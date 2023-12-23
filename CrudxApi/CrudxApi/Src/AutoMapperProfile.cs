using System;
using System.Collections.Generic;
using AutoMapper;
using CrudxApi.Src.Crud;
using CrudxApi.Src.CrudStatic;
using CrudxApi.Src.FieldType;
using CrudxApi.Src.File;
using CrudxApi.Src.Project;
using CrudxApi.Src.Technology;

namespace CrudxApi
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			// TECHNOLOGY 
			CreateMap<TechnologyModel, TechnologyViewModel>();
			CreateMap<TechnologyViewModel, TechnologyModel>();

			// FILE 
			CreateMap<FileModel, FileViewModel>();
            CreateMap<FileViewModel, FileModel>();
            CreateMap<FileModel, FileModel>().ForMember(dest => dest.CrudStaticId, opt => opt.Ignore());

            // PROJECT
            CreateMap<ProjectModel, ProjectViewModel>();
            CreateMap<ProjectViewModel, ProjectModel>();

			// CRUD STATIC
			CreateMap<CrudStaticModel, CrudStaticViewModel>();
			CreateMap<CrudStaticViewModel, CrudStaticModel>();

            // CRUD
            CreateMap<CrudModel, CrudViewModel>();
            CreateMap<CrudViewModel, CrudModel>();

            // FIELDS
            CreateMap<FieldModel, FieldViewModel>();
            CreateMap<FieldViewModel, FieldModel>();

            // FIELD TYPES
            CreateMap<FieldTypeModel, FieldTypeViewModel>();
            CreateMap<FieldTypeViewModel, FieldTypeModel>();

        }
    }
}

