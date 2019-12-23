using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCX.Configuration;

namespace OMSamples.Samples
{
    [SampleCode("dnproperty_save_delete")]
    [SampleWarning("modifies configuration of DN 100")]
    [SampleDescription("Shows how to modify(add) and delete DNProperty")]
    class DNPropertySaveDeleteSample : ISample
    {
        public void Run(params string[] args)
        {
            Extension a = PhoneSystem.Root.GetDNByNumber("100") as Extension;
            bool yesno = false;
            a.DeleteProperty("TESTPROP");
            a.Save();
            DNProperty c;
            for (; ; )
            {
                try
                {
                    c = a.GetPropertyByName("TESTPROP");
                    if (yesno && c == null
                        || (!yesno && c != null))
                    {
                        System.Console.WriteLine("Failed: expected - " + (yesno ? "doesn't exisit" : "exists"));
                        continue;
                    }
                    if (yesno)
                    {
                        a.DeleteProperty("TESTPROP");
                        a.Save();
                        yesno = false;
                    }
                    else
                    {
                        a.SetProperty("TESTPROP", "MyVal", PropertyType.String, "");
                        a.Save();
                        yesno = true;
                    }
                }
                catch
                {
                    System.Console.WriteLine("Failed: expected - " + (yesno ? "doesn't exisit" : "exists"));
                    a.Refresh();
                    c = a.GetPropertyByName("TESTPROP");
                    yesno = (c != null);
                }
            }
        }
    }
}