using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ORM
{
    [Table("Role")]
    public class Role : Entity
    {
        #region Constructor
        public Role()
        {
            Users = new HashSet<User>();
        }
        #endregion

        #region Properties
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        #endregion
    }
}
