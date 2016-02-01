using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : DalEntity
    {
        public DalUser()
        {
            Roles = new List<DalRole>();
        }

        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<DalRole> Roles { get; set; }
    }
}
