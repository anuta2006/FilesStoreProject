using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("User")]
    public class User : Entity
    {
        #region Constructor
        public User()
        {
            Roles = new HashSet<Role>();
        }
        #endregion

        #region Properties
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public virtual ICollection<Role> Roles { get; set; }
        #endregion
    }
}
