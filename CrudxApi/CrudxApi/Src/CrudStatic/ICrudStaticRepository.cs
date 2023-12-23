using System;
namespace CrudxApi.Src.CrudStatic
{
	public interface ICrudStaticRepository
	{
		void Create(CrudStaticModel crudStaticModel);
		void Update(CrudStaticModel crudStaticModel);
		void Delete(CrudStaticModel crudStaticModel);
		List<CrudStaticModel> GetByTechnologyId(int technologyId);
		CrudStaticModel? Get(int id);
	}
}

