using System;
using CrudxApi.Src.File;
using CrudxApi.Src.Project;

namespace CrudxApi.Src.FileRedactor
{
	public interface IFileRedactorService
	{
        string GetFileText(string path, string fileName, string projectTitle);
		bool CreateCommand(string? path, string? commandLine, string? projectTitle);
		bool CreateFile(FileModel file, string projectTitle);
		bool CreateFile(List<FileModel> files, string projectTitle);
		bool DeleteFile(FileModel file, string projectTitle);
		bool DeleteFile(List<FileModel> files, string projectTitle);
		bool DeleteProjectDir(string projectTitle);
    }
}

