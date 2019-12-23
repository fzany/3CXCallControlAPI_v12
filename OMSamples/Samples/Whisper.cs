using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.PBXAPI;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("whisper")]
    [SampleParam("arg1", "CallID taken from ActiveConnection")]
    [SampleParam("arg2", "new participant who will gives the instructions to the participant specified by arg3")]
    [SampleParam("arg3", "participant who requires instructions from new participant")]
    [SampleDescription("Shows how to use PBXAPI.WhisperTo()")]
    class WhisperSample : ISample
    {
        public void Run(params string[] args)
        {
            DN dn = PhoneSystem.Root.GetDNByNumber(args[3]);
            ActiveConnection[] conns = dn.GetActiveConnections();
            bool found = false;
            foreach (ActiveConnection ac in conns)
            {
                if (ac.CallID == int.Parse(args[1]) && ac.Status == ConnectionStatus.Connected)
                {
                    PBXConnection pbx = Utilities.CreatePbxConn();
                    pbx.WhisperTo(System.Convert.ToInt32(args[1]), args[2], args[3]);
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine(args[3] + " does not participate in call " + args[1] + " or call is in incorrect state");
        }
    }
}
