namespace EventLogSend.Method
{
    static class Log
    {
        internal static void Write(List<string> contents)
        {
            string logPath = string.Concat(Value.WorkDir[0], "\\", Value.LogFile);
            while (true)
            {
                logPath = logPath.Replace("\\\\", "\\"); // Collapse consecutive slashes
                int index = logPath.IndexOf("\\\\");
                if (index == -1) break;
            }
            //foreach (string content in contents) Console.WriteLine(content);
            File.AppendAllLines(logPath, contents);
        }
    }
}
