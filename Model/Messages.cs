using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receivers { get; set; }
        public string CCReceivers { get; set; }
        public string BCCReceivers { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        //public string CreateBY { get; set; }
        public DateTime DateTimeOfUpdate { get; set; }
        public int MessageStatus_Id { get; set; }
        public int NumberOfFailures { get; set; }
        public int MessageType_Id { get; set; }
        public int MessageEventType_Id { get; set; }
        public int IdEvent { get; set; }
        public Guid Uid_Dokument { get; set; }
        public int id_Document { get; set; }
        public string ImePrezime { get; set; }

    }
}
