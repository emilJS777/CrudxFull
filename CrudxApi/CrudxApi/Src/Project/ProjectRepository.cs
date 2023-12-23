using System;
using CrudxApi.Src.File;
using Microsoft.EntityFrameworkCore;

namespace CrudxApi.Src.Project
{
	public class ProjectRepository : IProjectRepository
	{
        private readonly ApplicationDbContext _dbContext;
        public ProjectRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ProjectModel Create(ProjectModel project)
        {
            var newProject = _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return newProject.Entity;
        }

        public void Delete(ProjectModel project)
        {
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
        }

        public ProjectModel? Get(int id)
        {
            ProjectModel? project = _dbContext.Projects.Include(p => p.Technology).FirstOrDefault(p => p.Id == id);
            return project;
        }

        public ProjectModel? GetByPort(int port)
        {
            ProjectModel? project = _dbContext.Projects.FirstOrDefault(p => p.Port == port);
            return project;
        }

        public List<ProjectModel> Get()
        {
            List<ProjectModel> projects = _dbContext.Projects.Include(p => p.Technology).ToList();
            return projects;
        }
    }
}

