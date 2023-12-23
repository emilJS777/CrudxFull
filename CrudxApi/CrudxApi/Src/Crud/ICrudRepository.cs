using System;
namespace CrudxApi.Src.Crud
{
	public interface ICrudRepository
	{
		CrudModel Create(CrudModel crudModel);
		void Update(CrudModel crudModel);
		void Delete(CrudModel crudModel);
        void Delete(List<CrudModel> crudModels);
        CrudModel? Get(int id);
		List<CrudModel> GetByProjectId(int projectId);
	}
}

