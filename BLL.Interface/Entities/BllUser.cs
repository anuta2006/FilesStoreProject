using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BllUser : BllEntity
    {
        public BllUser()
        {
            Roles = new List<BllRole>();    
        }

        public string Login { get; set; }

        public string Password { get; set; }
        
        public ICollection<BllRole> Roles { get; set; } 
    }
}
