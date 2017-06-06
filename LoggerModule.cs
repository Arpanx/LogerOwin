using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OwinSelfHost
{
    public class LoggerModule
    {
        private readonly AppFunc _next;        
        private Logger _logger;

        public LoggerModule(AppFunc next )
        {
            if (next == null)
                throw new ArgumentNullException("next");
            this._next = next;           
            _logger = new Logger();
        }

        public Task Invoke(IDictionary<string, object> env)
        {
           return this._next(env);
        }
        
       
    }
}
