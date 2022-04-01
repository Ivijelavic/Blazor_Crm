using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class Note
    {
        public string Message { get; }
        public string Icon { get; }

        public DateTimeOffset Created { get; }

        public DateTime EventTP { get; }
        public string Boja { get; }

        public Note(string message, string icon,DateTime Event,string boja )
        {
            Message = message;
            Icon = icon;
            Created = DateTimeOffset.UtcNow;
            this.EventTP = Event;
            this.Boja = boja;
        }
    }
}
