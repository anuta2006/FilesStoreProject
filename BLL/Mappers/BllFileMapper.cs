using System;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllFileMapper
    {
        public static BllFile ToBllFile(this DalFile dalFile)
        {
            if (dalFile == null)
            {
                throw new ArgumentNullException("dalFile");
            }
            return new BllFile()
            {
                Id = dalFile.Id,
                DateAdded = dalFile.DateAdded,
                DataOfFile = dalFile.DataOfFile,
                Name = dalFile.Name,
                IsShared = dalFile.IsShared,
                UrlLink = dalFile.UrlLink,
                UserId = dalFile.UserId
            };
        }

        public static DalFile ToDalFile(this BllFile bllFile)
        {
            if (bllFile == null)
            {
                throw new ArgumentNullException("bllFile");
            }
            return new DalFile()
            {
                Id = bllFile.Id,
                DateAdded = bllFile.DateAdded,
                DataOfFile = bllFile.DataOfFile,
                Name = bllFile.Name,
                IsShared = bllFile.IsShared,
                UrlLink = bllFile.UrlLink,
                UserId = bllFile.UserId
            };
        }
    }
}
