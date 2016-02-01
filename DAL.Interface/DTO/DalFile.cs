using System;

namespace DAL.Interface.DTO
{
    public class DalFile : DalEntity
    {
        public string Name { get; set; }

        public string UrlLink { get; set; }

        public byte[] DataOfFile { get; set; }

        public DateTime DateAdded { get; set; }

        public int? UserId { get; set; }

        public bool IsShared { get; set; }
    }
}
