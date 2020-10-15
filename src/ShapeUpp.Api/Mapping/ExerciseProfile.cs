using AutoMapper;
using ShapeUpp.Api.Models;
using ShapeUpp.Domain.Models;

namespace ShapeUpp.Api.Mapping
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExerciseDto, Exercise>()
                .ForMember(x => x.Equipment, x => x.Ignore())
                //.ForMember(x => x.CategoryId, x => x.MapFrom(v => v.Activity))
                ;
        }
    }
}
