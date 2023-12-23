using System;
using CrudxApi.Src.File;
using Microsoft.EntityFrameworkCore;

namespace CrudxApi.Src.Crud
{
	public class CrudRepository : ICrudRepository
	{
        private readonly ApplicationDbContext _dbContext;
		public CrudRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public CrudModel Create(CrudModel crudModel)
        {
            _dbContext.Cruds.Add(crudModel);
            _dbContext.SaveChanges();
            return crudModel;
        }

        public void Delete(CrudModel crudModel)
        {
            _dbContext.Cruds.Remove(crudModel);
            _dbContext.SaveChanges();
        }

        public void Delete(List<CrudModel> crudModels)
        {
            _dbContext.Cruds.RemoveRange(crudModels);
            _dbContext.SaveChanges();
        }

        public CrudModel? Get(int id)
        {
            CrudModel? crud = _dbContext.Cruds.Include(c => c.Fields).Include(c => c.Files).FirstOrDefault(c => c.Id == id);
            return crud;
        }

        public List<CrudModel> GetByProjectId(int projectId)
        {
            List<CrudModel> cruds = _dbContext.Cruds.Include(c => c.Fields).Include(c => c.CrudStatic).Include(c => c.Files).Where(c => c.ProjectId == projectId).ToList();
            return cruds;
        }

        public void Update(CrudModel crudModel)
        {
            _dbContext.Cruds.Update(crudModel);
            _dbContext.SaveChanges();
        }
    }
}

