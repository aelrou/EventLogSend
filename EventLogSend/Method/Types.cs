using System.Diagnostics;

namespace EventLogSend.Method
{
    public static class Types
    {
        public static void Report(string eventLogName, HashSet<EventLogEntry> eventLogEntriesHs, DateTime dateTime)
        {
            if (eventLogName.Equals("Application") | eventLogName.Equals("System"))
            {
                Line.Store.Add("");
                Line.Store.Add("---- Critical ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
                        if (eventLogEntry.EntryType.ToString().Equals("0"))
                        {
                            string line = string.Concat(
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
                                ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
                                //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
                                //", UserName ", eventLogEntry.UserName
                            );
                            Line.Store.Add(line);
                        }
                    }
                }

                Line.Store.Add("");
                Line.Store.Add("---- Error ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
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
                                string line = string.Concat(
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
                                    ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                );
                                Line.Store.Add(line);
                            }
                        }
                    }
                }

                Line.Store.Add("");
                Line.Store.Add("---- Warning ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
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
                                string line = string.Concat(
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
                                    ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                );
                                Line.Store.Add(line);
                            }
                        }
                    }
                }
            }

            if (eventLogName.Equals("Security"))
            {
                Line.Store.Add("");
                Line.Store.Add("---- FailureAudit ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
                        if (eventLogEntry.EntryType.ToString().Equals("FailureAudit"))
                        {
                            bool send = true;
                            if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed"))
                            {
                                send = false;
                            }

                            if (send)
                            {
                                string line = string.Concat(
                                    //"Category ", eventLogEntry.Category,
                                    //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                                    //" - EntryType ", eventLogEntry.EntryType,
                                    //eventLogEntry.EntryType,
                                    eventLogEntry.Source,
                                    //", ", eventLogEntry.InstanceId,
                                    //", Index ", eventLogEntry.Index
                                    //", MachineName ", eventLogEntry.MachineName,
                                    ", ", eventLogEntry.Data.GetHashCode(),
                                    ", ", Message.Filter(eventLogEntry.Message, 1000),
                                    ", ", eventLogEntry.TimeWritten.ToString(Constants.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Constants.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                );
                                Line.Store.Add(line);
                            }
                        }
                    }
                }
            }
        }
    }
}
