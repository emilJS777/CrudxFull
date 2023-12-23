using System;
using CrudxApi.Src.File;
using CrudxApi.Src.Technology;

namespace CrudxApi.Src.Project
{
	public interface IProjectRepository
	{
        ProjectModel Create(ProjectModel project);
        void Delete(ProjectModel project);
        ProjectModel? Get(int id);
        ProjectModel? GetByPort(int port);
        List<ProjectModel> Get();
    }
}

