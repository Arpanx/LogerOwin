using System;
using Microsoft.Owin.Hosting;
using System.Net;
using System.IO;
using System.Threading;

namespace Radacode_OWIN
{
    public class OwinServicervice
    {
        private IDisposable _webapp;

        public void Start()
        {
            _webapp = WebApp.Start<Startup>("http://localhost:8080");
         
        }

        public void Stop()
        {           
            _webapp?.Dispose();
        }  
    }
   
}
