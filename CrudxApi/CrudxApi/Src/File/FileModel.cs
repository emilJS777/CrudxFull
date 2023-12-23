using System;
using System.ComponentModel.DataAnnotations.Schema;
using CrudxApi.Src.Crud;
using CrudxApi.Src.CrudStatic;
using CrudxApi.Src.Technology;

namespace CrudxApi.Src.File
{
	public class FileModel
	{
        public int Id { get; set; }
        public string? Path { get; set; }
        public string? FileName { get; set; }
        public string? Text { get; set; }
        public string? CommandLine { get; set; }
        public string? DynamicManyLineStart { get; set; }
        public string? DynamicLine { get; set; }

        [ForeignKey("Technology")]
        public int? TechnologyId { get; set; }
        //public TechnologyModel? Technology { get; set; }

        [ForeignKey("CrudStatic")]
        public int? CrudStaticId { get; set; }
        //public CrudStaticModel? CrudStatic { get; set; }

        [ForeignKey("Crud")]
        public int? CrudId { get; set; }
        //public CrudModel? Crud { get; set; }
    }
}
