using System;
using System.Text.Json.Serialization;

namespace CrudxApi.Src.Project
{
	public class ProjectViewModel
	{
		public string? Title { get; set; }
        public int TechnologyId { get; set; }
        public string? DbName { get; set; }
        public string? DbUser { get; set; }
        public string? DbPassword { get; set; }

        [JsonIgnore]
        public string? Session { get; set; }
        [JsonIgnore]
        public int Port { get; set; }
    }
}

