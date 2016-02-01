using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя роли  ")]
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Name { get; set; }
    }
}