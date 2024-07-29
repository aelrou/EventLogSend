using System.Diagnostics;

namespace EventLogSend
{
    static class Statistics
    {
        //internal static void Report(string logName, EventLog[] eventLogs)
        internal static void Report(string logName)
        {
            //foreach (EventLog eventLog in eventLogs)
            //{
            //if (logName.Equals("System") & eventLog.Log.Equals(logName))
            if (logName.Equals("System"))
            {
                int criticalCount = 0;
                int errorCount = 0;
                int warningCount = 0;
                int informationCount = 0;

                //foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                foreach (EventLogEntry eventLogEntry in Value.systemLogEntryHashset)
                {
                    //if (eventLogEntry.TimeGenerated >= Value.OldestDate[0])
                    //{
                    switch (eventLogEntry.EntryType.ToString())
                    {
                        case "0":
                            criticalCount += 1;
                            break;
                        case "Error":
                            errorCount += 1;
                            break;
                        case "Warning":
                            warningCount += 1;
                            break;
                        case "Information":
                            informationCount += 1;
                            break;
                        default:
                            break;
                    }
                    //}
                }
                Value.Log.Add("");
                //Value.Log.Add(string.Concat(eventLog.Log, " log counts"));
                Value.Log.Add(string.Concat(logName, " log counts"));
                Value.Log.Add(string.Concat("  Critical    ", criticalCount.ToString()));
                Value.Log.Add(string.Concat("  Error       ", errorCount.ToString()));
                Value.Log.Add(string.Concat("  Warning     ", warningCount.ToString()));
                Value.Log.Add(string.Concat("  Information ", informationCount.ToString()));
                Value.Log.Add(string.Concat("  Unknown     ", Value.systemLogEntryHashset.Count - (criticalCount + errorCount + warningCount + informationCount)));
                //Value.Log.Add(string.Concat("  Unknown     ", eventLog.Entries.Count - (criticalCount + errorCount + warningCount + informationCount)));
            }

            //if (logName.Equals("Application") & eventLog.Log.Equals(logName))
            if (logName.Equals("Application"))
            {
                int criticalCount = 0;
                int errorCount = 0;
                int warningCount = 0;
                int informationCount = 0;

                foreach (EventLogEntry eventLogEntry in Value.applicationLogEntryHashset)
                {
                    //if (eventLogEntry.TimeGenerated >= Value.OldestDate[0])
                    //{
                    switch (eventLogEntry.EntryType.ToString())
                    {
                        case "0":
                            criticalCount += 1;
                            break;
                        case "Error":
                            errorCount += 1;
                            break;
                        case "Warning":
                            warningCount += 1;
                            break;
                        case "Information":
                            informationCount += 1;
                            break;
                        default:
                            break;
                    }
                    //}
                }
                Value.Log.Add("");
                //Value.Log.Add(string.Concat(eventLog.Log, " log counts"));
                Value.Log.Add(string.Concat(logName, " log counts"));
                Value.Log.Add(string.Concat("  Critical    ", criticalCount.ToString()));
                Value.Log.Add(string.Concat("  Error       ", errorCount.ToString()));
                Value.Log.Add(string.Concat("  Warning     ", warningCount.ToString()));
                Value.Log.Add(string.Concat("  Information ", informationCount.ToString()));
                Value.Log.Add(string.Concat("  Unknown     ", Value.applicationLogEntryHashset.Count - (criticalCount + errorCount + warningCount + informationCount)));
                //Value.Log.Add(string.Concat("  Unknown     ", eventLog.Entries.Count - (criticalCount + errorCount + warningCount + informationCount)));
            }

            //if (logName.Equals("Security") & eventLog.Log.Equals(logName))
            if (logName.Equals("Security"))
            {
                int auditFailureCount = 0;
                int auditSuccessCount = 0;

                //foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                foreach (EventLogEntry eventLogEntry in Value.securityLogEntryHashset)
                {
                    //if (eventLogEntry.TimeGenerated >= Value.OldestDate[0])
                    //{
                    switch (eventLogEntry.EntryType.ToString())
                    {
                        case "FailureAudit":
                            auditFailureCount += 1;
                            break;
                        case "SuccessAudit":
                            auditSuccessCount += 1;
                            break;
                        default:
                            break;
                    }
                    //}
                }
                Value.Log.Add("");
                //Value.Log.Add(string.Concat(eventLog.Log, " log counts"));
                Value.Log.Add(string.Concat(logName, " log counts"));
                Value.Log.Add(string.Concat("  AuditSuccess ", auditSuccessCount.ToString()));
                Value.Log.Add(string.Concat("  AuditFailure ", auditFailureCount.ToString()));
                Value.Log.Add(string.Concat("  Unknown      ", Value.securityLogEntryHashset.Count - (auditFailureCount + auditSuccessCount)));
                //Value.Log.Add(string.Concat("  Unknown      ", eventLog.Entries.Count - (auditFailureCount + auditSuccessCount)));
            }
            //}
        }
    }
}
