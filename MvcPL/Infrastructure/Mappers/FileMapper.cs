using System;
using BLL.Interface.Entities;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class FileMapper
    {
        

        public static FileViewModel ToMvcFileModel(this BllFile file, string userName = null)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            return new FileViewModel()
            {
                Id = file.Id,
                Name = file.Name,
                DataOfFile = file.DataOfFile,
                UserId = file.UserId,
                IsShared = file.IsShared,
                UrlLink = file.UrlLink,
                UserName = userName
            };
        }

        public static BllFile ToBllFile(this FileViewModel fileViewModel)
        {
            if (fileViewModel == null)
            {
                throw new ArgumentNullException("fileViewModel");
            }
            return new BllFile()
            {
                Id = fileViewModel.Id,
                Name = fileViewModel.Name,
                DataOfFile = fileViewModel.DataOfFile,
                UserId = fileViewModel.UserId,
                IsShared = fileViewModel.IsShared,
                UrlLink = fileViewModel.UrlLink
            };
        }
    }
}