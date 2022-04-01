using System.ComponentModel.DataAnnotations;

namespace CrmExpert.Model
{
    public class EmailModel
    {
		[Required]
		public int Id { get; set; }
		[EmailAddress]
		public string Sender { get; set; }
		[EmailAddress]
		public string Receivers { get; set; }
		[EmailAddress]
		public string CCReceivers { get; set; }
		[Required]
		public int IdEventType { get; set; }
		[Required]
		public int MessageType_Id { get; set; }
	}
}
