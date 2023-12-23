using System;
using Microsoft.EntityFrameworkCore;

namespace CrudxApi.Src.CrudStatic
{
	public class CrudStaticRepository : ICrudStaticRepository
	{
        private readonly ApplicationDbContext _dbContext;
		public CrudStaticRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public void Create(CrudStaticModel crudStaticModel)
        {
            _dbContext.CrudStatics.Add(crudStaticModel);
            _dbContext.SaveChanges();
        }

        public void Delete(CrudStaticModel crudStaticModel)
        {
            _dbContext.CrudStatics.Remove(crudStaticModel);
            _dbContext.SaveChanges();
        }

        public List<CrudStaticModel> GetByTechnologyId(int technologyId)
        {
            List<CrudStaticModel> crudStatics = _dbContext.CrudStatics.Include(c => c.FieldTypes).Include(c => c.Files).Where(c => c.TechnologyId == technologyId).ToList();
            return crudStatics;
        }

        public CrudStaticModel? Get(int id)
        {
            CrudStaticModel? crudStatic = _dbContext.CrudStatics.Include(c => c.FieldTypes).Include(c => c.Files).FirstOrDefault(c => c.Id == id);
            return crudStatic;
        }

        public void Update(CrudStaticModel crudStaticModel)
        {
            _dbContext.CrudStatics.Update(crudStaticModel);
            _dbContext.SaveChanges();
        }
    }
}

