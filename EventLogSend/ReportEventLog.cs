using Microsoft.Win32;
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
                object? path = null;
                FileInfo? file = null;
                ulong? sizeKB = null;

                Console.WriteLine();
                Console.WriteLine(string.Concat(e.LogDisplayName, ":"));
                Console.WriteLine(string.Concat("  Log name =\t\t", e.Log.ToString()));
                Console.WriteLine(string.Concat("  Log entry count =\t", e.Entries.Count.ToString()));

                try
                {
                    // Get event log file if there is one
                    regEventLog = Registry.LocalMachine.OpenSubKey(string.Concat("System\\CurrentControlSet\\Services\\EventLog\\", e.Log));
                    ArgumentNullException.ThrowIfNull(regEventLog);
                    try
                    {
                        path = regEventLog.GetValue("File");
                        ArgumentNullException.ThrowIfNull(path);
                        Console.WriteLine(string.Concat("  Log file path =\t", path.ToString()));
                        try
                        {
                            file = new FileInfo(path.ToString());
                            ArgumentNullException.ThrowIfNull(file);
                            // Get the event log file size
                            sizeKB = Convert.ToUInt64(file.Length / 1024);
                            if ((file.Length % 1024) != 0)
                            {
                                sizeKB++;
                            }
                            Console.WriteLine(string.Concat("  Current size =\t", sizeKB.ToString(), " kilobytes"));
                        }
                        catch (ArgumentNullException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("  Log file path =\t<not set>");
                    }
                }
                catch (ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                // Get event log overwrite policies
                sizeKB = Convert.ToUInt64(e.MaximumKilobytes);
                Console.WriteLine(string.Concat("  Maximum size =\t", sizeKB.ToString(), " kilobytes"));
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
