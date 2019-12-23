using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using TCX.Configuration;

namespace OMSamples
{
    public static class Utilities
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        static extern int GetKeyValueA(string strSection, string strKeyName, string strNull, StringBuilder RetVal, int nSize, string strFileName);
        static public string GetKeyValue(string Section, string KeyName, string FileName)
        {
            //Reading The KeyValue Method
            try
            {
                StringBuilder JStr = new StringBuilder(255);
                int i = GetKeyValueA(Section, KeyName, String.Empty, JStr, 255, FileName);
                return JStr.ToString();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static TCX.PBXAPI.PBXConnection CreatePbxConn()
        {
            String filePath = Path.Combine(GetAppPath(), @"Bin\3CXPhoneSystem.ini");
            String pbxUser = String.Empty,
                   pbxPass = String.Empty,
                   pbxHost = "127.0.0.1";
            Int32 pbxPort = 5482;//default value according to stepan
            String value = GetKeyValue("General", "PBXUser", filePath);
            if (!String.IsNullOrEmpty(value))
                pbxUser = value;
            value = GetKeyValue("General", "PBXPass", filePath);
            if (!String.IsNullOrEmpty(value))
                pbxPass = value;
            value = GetKeyValue("General", "CMHost", filePath);
            if (!String.IsNullOrEmpty(value))
                pbxHost = value;
            value = GetKeyValue("General", "CMPort", filePath);
            if (!String.IsNullOrEmpty(value))
            {
                Int32.TryParse(value, out pbxPort);
            }
            //obsolete. must not be used ?????????????????????????/
            //PBXConnection pbx = new PBXConnection();
            return new TCX.PBXAPI.PBXConnection(pbxHost, pbxPort, pbxUser, pbxPass);
        }

        public static String GetAppPath()
        {
            RegistryKey regKeyAppRoot;
            if (IntPtr.Size == 4)
            {
                regKeyAppRoot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\3CX\\PhoneSystem");
            }
            else
            {
                regKeyAppRoot = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\3CX\\PhoneSystem");
            }
            return (string)regKeyAppRoot.GetValue("AppPath");
        }
    }
}
