using System;

namespace BLL.Interface.Entities
{
    public class BllFile : BllEntity
    {
        public string Name { get; set; }
       
        public string UrlLink { get; set; }
        
        public byte[] DataOfFile { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        public int? UserId { get; set; }
        
        public bool IsShared { get; set; }
    }
}
