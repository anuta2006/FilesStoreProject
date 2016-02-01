using System;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalFileMapper
    {
        public static DalFile ToDalFile(this File file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            return new DalFile()
            {
                Id = file.Id,
                DateAdded = file.DateAdded,
                DataOfFile = file.DataOfFile,
                Name = file.Name,
                IsShared = file.IsShared,
                UrlLink = file.UrlLink,
                UserId = file.UserId
            };
        }

        public static File ToFile(this DalFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            return new File()
            {
                Id = file.Id,
                DateAdded = file.DateAdded,
                Name = file.Name,
                IsShared = file.IsShared,
                UrlLink = file.UrlLink,
                UserId = file.UserId,
                DataOfFile = file.DataOfFile
            };
        }

        public static void CopyFieldsTo(this DalFile source, File target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            target.Name = source.Name;
            target.IsShared = source.IsShared;
        }
    }
}
