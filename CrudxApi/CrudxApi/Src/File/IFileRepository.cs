using System;
namespace CrudxApi.Src.File
{
	public interface IFileRepository
	{
		void Create(FileModel file);
        void Create(List<FileModel> files);
        void Update(FileModel file);
        void Delete(FileModel file);
        void Delete(List<FileModel> files);
        FileModel? Get(int id);
        List<FileModel> Get();
    }
}

