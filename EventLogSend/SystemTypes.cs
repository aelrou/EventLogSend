using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    static class SystemTypes
    {
        internal static void Report()
        {
            string logName = "System";
            HashSet<string> entryCriticalList = new HashSet<string>();
            HashSet<string> entryErrorList = new HashSet<string>();
            HashSet<string> entryWarningList = new HashSet<string>();
            //HashSet<string> entryInfoList = new HashSet<string>();

            foreach (EventLogEntry eventLogEntry in Value.systemLogEntryHashset)
            {
                string line = "";
                if (eventLogEntry.EntryType.ToString().Equals("0"))
                {
                    bool send = true;
                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //"Critical",
                            eventLogEntry.Source,
                            ", Id ", eventLogEntry.InstanceId,
                            //", Index ", eventLogEntry.Index
                            //", MachineName ", eventLogEntry.MachineName,
                            ", ", Message.Filter(eventLogEntry.Message, 1000),
                            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                            //", UserName ", eventLogEntry.UserName
                        );
                        entryCriticalList.Add(line);
                    }
                }

                if (eventLogEntry.EntryType.ToString().Equals("Error"))
                {
                    bool send = true;
                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("DCOM") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("SNMP") & eventLogEntry.Message.ToString().Contains("encountered an error while accessing the registry key"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("Service Control Manager") & eventLogEntry.Message.ToString().Contains("The Printer Extensions and Notifications service"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WMI") & eventLogEntry.Message.ToString().Contains("attempted to"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
                    {
                        send = false;
                    }

                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //eventLogEntry.EntryType,
                            eventLogEntry.Source,
                            //", EventId ", eventLogEntry.InstanceId,
                            //", Index ", eventLogEntry.Index
                            //", MachineName ", eventLogEntry.MachineName,
                            ", ", Message.Filter(eventLogEntry.Message, 1000),
                            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                            //", UserName ", eventLogEntry.UserName
                        );
                        entryErrorList.Add(line);
                    }
                }

                if (eventLogEntry.EntryType.ToString().Equals("Warning"))
                {
                    bool send = true;
                    if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("DCOM") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("HTTP") & eventLogEntry.Message.ToString().Contains("description for Event ID"))
                    {
                        send = false;
                    }
                    if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
                    {
                        send = false;
                    }

                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //eventLogEntry.EntryType,
                            eventLogEntry.Source,
                            //", EventId ", eventLogEntry.InstanceId,
                            //", Index ", eventLogEntry.Index
                            //", MachineName ", eventLogEntry.MachineName,
                            ", ", Message.Filter(eventLogEntry.Message, 1000),
                            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                            //", UserName ", eventLogEntry.UserName
                        );
                        entryWarningList.Add(line);
                    }
                }
                //if (eventLogEntry.EntryType.ToString().Equals("Information"))
                //{
                //    bool send = true;
                //    if (send)
                //    {
                //        line = string.Concat(
                //            //"Category ", eventLogEntry.Category,
                //            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                //            //" - Data ", eventLogEntry.Data,
                //            //" - EntryType ", eventLogEntry.EntryType,
                //            //"Critical",
                //            eventLogEntry.Source,
                //            ", Id ", eventLogEntry.InstanceId,
                //            //", Index ", eventLogEntry.Index
                //            //", MachineName ", eventLogEntry.MachineName,
                //            ", ", Message.Filter(eventLogEntry.Message, 1000),
                //            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                //            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                //            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                //            //", UserName ", eventLogEntry.UserName
                //        );
                //        entryInfoList.Add(line);
                //    }
                //}
            }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- ", logName, ", Critical ----"));
            foreach (string entry in entryCriticalList) { Value.Log.Add(entry); }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- ", logName, ", Error ----"));
            foreach (string entry in entryErrorList) { Value.Log.Add(entry); }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- ", logName, ", Warning ----"));
            foreach (string entry in entryWarningList) { Value.Log.Add(entry); }

            //Value.Log.Add("");
            //Value.Log.Add(string.Concat("---- ", logName, ", Information ----"));
            //foreach (string entry in entryInfoList) { Value.Log.Add(entry); }
        }
    }
}
