using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lynes.ReportsServer.Core
{
    internal class HttpServer
    {
        private HttpListener m_listener;
        
        public HttpServer()
        {
            m_listener = new HttpListener();
        }

        public async void Start()
        {
            m_listener.Start();
            HttpListenerContext context = await m_listener.GetContextAsync();
            if (context != null)
            {
                HttpListenerRequest request = context.Request;
                
            }
        }

        public void Stop()
        {
            m_listener.Stop();
            m_listener.Close();
        }
    }

}
