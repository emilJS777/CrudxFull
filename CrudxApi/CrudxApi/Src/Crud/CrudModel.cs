using System;
using System.ComponentModel.DataAnnotations.Schema;
using CrudxApi.Src.CrudStatic;
using CrudxApi.Src.FieldType;
using CrudxApi.Src.File;
using CrudxApi.Src.Project;

namespace CrudxApi.Src.Crud
{
	public class FieldModel
	{
        public int Id { get; set; }
        public string? Title{ get; set; }

        [ForeignKey("FieldType")]
        public int? FieldTypeId { get; set; }
        public FieldTypeModel? FieldType { get; set; }

        [ForeignKey("Crud")]
		public int CrudId { get; set; }
    }

	public class CrudModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }

        public List<FieldModel> Fields { get; set; } = new List<FieldModel>();

        [ForeignKey("Project")]
		public int ProjectId { get; set; }
		//public ProjectModel Project {get;set;}

		[ForeignKey("CrudStatic")]
		public int CrudStaticId { get; set; }
		public CrudStaticModel? CrudStatic { get; set; }

		public List<FileModel> Files { get; set; } = new List<FileModel>();
	}
}

