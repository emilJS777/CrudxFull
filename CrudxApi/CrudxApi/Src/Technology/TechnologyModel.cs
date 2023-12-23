using System;
using System.ComponentModel.DataAnnotations.Schema;
using CrudxApi.Src.File;
using CrudxApi.Src.Project;

namespace CrudxApi.Src.Technology
{
	public class TechnologyModel
	{
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? DynamicTitle { get; set; }
        public string? DynamicDbName { get; set; }
        public string? DynamicDbUser { get; set; }
        public string? DynamicDbPassword { get; set; }
        public string? DynamicPort { get; set; }
        public string? RunDevCommandLine { get; set; }
        public string? StopDevCommandLine { get; set; }
        public string? DynamicSession { get; set; }

        //[InverseProperty("Technology")]
        public List<FileModel> Files { get; set; } = new List<FileModel>();
    }
}

