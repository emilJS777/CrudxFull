using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudxApi.Src.FieldType
{
	public class FieldTypeModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Type { get; set; }

		[ForeignKey("CrudStatic")]
		public int? CrudStaticId { get; set; }
	}
}

