using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IFileService : IService<BllFile>
    {
        IEnumerable<BllFile> GetShared(bool? isShared);

        BllFile GetByUrlLink(string url);

        IEnumerable<BllFile> Search(string name);
    }
}
