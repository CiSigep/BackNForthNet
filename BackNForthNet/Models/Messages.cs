using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackNForthNet.Models
{
    public static class Messages
    {
        public static List<Message> msgs;

        static Messages()
        {
            msgs = new List<Message>();
        }
    }
}