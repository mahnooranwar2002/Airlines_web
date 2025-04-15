using System.ComponentModel.DataAnnotations;

namespace Airlines_Booking.Models
{
    public class user
    {
        [Key]
        
        public int id { get; set; }

        [Required(ErrorMessage ="The name is required")]
        [StringLength(15,MinimumLength =3)]
       
        public string user_name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        public string user_email { get; set; }

        [Required(ErrorMessage ="The password is required")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$",ErrorMessage ="the password must include the upper case,lower case and special latter")]
        public string user_password { get; set; }

        [Required(ErrorMessage ="The comfirm password is required")]
        [Compare("user_password",ErrorMessage ="confirm password is not matched to password")]
        public string comfirm_password { get; set; }

        public int status { get; set; }

        public string status_update { get; set; }

    }
}
