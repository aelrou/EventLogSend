using Microsoft.Win32;

namespace EventLogSend.Method
{
    static class RegistryOs
    {
        internal static string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName.Equals("")) return "";
            //return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName + (CSDVersion != "" ? " " + CSDVersion : "");
            return string.Concat(ProductName.StartsWith("Microsoft") ? "" : "Microsoft ", ProductName, CSDVersion.Equals("") ? string.Concat(" ", CSDVersion) : "");
        }
        static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk.Equals(null)) return "";
                return rk.GetValue(key).ToString();
            }
            catch { return ""; }
        }
    }
}
