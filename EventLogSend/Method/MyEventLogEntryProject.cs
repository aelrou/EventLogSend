using System.Diagnostics;

namespace MyCSharpNamespace
{
    public static class MyEventLogEntryClass
    {
        public static void MyEventLogEntryMethod()
        {
            DateTime dateTime = DateTime.UtcNow.AddYears(-1);
            EventLog[] eventLogs = EventLog.GetEventLogs();
            foreach (EventLog eventLog in eventLogs)
            {
                if (eventLog.Log.Equals("Security"))
                {
                    foreach (EventLogEntry eventLogEntry in eventLog.Entries)
                    {
                        if (eventLogEntry.TimeWritten >= dateTime)
                        {
                            if (eventLogEntry.EntryType.ToString().Equals("FailureAudit"))
                            {
                                Console.WriteLine(eventLogEntry.Message.ToString());
                                //Console.WriteLine(eventLogEntry.Data.ToString());

                                // Accessing EventLogEntry.Data
                                byte[] data = eventLogEntry.Data;
                                if (data != null && data.Length > 0)
                                {
                                    // Process the data as needed
                                    string hex = BitConverter.ToString(data);
                                    Console.WriteLine($"Data (Hex): {hex}");

                                    // Convert to string if the data is a string
                                    string dataString = System.Text.Encoding.UTF8.GetString(data);
                                    Console.WriteLine($"Data (String): {dataString}");
                                }
                                else
                                {
                                    Console.WriteLine("No data available in the EventLogEntry.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
