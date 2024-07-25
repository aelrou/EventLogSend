using System.Diagnostics;

namespace EventLogSend
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            EventLog[] EventLogs = EventLog.GetEventLogs();
            Console.WriteLine(string.Concat("Log count: ", EventLogs.Length));
            foreach (EventLog log in EventLogs)
            {
                Console.WriteLine(string.Concat("Log: ", log.Log));
            }

            ReportEventLog.Properties();
        }
    }
}
