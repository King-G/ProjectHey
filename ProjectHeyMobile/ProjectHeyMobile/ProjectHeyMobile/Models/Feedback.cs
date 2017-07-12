using ProjectHeyMobile.Models.Enums;
using System;

namespace ProjectHeyMobile.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public string Message { get; set; }

        //[Required(ErrorMessage = "Creation date is required")]
        ////[DisplayName("Creation Date")]
        //[DataType(DataType.Date)]
        //[Column(TypeName = "datetime2")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
