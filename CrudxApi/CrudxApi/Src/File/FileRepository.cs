using System;
using CrudxApi.Src.Technology;
using Microsoft.EntityFrameworkCore;

namespace CrudxApi.Src.File
{
	public class FileRepository : IFileRepository
	{
        private readonly ApplicationDbContext _dbContext;
		public FileRepository(ApplicationDbContext dbContext)
		{
            this._dbContext = dbContext;
		}

        public void Create(FileModel file)
        {
            _dbContext.Files.Add(file);
            _dbContext.SaveChanges();
        }

        public void Create(List<FileModel> files)
        {
            _dbContext.Files.AddRange(files);
            _dbContext.SaveChanges();
        }

        public void Update(FileModel file)
        {
            _dbContext.Files.Update(file);
            _dbContext.SaveChanges();
        }

        public void Delete(FileModel file)
        {
            _dbContext.Files.Remove(file);
            _dbContext.SaveChanges();
        }

        public void Delete(List<FileModel> files)
        {
            _dbContext.Files.RemoveRange(files);
            _dbContext.SaveChanges();
        }

        public FileModel? Get(int id)
        {
            FileModel? file = _dbContext.Files.FirstOrDefault(f => f.Id == id);
            return file;
        }

        public List<FileModel> Get()
        {
            List<FileModel> files = _dbContext.Files.ToList();
            return files;
        }
    }
}

