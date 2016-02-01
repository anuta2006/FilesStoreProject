using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class FileRepository : Repository<DalFile, File>, IFileRepository
    {
        #region Constructor
        public FileRepository(DbContext context) 
            : base(context) { }
        #endregion

        #region Methods

        #region Public
        public IEnumerable<DalFile> GetShared(bool isShared)
        {
            var files = context.Set<File>()
                .Where(item => item.IsShared == isShared).ToList();

            return files.Select(MapToDalEntity);
        }

        public DalFile GetByUrlLink(string urlLink)
        {
            if (urlLink == null)
            {
                throw new ArgumentNullException("urlLink");
            }
            var file = context.Set<File>().FirstOrDefault(f => f.UrlLink == urlLink);
            return file == null ? null : MapToDalEntity(file);
        }

        public IEnumerable<DalFile> Search(string name = "")
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            
            var files = context.Set<File>()
                .Where(item => item.Name.Contains(name)).ToList();

            return files.Select(MapToDalEntity);
        }

        #endregion

        #region Protected
        protected override DalFile MapToDalEntity(File entity)
        {
            return entity.ToDalFile();
        }

        protected override File MapToEntity(DalFile dalEntity)
        {
            return dalEntity.ToFile();
        }

        protected override void CopyEntityFields(DalFile source, File target)
        {
            source.CopyFieldsTo(target);
        }
        #endregion
        #endregion
    }
}
