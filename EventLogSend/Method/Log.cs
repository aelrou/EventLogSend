
namespace EventLogSend.Method
{
    public static class Log
    {
        public static void Write(List<string> contents)
        {
            string logPath = string.Concat(Constants.WorkDir, "\\", Constants.OutputFile);

            foreach (string content in contents)
            {
                Console.WriteLine(content);
            }
            File.AppendAllLines(logPath, contents);
        }
    }
}
