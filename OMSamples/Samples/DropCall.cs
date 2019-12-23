using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using TCX.PBXAPI;

namespace OMSamples.Samples
{
    [SampleCode("dropcall")]
    [SampleParam("arg1", "CallID taken from ActiveConnection")]
    [SampleParam("arg2", "Participant which should be removed from the call")]
    [SampleDescription("Shows how to drop call using Call Control API")]
    class DropCallSample : ISample
    {
        public void Run(params string[] args)
        {
            DN dn = PhoneSystem.Root.GetDNByNumber(args[2]);
            ActiveConnection[] conns = dn.GetActiveConnections();
            bool found = false;
            foreach (ActiveConnection ac in conns)
            {
                if (ac.CallID == int.Parse(args[1]))
                {
                    PBXConnection pbx = Utilities.CreatePbxConn();
                    pbx.DropCall(System.Convert.ToInt32(args[1]), args[2]);
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine(args[2] + " does not participate in call " + args[1]);
        }
    }
}
