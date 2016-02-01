using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите другой пароль")]
        [StringLength(100, ErrorMessage = "Пароль должен быть не менее {2} символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }
}