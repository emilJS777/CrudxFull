using System;
using CrudxApi.Src.File;

namespace CrudxApi.Src.Technology
{
	public class TechnologyViewModel
	{
        public string? Title { get; set; }
        public string? DynamicTitle { get; set; }
        public string? DynamicDbName { get; set; }
        public string? DynamicDbUser { get; set; }
        public string? DynamicDbPassword { get; set; }
        public string? DynamicPort { get; set; }
        public string? RunDevCommandLine { get; set; }
        public string? StopDevCommandLine { get; set; }
        public string? DynamicSession { get; set; }

        public List<FileViewModel>? Files { get; set; }
    }
}

