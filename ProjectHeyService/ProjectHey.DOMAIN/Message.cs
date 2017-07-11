using System;

namespace ProjectHey.DOMAIN
{
    public class Message
    {
        public int Id { get; set; }

        public string Body { get; set; }

        //[Required(ErrorMessage = "Creation date is required")]
        ////[DisplayName("Creation Date")]
        //[DataType(DataType.Date)]
        //[Column(TypeName = "datetime2")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserSenderId { get; set; }
        public User UserSender { get; set; }

        public int UserReceiverId { get; set; }
        public User UserReceiver { get; set; }

    }
}
