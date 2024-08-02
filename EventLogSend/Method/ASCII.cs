namespace EventLogSend.Method
{
    class ASCII
    {
        internal static string[] CheckLinebreak(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, linebreak);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckWhitespace(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, whitespace);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckSpecial(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, special);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckReserved(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, reserved);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckNumeric(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, numeric);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckAlpha(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, alphaCap);
            text = RemoveCharList(text, alphaLow);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckAlternate(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, alternate);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckAlhpaExtended(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, alphaExtCap);
            text = RemoveCharList(text, alphaExtLow);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string[] CheckAmbiguous(string text)
        {
            string[] matchMismatch = ["", "", ""];
            int total = text.Length;
            text = RemoveCharList(text, ambiguous);
            int different = text.Length;
            int match = total - different;
            matchMismatch[2] = text;
            matchMismatch[1] = different.ToString();
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }
        
        internal static string SubstituteAmbiguous(string text)
        {
            text = text.Replace(Convert.ToString((char)128), "E"); // 0128 €
            text = text.Replace(Convert.ToString((char)130), ","); // 0130 ‚
            text = text.Replace(Convert.ToString((char)131), "f"); // 0131 ƒ
            text = text.Replace(Convert.ToString((char)132), ",,"); // 0132 „
            text = text.Replace(Convert.ToString((char)133), "..."); // 0133 …
            text = text.Replace(Convert.ToString((char)134), "+"); // 0134 †
            text = text.Replace(Convert.ToString((char)135), Convert.ToString((char)177)); // 0135 ‡		0177 ±
            text = text.Replace(Convert.ToString((char)136), "^"); // 0136 ˆ
            text = text.Replace(Convert.ToString((char)137), "%"); // 0137 ‰
            text = text.Replace(Convert.ToString((char)138), "S"); // 0138 Š
            text = text.Replace(Convert.ToString((char)139), "<"); // 0139 ‹
            text = text.Replace(Convert.ToString((char)140), "CE"); // 0140 Œ
            text = text.Replace(Convert.ToString((char)142), "Z"); // 0142 Ž
            text = text.Replace(Convert.ToString((char)145), "'"); // 0145 ‘
            text = text.Replace(Convert.ToString((char)146), "'"); // 0146 ’
            text = text.Replace(Convert.ToString((char)147), Convert.ToString((char)34)); // 0147 “		0034 "
            text = text.Replace(Convert.ToString((char)148), Convert.ToString((char)34)); // 0148 ”		0034 "
            text = text.Replace(Convert.ToString((char)149), "-"); // 0149 •
            text = text.Replace(Convert.ToString((char)150), "-"); // 0150 –
            text = text.Replace(Convert.ToString((char)151), "-"); // 0151 —
            text = text.Replace(Convert.ToString((char)152), "~"); // 0152 ˜
            text = text.Replace(Convert.ToString((char)153), "tm"); // 0153 ™
            text = text.Replace(Convert.ToString((char)154), "s"); // 0154 š
            text = text.Replace(Convert.ToString((char)155), ">"); // 0155 ›
            text = text.Replace(Convert.ToString((char)156), "ce"); // 0156 œ
            text = text.Replace(Convert.ToString((char)158), "z"); // 0158 ž
            text = text.Replace(Convert.ToString((char)159), Convert.ToString((char)255).ToUpper()); // 0159 Ÿ
            text = text.Replace(Convert.ToString((char)170), "a"); // 0170 ª
            text = text.Replace(Convert.ToString((char)173), "-"); // 0173
            text = text.Replace(Convert.ToString((char)178), "2"); // 0178 ²
            text = text.Replace(Convert.ToString((char)179), "3"); // 0179 ³
            text = text.Replace(Convert.ToString((char)185), "1"); // 0185 ¹
            text = text.Replace(Convert.ToString((char)186), "0"); // 0186 º
            text = text.Replace(Convert.ToString((char)198), "AE"); // 0198 Æ
            text = text.Replace(Convert.ToString((char)230), "ae"); // 0230 æ
            
            return text;
        }

        static string RemoveCharList(string text, List<string> charList)
        {
            int loop = 0;
            int stop = charList.Count;
            while (true)
            {
                if (loop >= stop) { break; }
                text = text.Replace(charList[loop], "");
                loop += 1;
            }
            return text;
        }

        internal static string[] CheckAscii(string text)
        {
            string[] matchMismatch = ["", "", ""];
            string[] linebreak = CheckLinebreak(text);
            string[] whitespace = CheckWhitespace(linebreak[2]);
            string[] special = CheckSpecial(whitespace[2]);
            string[] reserved = CheckReserved(special[2]);
            string[] numeric = CheckNumeric(reserved[2]);
            string[] alpha = CheckAlpha(numeric[2]);
            string[] alternate = CheckAlternate(alpha[2]);
            string[] alphaExt = CheckAlhpaExtended(alternate[2]);
            int match = int.Parse(linebreak[0])
                            + int.Parse(whitespace[0])
                            + int.Parse(special[0])
                            + int.Parse(reserved[0])
                            + int.Parse(numeric[0])
                            + int.Parse(alpha[0])
                            + int.Parse(alternate[0])
                            + int.Parse(alphaExt[0]);
            matchMismatch[2] = alphaExt[2];
            matchMismatch[1] = alphaExt[1];
            matchMismatch[0] = match.ToString();
            return matchMismatch;
        }

        internal static string ReplaceCharList(string text, List<string> charList, string newChar)
        {
            int loop = 0;
            int stop = charList.Count;
            while (true)
            {
                if (loop >= stop) { break; }
                if (!charList[loop].Equals(newChar))
                {
                    text = text.Replace(charList[loop], newChar);
                }
                loop += 1;
            }
            return text;
        }

        internal static void PrintTable()
        {
            string output = "";
            int loop = 1;
            int listEnd = all.Count;
            for (int i = 0; i < listEnd; i++)
            {
                {
                    if (all[i].Equals(Convert.ToString((char)126))) { output = string.Concat(output, " ", all[i], "\r\n"); loop = 1; }
                    else
                    {
                        if (loop == 1) { output = string.Concat(output, all[i]); loop += 1; }
                        else
                        {
                            if (1 < loop & loop < 8) { output = string.Concat(output, " ", all[i]); loop += 1; }
                            else { if (loop == 8) { output = string.Concat(output, " ", all[i], "\r\n"); loop = 1; } }
                        }
                    }
                }
            }
            Value.Log.Add(output);
        }

        internal static void PrintTypes()
        {
            string line = "";
            foreach (string character in linebreak) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("linebreak: ", line));

            line = "";
            foreach (string character in whitespace) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("whitespace: ", line));

            line = "";
            foreach (string character in special) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("special: ", line));

            line = "";
            foreach (string character in reserved) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("reserved: ", line));

            line = "";
            foreach (string character in numeric) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("numeric: ", line));

            line = "";
            foreach (string character in alphaCap) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("alphaCap: ", line));

            line = "";
            foreach (string character in alphaLow) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("alphaLow: ", line));

            line = "";
            foreach (string character in alternate) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("alternate: ", line));

            line = "";
            foreach (string character in alphaExtCap) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("alphaExtCap: ", line));

            line = "";
            foreach (string character in alphaExtLow) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("alphaExtLow: ", line));

            line = "";
            foreach (string character in ambiguous) { line = string.Concat(line, character); }
            Value.Log.Add(string.Concat("ambiguous: ", line));

            line = SubstituteAmbiguous(line);
            Value.Log.Add(string.Concat("converted: ", line));
        }

        internal static void FillTables()
        {
            char c;
            for (int i = 0; i <= 255; i++)
            {
                c = (char)i;

                if (i == 9 | i == 32 | i == 160) { whitespace.Add(c.ToString()); } // \t tab space nbsp

                if (i == 13 | i == 10) { linebreak.Add(c.ToString()); } // \r cr \n lf

                if (i == 34 | i == 42 | i == 47 | i == 58 | i == 60 | i == 62 | i == 63 | i == 92 | i == 124) { reserved.Add(c.ToString()); } // " * / : < > ? \ |

                if (i == 33 | i == 59 | i == 61 | i == 64 | i == 91 | i == 123 | i == 125 | i == 126) { special.Add(c.ToString()); } // ! ; = @ [ { } ~
                if (35 <= i & i <= 41) { special.Add(c.ToString()); } // # $ % & ' ( )
                if (43 <= i & i <= 46) { special.Add(c.ToString()); } // + , - .
                if (93 <= i & i <= 96) { special.Add(c.ToString()); } // ] ^ _ `

                if (48 <= i & i <= 57) { numeric.Add(c.ToString()); } // 0 1 2 3 4 5 6 7 8 9

                if (65 <= i & i <= 90) { alphaCap.Add(c.ToString()); } // A - Z
                if (97 <= i & i <= 122) { alphaLow.Add(c.ToString()); } // a - z

                if (161 <= i & i <= 169) { alternate.Add(c.ToString()); } // ¡ ¢ £ ¤ ¥ ¦ § ¨ ©
                if (i == 171 | i == 172 | i == 215 | i == 223 | i == 247) { alternate.Add(c.ToString()); } // « ¬ × ß ÷
                if (174 <= i & i <= 177) { alternate.Add(c.ToString()); } // ® ¯ ° ±
                if (180 <= i & i <= 184) { alternate.Add(c.ToString()); } // ´ µ ¶ · ¸
                if (187 <= i & i <= 191) { alternate.Add(c.ToString()); } // » ¼ ½ ¾ ¿

                if (130 <= i & i <= 140) { ambiguous.Add(c.ToString()); } // 
                if (145 <= i & i <= 156) { ambiguous.Add(c.ToString()); } // 
                if (i == 128 | i == 142 | i == 158 | i == 159 | i == 170 | i == 173 | i == 178 | i == 179 | i == 185 | i == 186 | i == 198 | i == 230 ) { ambiguous.Add(c.ToString()); } // 

                if (i == 159) { alphaExtCap.Add(Convert.ToString((char)255).ToUpper()); } // Ÿ
                if (192 <= i & i <= 197) { alphaExtCap.Add(c.ToString()); } // À Á Â Ã Ä Å
                if (199 <= i & i <= 214) { alphaExtCap.Add(c.ToString()); } // Ç È É Ê Ë Ì Í Î Ï Ð Ñ Ò Ó Ô Õ Ö
                if (216 <= i & i <= 222) { alphaExtCap.Add(c.ToString()); } // Ø Ù Ú Û Ü Ý Þ

                if (224 <= i & i <= 229) { alphaExtLow.Add(c.ToString()); } // à á â ã ä å
                if (231 <= i & i <= 246) { alphaExtLow.Add(c.ToString()); } // ç è é ê ë ì í î ï ð ñ ò ó ô õ ö
                if (248 <= i) { alphaExtLow.Add(c.ToString()); } // ø ù ú û ü ý þ ÿ

                if (32 <= i & i <= 126) { all.Add(c.ToString()); }
                if (128 <= i & i <= 158) { all.Add(c.ToString()); }
                if (i == 159) { all.Add(Convert.ToString((char)255).ToUpper()); }
                if (160 <= i) { all.Add(c.ToString()); }
            }
        }

        internal static readonly List<string> linebreak = new List<string>();
        internal static readonly List<string> whitespace = new List<string>();
        internal static readonly List<string> special = new List<string>();
        internal static readonly List<string> reserved = new List<string>();
        internal static readonly List<string> numeric = new List<string>();
        internal static readonly List<string> alphaCap = new List<string>();
        internal static readonly List<string> alphaLow = new List<string>();
        internal static readonly List<string> alternate = new List<string>();
        internal static readonly List<string> alphaExtCap = new List<string>();
        internal static readonly List<string> alphaExtLow = new List<string>();
        internal static readonly List<string> ambiguous = new List<string>();

        internal static readonly List<string> all = new List<string>();
    }
}
