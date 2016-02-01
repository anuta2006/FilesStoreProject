using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class FileService : Service<BllFile, DalFile>, IFileService
    {
        #region Constructor
        public FileService(IUnitOfWork uow, IFileRepository repository)
            : base(uow, repository) { }
        #endregion

        #region Methods
        #region Public
        public override void Create(BllFile entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.UrlLink = string.Format("_{0}", entity.GetHashCode().ToString()); 

            base.Create(entity);
        }

        public IEnumerable<BllFile> GetShared(bool? isShared)
        {
            if (isShared == null)
            {
                throw new ArgumentNullException("isShared");
            }
            var files = ((IFileRepository) repository).GetShared(isShared.Value);
            return files == null ? null : files.Select(MapToBllEntity);
        }

        public BllFile GetByUrlLink(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            var file = ((IFileRepository) repository).GetByUrlLink(url);
            return file == null ? null : MapToBllEntity(file);
        }

        public IEnumerable<BllFile> Search(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            var files = ((IFileRepository) repository).Search(name);
            return files == null ? null : files.Select(MapToBllEntity);
        }
        #endregion

        #region Protected
        protected override DalFile MapToDalEntity(BllFile entity)
        {
            return entity.ToDalFile();
        }

        protected override BllFile MapToBllEntity(DalFile entity)
        {
            return entity.ToBllFile();
        }
        #endregion
        #endregion
    }
}
