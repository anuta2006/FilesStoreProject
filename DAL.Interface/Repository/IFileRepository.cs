using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IFileRepository : IRepository<DalFile>
    {
        IEnumerable<DalFile> GetShared(bool isShared);

        DalFile GetByUrlLink(string urlLink);

        IEnumerable<DalFile> Search(string name);
    }
}
