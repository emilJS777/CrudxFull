using System;
using CrudxApi.Src.File;

namespace CrudxApi.Src.Project
{
	public interface IProjectService
	{
        bool? OnLaunch(int projectId);
        bool? Create(ProjectViewModel projectViewModel);
        bool? Delete(int id);
        ProjectModel? Get(int id);
        List<ProjectModel> Get();
    }
}

