using System;
using System.Collections.Generic;
using System.Text;
using TCX.Configuration;
using TCX.PBXAPI;
using System.Threading;
using System.IO;

namespace OMSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Random a = new Random(Environment.TickCount);
                //unique name PhoneSystem.ApplicationName = "TestApi";//any name
                PhoneSystem.ApplicationName = PhoneSystem.ApplicationName + a.Next().ToString();
            }

            #region phone system initialization(init db server)

            String _appPath = Utilities.GetAppPath();
            String filePath = Path.Combine(_appPath, @"Bin\3CXPhoneSystem.ini");
            String value = Utilities.GetKeyValue("ConfService", "ConfPort", filePath);
            Int32 port = 0;
            if (!String.IsNullOrEmpty(value))
            {
                Int32.TryParse(value.Trim(), out port);
                PhoneSystem.CfgServerPort = port;
            }
            value = Utilities.GetKeyValue("ConfService", "confUser", filePath);
            if (!String.IsNullOrEmpty(value))
                PhoneSystem.CfgServerUser = value;
            value = Utilities.GetKeyValue("ConfService", "confPass", filePath);
            if (!String.IsNullOrEmpty(value))
                PhoneSystem.CfgServerPassword = value;
            #endregion
            DN[] ps = PhoneSystem.Root.GetDN(); //Access PhoneSystem.Root to initialize ObjectModel
            SampleStarter.StartSample(args);
        }
    }
}