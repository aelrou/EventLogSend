using System.Diagnostics;

namespace EventLogSend.Method
{
    static class StatisticsCopy
    {
        internal static void Report(EventLog[] eventLogs)
        {
            foreach (EventLog eventLog in eventLogs)
            {
                int criticalCount = 0;
                int errorCount = 0;
                int warningCount = 0;
                int informationCount = 0;

                if (eventLog.Log.Equals("System"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
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
                        }
                    }
                    Value.Log.Add("");
                    Value.Log.Add(string.Concat(eventLog.Log, " log counts"));
                    Value.Log.Add(string.Concat("  Critical    ", criticalCount.ToString()));
                    Value.Log.Add(string.Concat("  Error       ", errorCount.ToString()));
                    Value.Log.Add(string.Concat("  Warning     ", warningCount.ToString()));
                    Value.Log.Add(string.Concat("  Information ", informationCount.ToString()));
                    Value.Log.Add(string.Concat("  Unknown     ", eventLog.Entries.Count - (criticalCount + errorCount + warningCount + informationCount)));
                }
            }

            foreach (EventLog eventLog in eventLogs)
            {
                int criticalCount = 0;
                int errorCount = 0;
                int warningCount = 0;
                int informationCount = 0;

                if (eventLog.Log.Equals("Application"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
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
                        }
                    }
                    Value.Log.Add("");
                    Value.Log.Add(string.Concat(eventLog.Log, " log counts"));
                    Value.Log.Add(string.Concat("  Critical    ", criticalCount.ToString()));
                    Value.Log.Add(string.Concat("  Error       ", errorCount.ToString()));
                    Value.Log.Add(string.Concat("  Warning     ", warningCount.ToString()));
                    Value.Log.Add(string.Concat("  Information ", informationCount.ToString()));
                    Value.Log.Add(string.Concat("  Unknown     ", eventLog.Entries.Count - (criticalCount + errorCount + warningCount + informationCount)));
                }
            }

            foreach (EventLog eventLog in eventLogs)
            {
                int auditFailureCount = 0;
                int auditSuccessCount = 0;

                if (eventLog.Log.Equals("Security"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= Value.OldestDate[0])
                        {
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
                        }
                    }
                    Value.Log.Add("");
                    Value.Log.Add(string.Concat(eventLog.Log, " log counts"));
                    Value.Log.Add(string.Concat("  AuditFailure ", auditFailureCount.ToString()));
                    Value.Log.Add(string.Concat("  AuditSuccess ", auditSuccessCount.ToString()));
                    Value.Log.Add(string.Concat("  Unknown      ", eventLog.Entries.Count - (auditFailureCount + auditSuccessCount)));
                }
            }
        }
    }
}
