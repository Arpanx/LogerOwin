using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwinSelfHost
{
    public class Logger
    {
        string[] hostname = { "google.com", "apple.com", "Microsoft.com" };
        public System.Timers.Timer timer1, timer2, timer3;
        object obj = new object();
        bool enabled = true;

        private void PrintToFileLog(String statusSite, String hostname)
        {
            using (StreamWriter writer = new StreamWriter("C:\\templog.txt", true))
            {
                writer.WriteLine(String.Format("time: {0}, status: {1}, hostname: {2}", DateTime.Now, statusSite, hostname));
                writer.Flush();
            }
        }

        private void ServiceTimer_Tick(string hostname)
        {
            try
            {
                lock (obj)
                {
                    // Create a request for the URL. 	
                    WebRequest request = WebRequest.Create("https://www." + hostname);
                    request.Method = "GET";
                    request.Timeout = 9000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    String statusSite = response.StatusDescription;
                    response.Close();
                    PrintToFileLog(statusSite, hostname);
                }
            }
            catch (Exception)
            {
                PrintToFileLog("Exception_Error", hostname);
            }
        }

        public Logger()
        {
            timer1 = new System.Timers.Timer();
            timer1.Interval = 4000;           // Every 2 minutes  or 4000 for test 4 sec
            timer1.AutoReset = true;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Elapsed += delegate { ServiceTimer_Tick(hostname[0]); };

            timer2 = new System.Timers.Timer();
            timer2.Interval = 300000;           // Every 5 minutes
            timer2.AutoReset = true;
            timer2.Enabled = true;
            timer2.Start();
            timer2.Elapsed += delegate { ServiceTimer_Tick(hostname[1]); };

            timer3 = new System.Timers.Timer(); // Every 2 dey in 22:15            
                                                // Figure how much time until 22:15
            DateTime now = DateTime.Now;
            DateTime fourOClock = DateTime.Today.AddHours(22.25);
            // If it's already past 22:15, wait until 22:15 tomorrow    
            if (now > fourOClock)
            {
                fourOClock = fourOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((fourOClock - now).TotalMilliseconds);
            // Set the timer to elapse only once, at 22:15.
            timer3.Interval = msUntilFour;
            timer3.AutoReset = true;
            timer3.Enabled = true;
            timer3.Start();
            timer3.Elapsed += delegate { ServiceTimer_Tick(hostname[3]); timer3.Interval = 172800000; }; // Every 2 dey in 22:15        

            using (StreamWriter writer = new StreamWriter("C:\\templog.txt", true))
            {
                writer.WriteLine(String.Format("Start...."));
                writer.Flush();
            }
        }



        public void Start()
        {
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            enabled = false;
        }
    }
}
