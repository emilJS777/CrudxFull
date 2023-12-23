using System;
using System.Text.Json.Serialization;
using CrudxApi.Src.File;

namespace CrudxApi.Src.Crud
{
    public class FieldViewModel
    {
        public string? Title { get; set; }
        public int? FieldTypeId { get; set; }
    }

    public class CrudViewModel
	{
		public string? Title { get; set; }
		public List<FieldViewModel> Fields { get; set; } = new List<FieldViewModel>();
		public int ProjectId { get; set; }
		public int CrudStaticId { get; set; }

        [JsonIgnore]
        public List<FileModel>? Files { get; set; }
    }
}

