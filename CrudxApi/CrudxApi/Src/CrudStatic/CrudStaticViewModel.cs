using System;
using System.ComponentModel.DataAnnotations.Schema;
using CrudxApi.Src.FieldType;
using CrudxApi.Src.File;

namespace CrudxApi.Src.CrudStatic
{
    public class CrudStaticViewModel
	{
        public string? Title { get; set; }
        public string? DynamicTitle { get; set; }
        public string? DynamicFieldTitle { get; set; }
        public string? DynamicFieldType { get; set; }
        public List<FieldTypeViewModel> FieldTypes { get; set; } = new List<FieldTypeViewModel>();
        public List<FileViewModel> Files { get; set; } = new List<FileViewModel>();
        public int TechnologyId { get; set; }
    }
}
