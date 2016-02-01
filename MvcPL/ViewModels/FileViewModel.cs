using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Display(Name = "Имя файла: ")]
        public string Name { get; set; }

        [Display(Name = "URL: ")]
        public string UrlLink { get; set; }

        public byte[] DataOfFile { get; set; }

        public int? UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Доступ: ")]
        public bool IsShared { get; set; }
    }
}