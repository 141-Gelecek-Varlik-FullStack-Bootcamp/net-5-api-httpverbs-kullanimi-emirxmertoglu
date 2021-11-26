using System;
using System.ComponentModel.DataAnnotations;

namespace BasicUser.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanici adinizi giriniz!")]
        [StringLength(maximumLength:50, MinimumLength =3,ErrorMessage ="Kullanici adiniz min 3 ve max 50 karakterden olusabilir!")]
        public string UserName { get; set; }

        [MaxLength(100, ErrorMessage ="Adiniz max 100 karakter olabilir!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email adresinizi giriniz!")]
        [EmailAddress(ErrorMessage ="Gecerli bir mail adresi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sifrenizi giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tekrar sifrenizi giriniz!")]
        [Compare("Password", ErrorMessage ="Sifreleriniz Uyusmuyor!")]
        public string RePassword { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
