using System;

namespace ProjectHeyMobile.ViewModels
{
    public class UserAdvertisement
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

        //[Required(ErrorMessage = "View date is required")]
        ////[DisplayName("View Date")]
        //[DataType(DataType.Date)]
        //[Column(TypeName = "datetime2")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ViewDate { get; set; } = DateTime.Now;

        public bool IsClicked { get; set; } = false;

        public Report Report { get; set; }
    }
}
