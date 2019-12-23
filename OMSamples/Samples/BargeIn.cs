using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.PBXAPI;

namespace OMSamples.Samples
{
    [SampleCode("bargein")]
    [SampleParam("arg1", "Specisies active call. (see ActiveConnection object)")]
    [SampleParam("arg2", "Specifies Extension number which sshould be barged in to the call")]
    [SampleDescription("Call Control API. Demostrates How to use PBXAPI.BargeIn()")]
    class BargeInSample : ISample
    {
        public void Run(params string[] args)
        {
            PBXConnection pbx = Utilities.CreatePbxConn();
            pbx.BargeinCall(System.Convert.ToInt32(args[1]), args[2], false);
        }
    }
}
