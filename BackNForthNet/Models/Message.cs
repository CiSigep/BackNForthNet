using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BackNForthNet.Models
{
    [DataContract]
    public class Message
    {
        [DataMember]
        private String sender;
        [DataMember]
        private String message;

        public void setSender(String sender)
        {
            this.sender = sender; 
        }

        public String getSender()
        {
            return this.sender;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }

        public String getMessage()
        {
            return this.message;
        }
    }
}