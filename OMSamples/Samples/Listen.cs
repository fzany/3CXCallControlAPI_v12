using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.PBXAPI;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("listen")]
    [SampleParam("arg1", "CallID taken from ActiveConnection")]
    [SampleParam("arg2", "Extension number which should listen the call")]
    [SampleDescription("Show how to use PBXAPI.Listen()")]
    class ListenSample : ISample
    {
        public void Run(params string[] args)
        {
            Extension e = PhoneSystem.Root.GetDNByNumber(args[2]) as Extension;
            if (e != null)
            {
                PBXConnection pbx = Utilities.CreatePbxConn();
                pbx.Listen(System.Convert.ToInt32(args[1]), args[2]);
            }
        }
    }
}
