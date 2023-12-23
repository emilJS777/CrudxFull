using System;
using System.Diagnostics;
using System.IO;
using CrudxApi.Src.File;
using static System.Net.WebRequestMethods;

namespace CrudxApi.Src.FileRedactor
{
	public class FileRedactorService : IFileRedactorService
	{
        private readonly IConfiguration _configuration;
		public FileRedactorService(IConfiguration configuration)
		{
            _configuration = configuration;
		}


        public string GetFileText(string path, string fileName, string projectTitle)
        {
            var content = System.IO.File.ReadAllText(_configuration["ProjectsDirPath"] + '/' + projectTitle + '/' + path + '/' + fileName);
            return content;
        }

        public bool CreateCommand(string? path, string? commandLine, string projectTitle)
        {

            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            StreamWriter streamWriter = process.StandardInput;
            StreamReader streamReader = process.StandardOutput;

            streamWriter.WriteLine("cd " + _configuration["ProjectsDirPath"] + '/' + projectTitle + " && " + commandLine);
            streamWriter.Close();

            string output = streamReader.ReadToEnd();

            process.WaitForExit();
            process.Close();
            return true;
        }
         
        public bool CreateFile(FileModel file, string projectTitle)
        {
            Directory.CreateDirectory(_configuration["ProjectsDirPath"] + '/' + projectTitle + '/' + file.Path);
            if(file.FileName != "" && file.Text != "")
                System.IO.File.WriteAllText(_configuration["ProjectsDirPath"] + '/' + projectTitle + '/' + file.Path + '/' + file.FileName, file.Text);
            CreateCommand(file.Path, file.CommandLine, projectTitle);
            return true;
        }

        public bool CreateFile(List<FileModel> files, string projectTitle)
        {
            foreach (var file in files)
                CreateFile(file, projectTitle);
            return true;
        }

        public bool DeleteFile(FileModel file, string title)
        {
            try
            {
                System.IO.File.Delete(_configuration["ProjectsDirPath"] + '/' + title + '/' + file.Path + '/' + file.FileName);
            }
            catch
            {
                return true;
            }
            return true;
        }

        public bool DeleteFile(List<FileModel> files, string title)
        {
            foreach (var file in files)
                DeleteFile(file, title);
            return true;
        }

        public bool DeleteProjectDir(string title)
        {
            try
            {
                string directoryPath = Path.Combine(_configuration["ProjectsDirPath"], title);
                Directory.Delete(directoryPath, true);
            }
            
            catch
            {
                return true;
            }
            return true;
        }
    }
}

