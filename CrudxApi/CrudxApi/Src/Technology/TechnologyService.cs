using System;
using AutoMapper;
using CrudxApi.Src.FileRedactor;
using CrudxApi.Src.File;

namespace CrudxApi.Src.Technology
{
	public class TechnologyService : ITechnologyService
	{
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IFileRedactorService _fileRedactorService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TechnologyService(ITechnologyRepository technologyRepository, IFileRepository fileRepository, IFileRedactorService fileRedactorService, IMapper mapper, IConfiguration configuration)
		{
            _technologyRepository = technologyRepository;
            _fileRepository = fileRepository;
            _fileRedactorService = fileRedactorService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public bool? Create(TechnologyViewModel technologyViewModel)
        {
            //_fileRedactorService.CreateFile(_mapper.Map<TechnologyModel>(technologyViewModel).Files, technologyViewModel.Title);
            _technologyRepository.Create(_mapper.Map<TechnologyModel>(technologyViewModel));
            return true;
        }

        public bool? Update(int id, TechnologyViewModel technologyViewModel)
        {
            TechnologyModel? technology = _technologyRepository.Get(id);
            if (technology == null)
                return null;

            _technologyRepository.Update(_mapper.Map(technologyViewModel, technology));
            //_fileRedactorService.DeleteFile(_mapper.Map<TechnologyModel>(technologyViewModel).Files, technologyViewModel.Title);
            //_fileRedactorService.CreateFile(_mapper.Map<TechnologyModel>(technologyViewModel).Files, technologyViewModel.Title);
            return true;
        }

        public bool? Delete(int id)
        {
            TechnologyModel? technology = _technologyRepository.Get(id);
            if (technology == null)
                return null;

            _fileRepository.Delete(technology.Files);
            _technologyRepository.Delete(technology);
            //_fileRedactorService.DeleteFile(technology.Files, technology.Title);
            return true;
        }

        public TechnologyModel? Get(int id)
        {
            TechnologyModel? technology = _technologyRepository.Get(id);
            if (technology == null)
                return null;
            return technology;
        }

        public List<TechnologyModel> Get()
        {
            List<TechnologyModel> technologies = _technologyRepository.Get();
            return technologies;
        }
    }
}

