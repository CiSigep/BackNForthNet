using BackNForthNet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BackNForthNet.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MessageReceive()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Message));

            Message msg = (Message)json.ReadObject(Request.InputStream);
            Messages.msgs.Add(msg);

            return Content("true", "application/json");
        }

        [HttpPost]
        public ActionResult MessageSend()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Message));

            byte[] data = System.Text.Encoding.UTF8.GetBytes(Request["data"]);
            
            Message msg = (Message) json.ReadObject(new MemoryStream(data));


            // code to send to java server
            WebRequest req = WebRequest.Create("http://localhost:7001/BacknForth/api/messageReceive");
            req.Method = "POST";
            req.ContentType = "application/json";
            Stream stm = req.GetRequestStream();

            stm.Write(data, 0, data.Length);
            stm.Close();

            WebResponse resp = req.GetResponse();
            Messages.msgs.Add(msg);

            return Content("OK");
        }

        [HttpGet]
        public ActionResult MessageQueue()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Message>));


            MemoryStream stm = new MemoryStream();
            json.WriteObject(stm, Messages.msgs);
            Messages.msgs.Clear();
            stm.Position = 0;

            return Content("data:" + new StreamReader(stm).ReadToEnd() + "\n\n", "text/event-stream");
            
        }
    }
}