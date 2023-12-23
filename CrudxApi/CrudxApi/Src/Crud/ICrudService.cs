using System;
namespace CrudxApi.Src.Crud
{
	public interface ICrudService
	{
		bool? Create(CrudViewModel crudViewModel);
        bool? Update(int id, CrudViewModel crudViewModel);
        bool? Delete(int id);
        CrudModel? Get(int id);
        List<CrudModel> GetList(int projectId);
    }
}

