using System;
using AutoMapper;
using CrudxApi.Src.CrudStatic;
using CrudxApi.Src.File;
using CrudxApi.Src.FileRedactor;
using CrudxApi.Src.Project;
using CrudxApi.Src.Technology;

namespace CrudxApi.Src.Crud
{
	public class CrudService : ICrudService
	{
        private readonly ICrudRepository _crudRepository;
        private readonly ICrudStaticRepository _crudStaticRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IFileRedactorService _fileRedactorService;
        private readonly IMapper _mapper;
        public CrudService(ICrudRepository crudRepository, ICrudStaticRepository crudStaticRepository, IProjectRepository projectRepository, ITechnologyRepository technologyRepository, IFileRepository fileRepository, IFileRedactorService fileRedactorService, IMapper mapper)
		{
            _crudRepository = crudRepository;
            _crudStaticRepository = crudStaticRepository;
            _projectRepository = projectRepository;
            _technologyRepository = technologyRepository;
            _fileRepository = fileRepository;
            _fileRedactorService = fileRedactorService;
            _mapper = mapper;
		}

        private List<FileModel> RefactorFiles(List<FileModel> files, string dynamicTitle, string title, string dynamicFieldTitle, string dynamciFieldType, List<FieldModel> fields)
        {
            var changedFiles = new List<FileModel>();
            foreach (var file in files)
            {
                var newFile = new FileModel();
                newFile.FileName = file.FileName;
                newFile.Path = file.Path;
                newFile.CommandLine = file.CommandLine;
                newFile.Text = file.Text;

                // CHANGE DYNAMIC LINES
                if (file.DynamicManyLineStart != null && newFile.Text.Contains(file.DynamicManyLineStart))
                {
                    string[] lines = newFile.Text.Split('\n');
                    foreach(var line in lines)
                    {
                        int dynamicManyLineStartIndex = Array.FindIndex(lines, line => line.Contains(file.DynamicManyLineStart));
                        if(dynamicManyLineStartIndex != -1)
                        {
                            lines[dynamicManyLineStartIndex] = lines[dynamicManyLineStartIndex] + "\n" + file.DynamicLine;
                            break;
                        }
                    }
                    newFile.Text = string.Join("\n", lines);
                }

                // CHANGE FIELDS
                if (newFile.Text.Contains(dynamicFieldTitle))
                {

                    while (true)
                    {
                        int index = newFile.Text.IndexOf(dynamicFieldTitle);
                        if (index == -1)
                            break;

                        int lineStart = newFile.Text.LastIndexOf('\n', index) + 1;
                        int leadingSpacesCount = index - lineStart;

                        //string allFields = "";
                        foreach (var field in fields)
                        {
                            int fieldIndex = fields.IndexOf(field);
                            string[] lines = newFile.Text.Split('\n');

                            //allFields += field. + "\n" + new string(' ', leadingSpacesCount);
                            if (fieldIndex < fields.Count)
                            {
                                int dynamicFieldTitleLineIndex = Array.FindIndex(lines, line => line.Contains(dynamicFieldTitle));
                                string dynalicLine = lines[dynamicFieldTitleLineIndex];

                                lines[dynamicFieldTitleLineIndex] = lines[dynamicFieldTitleLineIndex].Replace(dynamicFieldTitle, field.Title);
                                lines[dynamicFieldTitleLineIndex] = lines[dynamicFieldTitleLineIndex].Replace(dynamciFieldType, field.FieldType.Type);

                                if (fieldIndex + 1 < fields.Count)
                                    lines[dynamicFieldTitleLineIndex] += "\n" + dynalicLine;
                            }
                            newFile.Text = string.Join("\n", lines);
                        }
                    }

                }

                // CHANGE Filename And Text TITLE
                string modifiedDynamicTitle = char.ToLower(dynamicTitle[0]) + dynamicTitle.Substring(1);
                string modifiedTitle = char.ToLower(title[0]) + title.Substring(1);
                if (newFile.Text.Contains(modifiedDynamicTitle))
                    newFile.Text = newFile.Text.Replace(modifiedDynamicTitle, modifiedTitle);

                if (newFile.Text.Contains(dynamicTitle))
                    newFile.Text = newFile.Text.Replace(dynamicTitle, title);

                if (newFile.FileName.Contains(dynamicTitle))
                    newFile.FileName = file.FileName.Replace(dynamicTitle, title);

                changedFiles.Add(newFile);
            }
            return changedFiles;
        }

        public bool? Create(CrudViewModel crudViewModel)
        {
            var crudStatic = _crudStaticRepository.Get(crudViewModel.CrudStaticId);
            var project = _projectRepository.Get(crudViewModel.ProjectId);
            var technology = _technologyRepository.Get(project.TechnologyId);
            if (crudStatic == null || project == null)
                return null;

            var crud = _crudRepository.Create(_mapper.Map<CrudModel>(crudViewModel));

            var FileList = new List<FileModel>();
            foreach (var file in technology.Files)
            {
                FileModel newFile = file;
                var fileText = _fileRedactorService.GetFileText(file.Path, file.FileName, project.Title);
                newFile.Text = fileText;
                FileList.Add(newFile);
            }
            var technologyFiles = RefactorFiles(FileList, crudStatic.DynamicTitle, crudViewModel.Title, crudStatic.DynamicFieldTitle, crudStatic.DynamicFieldType, crud.Fields);
            _fileRedactorService.CreateFile(technologyFiles, project.Title);

            var files = RefactorFiles(crudStatic.Files, crudStatic.DynamicTitle, crudViewModel.Title, crudStatic.DynamicFieldTitle, crudStatic.DynamicFieldType, crud.Fields);
            crud.Files = files;
            _crudRepository.Update(crud);
            _fileRedactorService.CreateFile(files, project.Title);

            
            return true;
        }

        public bool? Delete(int id)
        {
            var crud = _crudRepository.Get(id);
            var project = _projectRepository.Get(crud.ProjectId);
            if (crud == null)
                return null;

            _fileRepository.Delete(crud.Files);
            _crudRepository.Delete(crud);
            _fileRedactorService.DeleteFile(crud.Files, project.Title);
            return true;
        }

        public CrudModel? Get(int id)
        {
            var crud = _crudRepository.Get(id);
            if (crud == null)
                return null;
            return crud;
        }

        public List<CrudModel> GetList(int projectId)
        {
            var cruds = _crudRepository.GetByProjectId(projectId);
            return cruds;
        }

        public bool? Update(int id, CrudViewModel crudViewModel)
        {
            var crud = _crudRepository.Get(id);
            var crudStatic = _crudStaticRepository.Get(crudViewModel.CrudStaticId);
            var project = _projectRepository.Get(crudViewModel.ProjectId);
            var technology = _technologyRepository.Get(project.TechnologyId);

            if (crud == null || crudStatic == null || project == null)
                return null;

            
            _fileRedactorService.DeleteFile(crud.Files, project.Title);
            _fileRepository.Delete(crud.Files);
            var FileList = new List<FileModel>();
            foreach (var file in technology.Files)
            {
                var fileText = _fileRedactorService.GetFileText(file.Path, file.FileName, project.Title);
                FileModel newFile = file;
                newFile.Text = fileText;
                FileList.Add(newFile);
            }
            var technologyFiles = RefactorFiles(FileList, crudStatic.DynamicTitle, crudViewModel.Title, crudStatic.DynamicFieldTitle, crudStatic.DynamicFieldType, crud.Fields);
            _fileRedactorService.CreateFile(technologyFiles, project.Title);
            //_crudRepository.Delete(crud);
            var files = RefactorFiles(crudStatic.Files, crudStatic.DynamicTitle, crudViewModel.Title, crudStatic.DynamicFieldTitle, crudStatic.DynamicFieldType, crud.Fields);
            crudViewModel.Files = files;
            _crudRepository.Update(_mapper.Map(crudViewModel, crud));
            _fileRedactorService.CreateFile(files, project.Title);

            
            return true;
        }
    }
}

