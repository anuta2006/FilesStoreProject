using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
       
        [Display(Name = "Логин")]
        public string Login { get; set; }
       
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        [Display(Name = "Роли пользователя")]
        public ICollection<string> RoleNames { get; set; } 
    }
}