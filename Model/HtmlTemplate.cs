using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Model
{
    public class HtmlTemplate
    {
        [Key]
        public int id { get; set; }
        public string HtmlText { get; set; }
        public string TemplateName { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public string CreateBY { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public int Cypher { get; set; }
    }
}
