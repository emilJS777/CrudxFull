using System;
using System.ComponentModel.DataAnnotations.Schema;
using CrudxApi.Src.FieldType;
using CrudxApi.Src.File;

namespace CrudxApi.Src.CrudStatic
{
	public class CrudStaticModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? DynamicTitle { get; set; }
        public string? DynamicFieldTitle { get; set; }
        public string? DynamicFieldType { get; set; }
        public List<FieldTypeModel> FieldTypes { get; set; } = new List<FieldTypeModel>();
        public List<FileModel> Files { get; set; } = new List<FileModel>();
        public int TechnologyId { get; set; }
    }
}

