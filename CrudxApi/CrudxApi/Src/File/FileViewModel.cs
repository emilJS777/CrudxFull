using System;
using System.Text.Json.Serialization;

namespace CrudxApi.Src.File
{
	public class FileViewModel
	{
        public string? Path { get; set; }
        public string? FileName { get; set; }
        public string? Text { get; set; }
        public string? CommandLine { get; set; }
        public string? DynamicManyLineStart { get; set; }
        public string? DynamicLine { get; set; }

        [JsonIgnore]
        public int? TechnologyId { get; set; }

        [JsonIgnore]
        public int? CrudStaticId { get; set; }

        [JsonIgnore]
        public int? CrudId { get; set; }
    }
}

