using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;


namespace EventLogSend
{
    public static class ReportEventLog
    {
        public static void Properties()
        {
            HashSet<EventLog> eventLogsHs = new HashSet<EventLog>();
            HashSet<EventLogEntry> applicationLogEntriesHs = new HashSet<EventLogEntry>();
            HashSet<EventLogEntry> securityLogEntriesHs = new HashSet<EventLogEntry>();
            HashSet<EventLogEntry> systemLogEntriesHs = new HashSet<EventLogEntry>();

            EventLog[] eventLogs = EventLog.GetEventLogs();
            Console.WriteLine("Populating HashSet<EventLog>");
            eventLogsHs = eventLogs.ToHashSet();

            foreach (EventLog eventLog in eventLogsHs)
            {
                if (eventLog.Log.ToString().Equals("Application"))
                {
                    Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        applicationLogEntriesHs.Add(eventLogEntry);
                    }
                }
                if (eventLog.Log.ToString().Equals("System"))
                {
                    Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        systemLogEntriesHs.Add(eventLogEntry);
                    }
                }
                if (eventLog.Log.ToString().Equals("Security"))
                {
                    Console.WriteLine(string.Concat("Populating ", eventLog.Log.ToString(), " HashSet<EventLogEntry>"));
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        securityLogEntriesHs.Add(eventLogEntry);
                    }
                }
            }
            Console.WriteLine("Done");

            // Iterate through event logs and display properties for each
            foreach (EventLog eventLog in eventLogsHs)
            {
                RegistryKey? regEventLog = null;
                object? logPath = null;
                FileInfo? logFile = null;
                ulong? logSize = null;

                try
                {
                    // Get event log file if there is one
                    regEventLog = Registry.LocalMachine.OpenSubKey(string.Concat("System\\CurrentControlSet\\Services\\EventLog\\", eventLog.Log));
                    ArgumentNullException.ThrowIfNull(regEventLog);
                    try
                    {
                        logPath = regEventLog.GetValue("File");
                        ArgumentNullException.ThrowIfNull(logPath);
                        try
                        {
                            logFile = new FileInfo(logPath.ToString()!);
                            ArgumentNullException.ThrowIfNull(logFile);
                            // Get event log file size in kilobytes
                            logSize = Convert.ToUInt64(Math.Ceiling(Convert.ToDecimal(logFile.Length / 1024)));
                        }
                        catch (ArgumentNullException)
                        {
                            logSize = 0;
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        logPath = "<not set>";
                        logSize = 0;
                    }
                }
                catch (ArgumentNullException)
                {
                    logPath = "<not set>";
                    logSize = 0;
                }

                Console.WriteLine();
                Console.WriteLine(string.Concat(eventLog.LogDisplayName, ":"));
                Console.WriteLine(string.Concat("  Log name =\t\t", eventLog.Log.ToString()));
                Console.WriteLine(string.Concat("  Log entry count =\t", eventLog.Entries.Count.ToString()));
                Console.WriteLine(string.Concat("  Log file path =\t", logPath.ToString()));
                Console.WriteLine(string.Concat("  Current size =\t", logSize.ToString(), " kilobytes"));
                Console.WriteLine(string.Concat("  Maximum size =\t", eventLog.MaximumKilobytes.ToString(), " kilobytes"));
                // Get event log overwrite policy
                Console.WriteLine(string.Concat("  Overflow setting =\t", eventLog.OverflowAction.ToString()));
                switch (eventLog.OverflowAction)
                {
                    case OverflowAction.OverwriteOlder:
                        Console.WriteLine(string.Concat("  Entries are retained for at least ", eventLog.MinimumRetentionDays, " days."));
                        break;
                    case OverflowAction.DoNotOverwrite:
                        Console.WriteLine("  Entries are not overwritten.");
                        break;
                    case OverflowAction.OverwriteAsNeeded:
                        Console.WriteLine("  Oldest entries are overwritten when the log reaches the size limit.");
                        break;
                    default:
                        break;
                }
            }

            foreach (EventLogEntry eventLogEntry in applicationLogEntriesHs)
            {
                Console.WriteLine("--------");
                Console.WriteLine("LogName Application");
                Console.WriteLine(string.Concat("Category ", eventLogEntry.Category));
                Console.WriteLine(string.Concat("CategoryNumber ", eventLogEntry.CategoryNumber));
                Console.WriteLine(string.Concat("Data ", eventLogEntry.Data));
                Console.WriteLine(string.Concat("EntryType ", eventLogEntry.EntryType));
                Console.WriteLine(string.Concat("Index ", eventLogEntry.Index));
                Console.WriteLine(string.Concat("InstanceId ", eventLogEntry.InstanceId));
                Console.WriteLine(string.Concat("MachineName ", eventLogEntry.MachineName));
                Console.WriteLine(string.Concat("Message ", eventLogEntry.Message));
                Console.WriteLine(string.Concat("ReplacementStrings ", eventLogEntry.ReplacementStrings));
                Console.WriteLine(string.Concat("TimeGenerated ", eventLogEntry.TimeGenerated));
                Console.WriteLine(string.Concat("TimeWritten ", eventLogEntry.TimeWritten));
                Console.WriteLine(string.Concat("UserName ", eventLogEntry.UserName));
                break;
            }

            foreach (EventLogEntry eventLogEntry in systemLogEntriesHs)
            {
                Console.WriteLine("--------");
                Console.WriteLine("LogName System");
                Console.WriteLine(string.Concat("Category ", eventLogEntry.Category));
                Console.WriteLine(string.Concat("CategoryNumber ", eventLogEntry.CategoryNumber));
                Console.WriteLine(string.Concat("Data ", eventLogEntry.Data));
                Console.WriteLine(string.Concat("EntryType ", eventLogEntry.EntryType));
                Console.WriteLine(string.Concat("Index ", eventLogEntry.Index));
                Console.WriteLine(string.Concat("InstanceId ", eventLogEntry.InstanceId));
                Console.WriteLine(string.Concat("MachineName ", eventLogEntry.MachineName));
                Console.WriteLine(string.Concat("Message ", eventLogEntry.Message));
                Console.WriteLine(string.Concat("ReplacementStrings ", eventLogEntry.ReplacementStrings));
                Console.WriteLine(string.Concat("TimeGenerated ", eventLogEntry.TimeGenerated));
                Console.WriteLine(string.Concat("TimeWritten ", eventLogEntry.TimeWritten));
                Console.WriteLine(string.Concat("UserName ", eventLogEntry.UserName));
                break;
            }

            foreach (EventLogEntry eventLogEntry in securityLogEntriesHs)
            {
                Console.WriteLine("--------");
                Console.WriteLine("LogName Security");
                Console.WriteLine(string.Concat("Category ", eventLogEntry.Category));
                Console.WriteLine(string.Concat("CategoryNumber ", eventLogEntry.CategoryNumber));
                Console.WriteLine(string.Concat("Data ", eventLogEntry.Data));
                Console.WriteLine(string.Concat("EntryType ", eventLogEntry.EntryType));
                Console.WriteLine(string.Concat("Index ", eventLogEntry.Index));
                Console.WriteLine(string.Concat("InstanceId ", eventLogEntry.InstanceId));
                Console.WriteLine(string.Concat("MachineName ", eventLogEntry.MachineName));
                Console.WriteLine(string.Concat("Message ", eventLogEntry.Message));
                Console.WriteLine(string.Concat("ReplacementStrings ", eventLogEntry.ReplacementStrings));
                Console.WriteLine(string.Concat("TimeGenerated ", eventLogEntry.TimeGenerated));
                Console.WriteLine(string.Concat("TimeWritten ", eventLogEntry.TimeWritten));
                Console.WriteLine(string.Concat("UserName ", eventLogEntry.UserName));
                break;
            }

            DateTime dateTime = DateTime.UtcNow.AddYears(-10);
            Console.WriteLine();
            Console.WriteLine(string.Concat("Entries newer than ", dateTime.ToString(Constants.DateFormat, CultureInfo.InvariantCulture)));
            Console.WriteLine();
            Method.Statistics.Report("Application", applicationLogEntriesHs, dateTime);
            Console.WriteLine();
            Method.Statistics.Report("System", systemLogEntriesHs, dateTime);
            Console.WriteLine();
            Method.Statistics.Report("Security", securityLogEntriesHs, dateTime);
        }
    }
}
