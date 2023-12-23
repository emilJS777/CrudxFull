using System;
using AutoMapper;
using CrudxApi.Src.File;

namespace CrudxApi.Src.CrudStatic
{
	public class CrudStaticService : ICrudStaticService
	{
        private readonly ICrudStaticRepository _crudStaticRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
		public CrudStaticService(ICrudStaticRepository crudStaticRepository, IFileRepository fileRepository, IMapper mapper)
		{
            _crudStaticRepository = crudStaticRepository;
            _fileRepository = fileRepository;
            _mapper = mapper;
		}

        public bool? Create(CrudStaticViewModel crudStaticViewModel)
        {
            _crudStaticRepository.Create(_mapper.Map<CrudStaticModel>(crudStaticViewModel));
            return true;
        }

        public bool? Update(int id, CrudStaticViewModel crudStaticViewModel)
        {
            var crudStatic = _crudStaticRepository.Get(id);
            if (crudStatic == null)
                return null;
            _crudStaticRepository.Update(_mapper.Map(crudStaticViewModel, crudStatic));
            return true;
        }

        public bool? Delete(int id)
        {
            var crudStatic = _crudStaticRepository.Get(id);
            if (crudStatic == null)
                return null;
            _fileRepository.Delete(crudStatic.Files);
            _crudStaticRepository.Delete(crudStatic);
            return true;
        }

        public CrudStaticModel? Get(int id)
        {
            var crudStatic = _crudStaticRepository.Get(id);
            if (crudStatic == null)
                return null;
            return crudStatic;
        }

        public List<CrudStaticModel> GetList(int technologyId)
        {
            var crudStatics = _crudStaticRepository.GetByTechnologyId(technologyId);
            return crudStatics;
        }
    }
}

