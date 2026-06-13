using System.ComponentModel.DataAnnotations;
namespace APP_PRUEBA.Models
{
    
    public class LoginViewModel
    
        {
        [Required]
        [EmailAddress]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }
    }

}

