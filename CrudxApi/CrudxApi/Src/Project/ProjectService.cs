using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using AutoMapper;
using CrudxApi.Src.Crud;
using CrudxApi.Src.File;
using CrudxApi.Src.FileRedactor;
using CrudxApi.Src.Technology;

namespace CrudxApi.Src.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly ICrudRepository _crudRepository;
        private readonly IFileRedactorService _fileRedactorService;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, ITechnologyRepository technologyRepository, ICrudRepository crudRepository, IFileRedactorService fileRedactorService, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _technologyRepository = technologyRepository;
            _fileRedactorService = fileRedactorService;
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        private bool CheckLaunchedProject(int port)
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
                    return false;
                }
                catch (SocketException)
                {
                    return true;
                }
            }
        }

        private List<FileModel> RefactorTechnologyFiles(List<FileModel> files, List<string> dynamicTitleList, List<string> titleList)
        {
            var changedFiles = new List<FileModel>();
            foreach (var file in files)
            {
                var newFile = new FileModel();
                newFile.FileName = file.FileName;
                newFile.Path = file.Path;
                newFile.CommandLine = file.CommandLine;
                newFile.Text = file.Text;

                foreach (var dynamicTitle in dynamicTitleList)
                {
                    int index = dynamicTitleList.IndexOf(dynamicTitle);
                    if (dynamicTitleList[index] != "" && file.Text.Contains(dynamicTitleList[index]))
                    {
                        newFile.Text = newFile.Text.Replace(dynamicTitleList[index], titleList[index]);
                    }
                    if (dynamicTitleList[index] != "" && file.Path.Contains(dynamicTitleList[index]))
                    {
                        newFile.Path = newFile.Path.Replace(dynamicTitleList[index], titleList[index]);
                    }
                    if (dynamicTitleList[index] != "" && file.CommandLine.Contains(dynamicTitleList[index]))
                    {
                        newFile.CommandLine = newFile.CommandLine.Replace(dynamicTitleList[index], titleList[index]);
                    }
                }
                changedFiles.Add(newFile);
            }
            return changedFiles;
        }

        public bool? OnLaunch(int projectId)
        {
            var project = _projectRepository.Get(projectId);
            if (project == null)
                return null;

            if (CheckLaunchedProject(project.Port) == false)
            {
                string runCommand = project.Technology.RunDevCommandLine.Replace(project.Technology.DynamicPort, project.Port.ToString());
                runCommand = runCommand.Replace(project.Technology.DynamicSession, project.Session);
                if(project.Technology.DynamicTitle != "")
                    runCommand = runCommand.Replace(project.Technology.DynamicTitle, project.Title);

                _fileRedactorService.CreateCommand("", runCommand, project.Title);
                return true;
            }
            string stopCommand = project.Technology.StopDevCommandLine.Replace(project.Technology.DynamicPort, project.Port.ToString());
            if (project.Technology.DynamicTitle != "")
                stopCommand = stopCommand.Replace(project.Technology.DynamicTitle, project.Title);
            _fileRedactorService.CreateCommand("", stopCommand, project.Title);
            return false;
        }

        public bool? Create(ProjectViewModel projectViewModel)
        {
            // Generated unique port
            while (true)
            {
                projectViewModel.Port = new Random().Next(1024, 65536);
                if (_projectRepository.GetByPort(projectViewModel.Port) == null)
                    break;
                continue;
            }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            StringBuilder result = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                int randomIndex = random.Next(chars.Length);
                result.Append(chars[randomIndex]);
            }

            projectViewModel.Session = result.ToString();
            var project = _projectRepository.Create(_mapper.Map<ProjectModel>(projectViewModel));
            var technology = _technologyRepository.Get(project.TechnologyId);

            _fileRedactorService.CreateFile(RefactorTechnologyFiles(technology.Files,
                new List<string> {technology.DynamicTitle, technology.DynamicDbUser, technology.DynamicDbPassword, technology.DynamicDbName,},
                new List<string> {project.Title, project.DbUser, project.DbPassword, project.DbName }),
                project.Title, technology.DynamicTitle);

            return true;
        }

        public bool? Delete(int id)
        {
            ProjectModel? project = _projectRepository.Get(id);
            if (project == null)
                return null;

            var cruds = _crudRepository.GetByProjectId(project.Id);
            //foreach (var crud in cruds)
            //    _fileRepository.Delete(crud.Files.ToList());
            _crudRepository.Delete(cruds);
            _projectRepository.Delete(project);

            var technology = _technologyRepository.Get(project.TechnologyId);
            _fileRedactorService.DeleteProjectDir(project.Title);
            return true;
        }

        public ProjectModel? Get(int id)
        {
            ProjectModel? project = _projectRepository.Get(id);
            if (project == null)
                return null;

            project.Launched = CheckLaunchedProject(project.Port);

            return project;
        }

        public List<ProjectModel> Get()
        {
            List<ProjectModel> projects = _projectRepository.Get();

            foreach (var project in projects)
            {
                project.Launched = CheckLaunchedProject(project.Port);
            }
            return projects;
        }
    }
}

