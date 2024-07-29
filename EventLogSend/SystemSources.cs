using System.Diagnostics;
using EventLogSend.Method;

namespace EventLogSend
{
    static class SystemSources
    {
        internal static void Report(string sourceName)
        {
            HashSet<string> entryCriticalList = new HashSet<string>();
            HashSet<string> entryErrorList = new HashSet<string>();
            HashSet<string> entryWarningList = new HashSet<string>();
            HashSet<string> entryInfoList = new HashSet<string>();

            foreach (EventLogEntry eventLogEntry in Value.systemLogEntryHashset)
            {
                string line = "";
                if (eventLogEntry.EntryType.ToString().Equals("0") & eventLogEntry.Source.Equals(sourceName))
                {
                    bool send = true;
                    //if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected")) { send = false; }
                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //"Critical",
                            //", ", eventLogEntry.Source,
                            "Id ", eventLogEntry.InstanceId,
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

                if (eventLogEntry.EntryType.ToString().Equals("Error") & eventLogEntry.Source.Equals(sourceName))
                {
                    bool send = true;
                    //if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected")) { send = false; }
                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //eventLogEntry.EntryType,
                            //", ", eventLogEntry.Source,
                            //", EventId ", eventLogEntry.InstanceId,
                            //", Index ", eventLogEntry.Index
                            //", MachineName ", eventLogEntry.MachineName,
                            Message.Filter(eventLogEntry.Message, 1000),
                            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                            //", UserName ", eventLogEntry.UserName
                        );
                        entryErrorList.Add(line);
                    }
                }

                if (eventLogEntry.EntryType.ToString().Equals("Warning") & eventLogEntry.Source.Equals(sourceName))
                {
                    bool send = true;
                    //if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed")) { send = false; }
                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //eventLogEntry.EntryType,
                            //", ", eventLogEntry.Source,
                            //", EventId ", eventLogEntry.InstanceId,
                            //", Index ", eventLogEntry.Index
                            //", MachineName ", eventLogEntry.MachineName,
                            Message.Filter(eventLogEntry.Message, 1000),
                            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                            //", UserName ", eventLogEntry.UserName
                        );
                        entryWarningList.Add(line);
                    }
                }

                if (eventLogEntry.EntryType.ToString().Equals("Information") & eventLogEntry.Source.Equals(sourceName))
                {
                    bool send = true;
                    //if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected")) { send = false; }
                    if (send)
                    {
                        line = string.Concat(
                            //"Category ", eventLogEntry.Category,
                            //" - CategoryNumber ", eventLogEntry.CategoryNumber,
                            //" - Data ", eventLogEntry.Data,
                            //" - EntryType ", eventLogEntry.EntryType,
                            //eventLogEntry.EntryType,
                            //", ", eventLogEntry.Source,
                            //", EventId ", eventLogEntry.InstanceId,
                            //", Index ", eventLogEntry.Index
                            //", MachineName ", eventLogEntry.MachineName,
                            Message.Filter(eventLogEntry.Message, 1000),
                            ", ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat)
                            //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                            //", TimeGenerated ", eventLogEntry.TimeGenerated.ToString(Value.DateFormat),
                            //", UserName ", eventLogEntry.UserName
                        );
                        entryInfoList.Add(line);
                    }
                }
            }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- System, Critical, ", sourceName, " ----"));
            foreach (string line in entryCriticalList) { Value.Log.Add(line); }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- System, Error, ", sourceName, " ----"));
            foreach (string line in entryErrorList) { Value.Log.Add(line); }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- System, Warning, ", sourceName, " ----"));
            foreach (string line in entryWarningList) { Value.Log.Add(line); }

            Value.Log.Add("");
            Value.Log.Add(string.Concat("---- System, Information, ", sourceName, " ----"));
            foreach (string line in entryInfoList) { Value.Log.Add(line); }
        }
    }
}
