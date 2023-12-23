using System;
namespace CrudxApi.Src.Technology
{
	public interface ITechnologyRepository
	{
		void Create(TechnologyModel technology);
        void Update(TechnologyModel technology);
        void Delete(TechnologyModel technology);
        TechnologyModel? Get(int id);
        List<TechnologyModel> Get();
    }
}

