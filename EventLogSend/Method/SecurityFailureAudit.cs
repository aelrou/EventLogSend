using System.Diagnostics;

namespace EventLogSend.Method
{
    public static class SecurityFailureAudit
    {
        public static Dictionary<string, string> ParseDictionary(EventLogEntry entry)
        {
            Dictionary<string, string> messageData = new Dictionary<string, string>();

            // Check entry source is "Security" EventLog
            if (entry.Source.Equals("Microsoft-Windows-Security-Auditing"))
            {
                // Check entry type is "FailureAudit"
                if (entry.EntryType == EventLogEntryType.FailureAudit)
                {
                    // Check entry detail is "4625 An account failed to log on."
                    if (entry.InstanceId.Equals(4625))
                    {
                        string[] failureDataLines = entry.Message.Split(new string[] { Value.crlf, Value.cr, Value.lf }, StringSplitOptions.None);
                        int dataLineCount = failureDataLines.Length;

                        int startPosition = 99;
                        int subjectPosition = 99;
                        int loginFailPosition = 99;
                        int failInfoPosition = 99;
                        int processPosition = 99;
                        int networkPosition = 99;
                        int authPosition = 99;
                        int endPosition = 99;

                        for (int i = 0; i < dataLineCount; i++)
                        {
                            if (failureDataLines[i].Trim().Equals(@"An account failed to log on.")) { startPosition = i; }
                            if (i > startPosition & failureDataLines[i].Trim().Equals(@"Subject:")) { subjectPosition = i; }
                            if (i > subjectPosition & failureDataLines[i].Trim().Equals(@"Account For Which Logon Failed:")) { loginFailPosition = i; }
                            if (i > loginFailPosition & failureDataLines[i].Trim().Equals(@"Failure Information:")) { failInfoPosition = i; }
                            if (i > failInfoPosition & failureDataLines[i].Trim().Equals(@"Process Information:")) { processPosition = i; }
                            if (i > processPosition & failureDataLines[i].Trim().Equals(@"Network Information:")) { networkPosition = i; }
                            if (i > networkPosition & failureDataLines[i].Trim().Equals(@"Detailed Authentication Information:")) { authPosition = i; }
                            if (i > authPosition & failureDataLines[i].Trim().StartsWith(@"This event is generated when a logon request fails.")) { endPosition = i; }
                        }

                        HashSet<string> subjectSet = new HashSet<string>();
                        HashSet<string> loginFailSet = new HashSet<string>();
                        HashSet<string> failInfoSet = new HashSet<string>();
                        HashSet<string> processSet = new HashSet<string>();
                        HashSet<string> networkSet = new HashSet<string>();
                        HashSet<string> authSet = new HashSet<string>();

                        if (startPosition < subjectPosition
                            & subjectPosition < loginFailPosition
                            & loginFailPosition < failInfoPosition
                            & failInfoPosition < processPosition
                            & processPosition < networkPosition
                            & networkPosition < authPosition
                            & authPosition < endPosition
                            & endPosition < 99)
                        {
                            for (int i = subjectPosition; i < loginFailPosition; i++) { subjectSet.Add(failureDataLines[i]); }
                            for (int i = loginFailPosition; i < failInfoPosition; i++) { loginFailSet.Add(failureDataLines[i]); }
                            for (int i = failInfoPosition; i < processPosition; i++) { failInfoSet.Add(failureDataLines[i]); }
                            for (int i = processPosition; i < networkPosition; i++) { processSet.Add(failureDataLines[i]); }
                            for (int i = networkPosition; i < authPosition; i++) { networkSet.Add(failureDataLines[i]); }
                            for (int i = authPosition; i < endPosition; i++) { authSet.Add(failureDataLines[i]); }
                        }
                        else
                        {
                            Console.WriteLine("Message data heading mismatch");
                            Console.WriteLine(string.Concat("startPosition ", startPosition));
                            Console.WriteLine(string.Concat("subjectPosition ", subjectPosition));
                            Console.WriteLine(string.Concat("loginFailPosition ", loginFailPosition));
                            Console.WriteLine(string.Concat("failInfoPosition ", failInfoPosition));
                            Console.WriteLine(string.Concat("processPosition ", processPosition));
                            Console.WriteLine(string.Concat("networkPosition ", networkPosition));
                            Console.WriteLine(string.Concat("authPosition ", authPosition));
                            Console.WriteLine(string.Concat("endPosition ", endPosition));
                        }

                        //foreach (string line in subjectSet) { Console.WriteLine(line); }
                        //foreach (string line in loginFailSet) { Console.WriteLine(line); }
                        //foreach (string line in failInfoSet) { Console.WriteLine(line); }
                        //foreach (string line in processSet) { Console.WriteLine(line); }
                        //foreach (string line in networkSet) { Console.WriteLine(line); }
                        //foreach (string line in authSet) { Console.WriteLine(line); }

                        //Dictionary<string, string> subjectData = new Dictionary<string, string>();
                        foreach (string line in subjectSet)
                        {
                            string section = @"Subject:";
                            string key = @"Security ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Domain:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Logon ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Logon Type:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                        }

                        //Dictionary<string, string> loginInfoData = new Dictionary<string, string>();
                        foreach (string line in loginFailSet)
                        {
                            string section = @"Account For Which Logon Failed:";
                            string key = @"Security ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Account Domain:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        //Dictionary<string, string> newLogonData = new Dictionary<string, string>();
                        foreach (string line in failInfoSet)
                        {
                            string section = @"Failure Information:";
                            string key = @"Failure Reason:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Status:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Sub Status:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        //Dictionary<string, string> processData = new Dictionary<string, string>();
                        foreach (string line in processSet)
                        {
                            string section = @"Process Information:";
                            string key = @"Caller Process ID:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Caller Process Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        //Dictionary<string, string> networkData = new Dictionary<string, string>();
                        foreach (string line in networkSet)
                        {
                            string section = @"Network Information:";
                            string key = @"Workstation Name:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Source Network Address:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Source Port:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        //Dictionary<string, string> authData = new Dictionary<string, string>();
                        foreach (string line in authSet)
                        {
                            string section = @"Detailed Authentication Information:";
                            string key = @"Logon Process:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Authentication Package:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Transited Services:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Package Name (NTLM only):";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }

                            key = @"Key Length:";
                            if (LineKeyCheck(key, line))
                            {
                                messageData.Add(string.Concat(section, " ", key), LineGetValue(@key, line));
                            }
                        }

                        //Console.WriteLine("Dictionary lookups");
                        //foreach (var pair in subjectData) { Console.WriteLine(string.Concat(pair.Key, " ", pair.Value)); }
                        //foreach (var pair in loginInfoData) { Console.WriteLine(string.Concat(pair.Key, " ", pair.Value)); }
                        //foreach (var pair in newLogonData) { Console.WriteLine(string.Concat(pair.Key, " ", pair.Value)); }
                        //foreach (var pair in processData) { Console.WriteLine(string.Concat(pair.Key, " ", pair.Value)); }
                        //foreach (var pair in networkData) { Console.WriteLine(string.Concat(pair.Key, " ", pair.Value)); }
                        //foreach (var pair in authData) { Console.WriteLine(string.Concat(pair.Key, " ", pair.Value)); }

                        //messageData.Add(subjectData);
                        //messageData.Add(loginInfoData);
                        //messageData.Add(newLogonData);
                        //messageData.Add(processData);
                        //messageData.Add(networkData);
                        //messageData.Add(authData);
                    }
                }
            }
            return messageData;
        }
        private static bool LineKeyCheck(string key, string line)
        {
            if (line.Trim().StartsWith(key.Trim()))
            {
                return true;
            }
            return false;
        }
        private static string LineGetValue(string key, string line)
        {
            int position = line.IndexOf(key);
            string value = "";
            if (position != -1)
            {
                value = line.Substring(position + key.Length);
            }
            return value.Trim();
        }
    }
}
