using System.Diagnostics;

namespace EventLogSend.Method
{
    public static class Sources
    {
        public static void Report(string eventLogName, HashSet<EventLogEntry> eventLogEntriesHs, DateTime dateTime)
        {
            if (eventLogName.Equals("System"))
            {
                Line.Store.Add("");
                Line.Store.Add("---- Critical, Microsoft-Windows-WHEA-Logger ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
                        if (eventLogEntry.EntryType.ToString().Equals("0") & eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
                        {
                            string line = string.Concat(
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
                Line.Store.Add("---- Error, Microsoft-Windows-WHEA-Logger ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
                        if (eventLogEntry.EntryType.ToString().Equals("Error") & eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
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
                                    //" - Data ", eventLogEntry.Data,
                                    //" - EntryType ", eventLogEntry.EntryType,
                                    //eventLogEntry.EntryType,
                                    //", ", eventLogEntry.Source,
                                    //", EventId ", eventLogEntry.InstanceId,
                                    //", Index ", eventLogEntry.Index
                                    //", MachineName ", eventLogEntry.MachineName,
                                    Message.Filter(eventLogEntry.Message, 1000),
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
                Line.Store.Add("---- Warning, Microsoft-Windows-WHEA-Logger ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
                        if (eventLogEntry.EntryType.ToString().Equals("Warning") & eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
                        {
                            bool send = true;
                            if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
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
                                    //", ", eventLogEntry.Source,
                                    //", EventId ", eventLogEntry.InstanceId,
                                    //", Index ", eventLogEntry.Index
                                    //", MachineName ", eventLogEntry.MachineName,
                                    Message.Filter(eventLogEntry.Message, 1000),
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
                Line.Store.Add("---- Information, Microsoft-Windows-WHEA-Logger ----");
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
                    {
                        if (eventLogEntry.EntryType.ToString().Equals("Information") & eventLogEntry.Source.ToString().Equals("Microsoft-Windows-WHEA-Logger"))
                        {
                            bool send = true;
                            if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
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
                                    //", ", eventLogEntry.Source,
                                    //", EventId ", eventLogEntry.InstanceId,
                                    //", Index ", eventLogEntry.Index
                                    //", MachineName ", eventLogEntry.MachineName,
                                    Message.Filter(eventLogEntry.Message, 1000),
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
