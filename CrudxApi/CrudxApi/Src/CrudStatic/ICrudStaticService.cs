using System;
namespace CrudxApi.Src.CrudStatic
{
	public interface ICrudStaticService
	{
		bool? Create(CrudStaticViewModel crudStaticViewModel);
        bool? Update(int id, CrudStaticViewModel crudStaticViewModel);
        bool? Delete(int id);
        CrudStaticModel? Get(int id);
        List<CrudStaticModel> GetList(int technologyId);
    }
}

