using System;
using AutoMapper;

namespace CrudxApi.Src.File
{
	public class FileService : IFileService
	{
		private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

		public FileService(IFileRepository fileRepository, IMapper mapper, IConfiguration configuration)
		{
			_fileRepository = fileRepository;
            _mapper = mapper;
            _configuration = configuration;
		}

        public bool? Create(FileViewModel fileViewModel)
        {
            _fileRepository.Create(_mapper.Map<FileModel>(fileViewModel));
            return true;
        }

        public bool? Update(int id, FileViewModel fileViewModel)
        {
            FileModel? file = _fileRepository.Get(id);
            if (file == null)
                return null;
            _fileRepository.Update(_mapper.Map(fileViewModel, file));
            return true;
        }

        public bool? Delete(int id)
        {
            FileModel? file = _fileRepository.Get(id);
            if (file == null)
                return null;
            _fileRepository.Delete(file);
            return true;
        }

        public FileModel? Get(int id)
        {
            FileModel? file = _fileRepository.Get(id);
            if (file == null)
                return null;
            return file;
        }

        public List<FileModel> Get()
        {
            List<FileModel> files = _fileRepository.Get();
            return files;
        }
    }
}

