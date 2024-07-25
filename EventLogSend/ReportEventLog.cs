﻿using Microsoft.Win32;
using System.Diagnostics;

namespace EventLogSend
{
    public static class ReportEventLog
    {
        public static void Properties()
        {
            // Iterate through event logs and display properties for each
            EventLog[] eventLogs = EventLog.GetEventLogs();
            foreach (EventLog e in eventLogs)
            {
                RegistryKey? regEventLog = null;
                object? logPath = null;
                FileInfo? logFile = null;
                ulong? logSize = null;

                try
                {
                    // Get event log file if there is one
                    regEventLog = Registry.LocalMachine.OpenSubKey(string.Concat("System\\CurrentControlSet\\Services\\EventLog\\", e.Log));
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
                Console.WriteLine(string.Concat(e.LogDisplayName, ":"));
                Console.WriteLine(string.Concat("  Log name =\t\t", e.Log.ToString()));
                Console.WriteLine(string.Concat("  Log entry count =\t", e.Entries.Count.ToString()));
                Console.WriteLine(string.Concat("  Log file path =\t", logPath.ToString()));
                Console.WriteLine(string.Concat("  Current size =\t", logSize.ToString(), " kilobytes"));
                // Get event log overwrite policy
                Console.WriteLine(string.Concat("  Maximum size =\t", e.MaximumKilobytes.ToString(), " kilobytes"));
                Console.WriteLine(string.Concat("  Overflow setting =\t", e.OverflowAction.ToString()));
                switch (e.OverflowAction)
                {
                    case OverflowAction.OverwriteOlder:
                        Console.WriteLine(string.Concat("  Entries are retained for at least ", e.MinimumRetentionDays, " days."));
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
        }
    }
}