namespace EventLogSend.Method
{
    static class Message
    {
        internal static string Filter(string message, int keep)
        {
            if (message.Contains("The description for Event ID")) return "";
            message = message.Replace(Value.crlf, " "); // Remove Cr+Lf
            message = message.Replace(Value.cr, " "); // Remove carriage returns
            message = message.Replace(Value.lf, " "); // Remove line feeds
            message = message.Replace(Value.t, " "); // Remove tabs
            message = message.Replace(Value.nbsp, " "); // Remove non-breaking spaces
            while (true)
            {
                message = message.Replace("  ", " "); // Collapse consecutive spaces
                int index = message.IndexOf("  "); 
                if (index == -1) break;
            }
            message = message.Replace(" ,", ","); // Remove spaces preceding commas
            message = message[..Math.Min(keep, message.Length)]; // Truncate to specified character count
            return message;
        }
    }
}
