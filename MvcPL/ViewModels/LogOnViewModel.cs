using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить пароль?")]
        public bool RememberMe { get; set; }
    }
}