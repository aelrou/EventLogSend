using System.Diagnostics;

namespace EventLogSend.Method
{
    static class SourcesCopy
    {
        internal static void Report(string sourceName, EventLog[] eventLogs)
        {
            foreach (EventLog eventLog in eventLogs)
            {
                if (eventLog.Log.Equals("System"))
                {
                    Value.Log.Add("");
                    Value.Log.Add(string.Concat("---- Critical, ", sourceName, " ----"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
                            if (eventLogEntry.EntryType.ToString().Equals("0") & eventLogEntry.Source.ToString().Equals(sourceName))
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
                                    ", ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)
                                //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                //", TimeGenerated ", eventLogEntry.TimeWritten.ToString(Value.DateFormat),
                                //", UserName ", eventLogEntry.UserName
                                );
                                Value.Log.Add(line);
                            }
                        }
                    }

                    Value.Log.Add("");
                    Value.Log.Add(string.Concat("---- Error, ", sourceName, " ----"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
                            if (eventLogEntry.EntryType.ToString().Equals("Error") & eventLogEntry.Source.ToString().Equals(sourceName))
                            {
                                bool send = true;
                                //if (eventLogEntry.Source.ToString().Equals("Microsoft-Windows-GroupPolicy") & eventLogEntry.Message.ToString().Contains("processing of Group Policy failed"))
                                //{
                                //    send = false;
                                //}

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
                                        ", ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeWritten.ToString(Value.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                    );
                                    Value.Log.Add(line);
                                }
                            }
                        }
                    }

                    Value.Log.Add("");
                    Value.Log.Add(string.Concat("---- Warning, ", sourceName, " ----"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
                            if (eventLogEntry.EntryType.ToString().Equals("Warning") & eventLogEntry.Source.ToString().Equals(sourceName))
                            {
                                bool send = true;
                                //if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
                                //{
                                //    send = false;
                                //}

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
                                        ", ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeWritten.ToString(Value.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                    );
                                    Value.Log.Add(line);
                                }
                            }
                        }
                    }
                    Value.Log.Add("");
                    Value.Log.Add(string.Concat("---- Information, ", sourceName, " ----"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
                            if (eventLogEntry.EntryType.ToString().Equals("Information") & eventLogEntry.Source.ToString().Equals(sourceName))
                            {
                                bool send = true;
                                //if (eventLogEntry.Source.ToString().Equals("LsaSrv") & eventLogEntry.Message.ToString().Contains("package is not signed as expected"))
                                //{
                                //    send = false;
                                //}

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
                                        ", ", eventLogEntry.TimeWritten.ToString(Value.DateFormat)
                                    //" - ReplacementStrings ", eventLogEntry.ReplacementStrings,
                                    //", TimeGenerated ", eventLogEntry.TimeWritten.ToString(Value.DateFormat),
                                    //", UserName ", eventLogEntry.UserName
                                    );
                                    Value.Log.Add(line);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
