namespace EventLogSend.Method
{
    static class Message
    {
        internal static string Filter(string message, int keep)
        {
            if (message.Contains("The description for Event ID")) return "";
            message = ASCII.SubstituteAmbiguous(message);
            string[] result = ASCII.CheckAscii(message); // Check for non ASCII characters
            if (result[1].Equals("0")) { }
            else
            {
                Console.WriteLine(result[2]);
                char[] charArray = result[2].ToCharArray();
                List<string> charList = new List<string>();
                foreach (char c in charArray) { charList.Add(c.ToString()); }
                message = ASCII.ReplaceCharList(message, charList, ""); // Remove non ASCII characters
            }
            message = ASCII.ReplaceCharList(message, ASCII.linebreak, "");
            message = ASCII.ReplaceCharList(message, ASCII.whitespace, " ");
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
