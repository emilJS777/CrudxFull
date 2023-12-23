using System;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CrudxApi.Src.Technology
{
    public interface ITechnologyService
	{
        bool? Create(TechnologyViewModel technologyViewModel);
        bool? Update(int id, TechnologyViewModel technologyViewModel);
        bool? Delete(int id);
        TechnologyModel? Get(int id);
        List<TechnologyModel> Get();
    }
}

