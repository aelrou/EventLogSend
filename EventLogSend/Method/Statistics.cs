﻿using System.Diagnostics;
using System.Globalization;

namespace EventLogSend.Method
{
    public static class Statistics
    {
        public static void Report(string eventLogName, HashSet<EventLogEntry> eventLogEntriesHs, DateTime dateTime)
        {

            int criticalCount = 0;
            int errorCount = 0;
            int warningCount = 0;
            int informationCount = 0;
            int auditFailureCount = 0;
            int auditSuccessCount = 0;

            if (eventLogName.Equals("Application") | eventLogName.Equals("System"))
            {
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
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
                Console.WriteLine(string.Concat(eventLogName, " log counts"));
                Console.WriteLine(string.Concat("  Critical\t", criticalCount.ToString()));
                Console.WriteLine(string.Concat("  Error   \t", errorCount.ToString()));
                Console.WriteLine(string.Concat("  Warning \t", warningCount.ToString()));
                Console.WriteLine(string.Concat("  Information\t", informationCount.ToString()));
                Console.WriteLine(string.Concat("  Missed  \t", eventLogEntriesHs.Count - (criticalCount + errorCount + warningCount + informationCount)));
            }

            if (eventLogName.Equals("Security"))
            {
                foreach (EventLogEntry eventLogEntry in eventLogEntriesHs)
                {
                    if (eventLogEntry.TimeWritten >= dateTime)
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
                Console.WriteLine(string.Concat(eventLogName, " log counts"));
                Console.WriteLine(string.Concat("  AuditFailure\t", auditFailureCount.ToString()));
                Console.WriteLine(string.Concat("  AuditSuccess\t", auditSuccessCount.ToString()));
                Console.WriteLine(string.Concat("  Missed  \t", eventLogEntriesHs.Count - (auditFailureCount + auditSuccessCount)));
            }
        }
    }
}