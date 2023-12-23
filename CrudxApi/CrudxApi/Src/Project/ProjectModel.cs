using System;
using CrudxApi.Src.Technology;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudxApi.Src.Project
{
	public class ProjectModel
	{
        public int Id { get; set; }
        public string? Title { get; set; }

        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }

        public string? DbName { get; set; }
        public string? DbUser { get; set; }
        public string? DbPassword { get; set; }

        public TechnologyModel? Technology { get; set; }
        public string? Session { get; set; }
        public int Port { get; set; }
        public bool Launched { get; set; } = false;
    }
}
