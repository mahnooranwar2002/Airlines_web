using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class admin
    {
        [Key]
        public int id { get; set; }
        public string admin_name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        public string admin_email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "the password must include the upper case,lower case and special latter")]
        public string admin_password { get; set; }

        [Required(ErrorMessage = "The comfirm password is required")]
        [Compare("user_password", ErrorMessage = "confirm password is not matched to password")]
        public string comfirm_password { get; set; }

        public int status { get; set; }
        public string admin_Image { get; set; }

        public string status_update { get; set; }
    }
}
