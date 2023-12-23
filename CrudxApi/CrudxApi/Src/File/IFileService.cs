using System;

namespace CrudxApi.Src.File
{
	public interface IFileService
	{
		bool? Create(FileViewModel fileViewModel);
        bool? Update(int id, FileViewModel fileViewModel);
        bool? Delete(int id);
        FileModel? Get(int id);
        List<FileModel> Get();
    }
}

