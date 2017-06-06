using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace Radacode_OWIN
{
    class Program
    {
        static void Main(string[] args)
        {
            StartTopshelf();
        }

        static void StartTopshelf()
        {
            HostFactory.Run(x =>
            {
                x.Service<OwinServicervice>(s =>
                {
                    s.ConstructUsing(name => new OwinServicervice());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("!Radacode Windows Service");
                x.SetDisplayName("!OWIN Self Host");
                x.SetServiceName("!Radacode_Pisetskij");
            });
        }
    }
}
