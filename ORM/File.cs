using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("File")]
    public class File : Entity
    {
        #region Constructor

        public File()
        {
            DateAdded = DateTime.Now;
        }
        #endregion

        #region Properties
        [Required]
        public string Name { get; set; }

        [Required]
        public string UrlLink { get; set; }

        [Required]
        public byte[] DataOfFile { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public bool IsShared { get; set; }
        #endregion
    }
}
