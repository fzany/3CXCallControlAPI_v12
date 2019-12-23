using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("delete_current_profile")]
    [SampleWarning("This sample damages configuration of extension 112. 112 should be deleted and recreated again after runing this sample")]
    [SampleDescription("Requires existing extension 112. Removes profile which is currently seleted in extension configuration")]
    class DeleteCurrentProfileSample : ISample
    {
        public void Run(params string[] args)
        {
            Extension ext = PhoneSystem.Root.GetDNByNumber("112") as Extension;
            FwdProfile fp = ext.CurrentProfile;
            if (fp != null)
            {
                fp.Delete();
            }
        }
    }
}