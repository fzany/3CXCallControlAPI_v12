using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;
using System.Threading;

namespace OMSamples.Samples
{
    [SampleCode("createbthelper")]
    [SampleParam("arg1", "dial code of blind transfer helper")]
    [SampleDescription("Creates dialcode and parking extension for blind transfer helper")]
    class CreateBlindTransferHelper : ISample
    {
        public void Run(params string[] args)
        {
            PhoneSystem ps = PhoneSystem.Root;
            Parameter p = ps.GetParameterByName("DIALCODEBTHELPER");
            if (p == null)
            {
                ps.GetTenants()[0].CreateParkExtension(args[1]).Save();
                p = ps.CreateParameter();
                p.Name = "DIALCODEBTHELPER";
                p.Value = args[1];
                p.Type = ParameterType.String;
                p.Description = "Dial code for Blind transfer helper";
                p.Save();
            }
            else
            {
                ParkExtension pe = ps.GetDNByNumber(p.Value) as ParkExtension;
                if (pe == null)
                {
                    ps.GetTenants()[0].CreateParkExtension(args[1]).Save();
                    p.Value = args[1];
                    p.Save();
                }
                else
                {
                    pe.Number = args[1];
                    pe.Save();
                    p.Value = args[1];
                    p.Save();
                }

            }
        }
    }
}
