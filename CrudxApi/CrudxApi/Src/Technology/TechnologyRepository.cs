using System;
using Microsoft.EntityFrameworkCore;

namespace CrudxApi.Src.Technology
{
	public class TechnologyRepository : ITechnologyRepository
	{
        private readonly ApplicationDbContext _dbContext;
        public TechnologyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TechnologyModel technology)
        {
            _dbContext.Technologies.Add(technology);
            _dbContext.SaveChanges();
        }

        public void Update(TechnologyModel technology)
        {
            _dbContext.Technologies.Update(technology);
            _dbContext.SaveChanges();
        }

        public void Delete(TechnologyModel technology)
        {
            _dbContext.Technologies.Remove(technology);
            _dbContext.SaveChanges();
        }

        public TechnologyModel? Get(int id)
        {
           TechnologyModel? technology = _dbContext.Technologies.Include(t => t.Files).FirstOrDefault(t => t.Id == id);
           return technology; 
        }
    
        public List<TechnologyModel> Get()
        {
            List<TechnologyModel> technologies = _dbContext.Technologies.ToList();
            return technologies;
        }
    }
}

