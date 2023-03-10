using AutoMapper;
using Google.Protobuf.WellKnownTypes;

using BusinessEntities = CompetitionService.BusinessLogic.Entities;
using BusnessEnums = CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.Grpc.Infrastructure.Mappings
{
    /// <summary>
    /// AutoMapper Profile for competition grpc serivce.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class CompetitionServiceProfile : Profile
    {
        public CompetitionServiceProfile()
        {
            CreateMap<string, Guid>()
                .ConvertUsing((x, res) => res = Guid.TryParse(x, out var id) ? id : Guid.Empty);
            CreateMap<Guid?, string>()
                .ConvertUsing((x, res) => res = x?.ToString() ?? string.Empty);

            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(x));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());

            CreateMap<BusnessEnums.CoefficientGroupType, CoefficientGroupType>()
                .ReverseMap();
            CreateMap<BusnessEnums.CoefficientStatusType, CoefficientStatusType>()
                .ReverseMap();
            CreateMap<BusnessEnums.CoefficientOutcomeType, CoefficientOutcomeType>()
                .ReverseMap();
            CreateMap<BusnessEnums.CompetitionStatusType, CompetitionStatusType>()
                .ReverseMap();
            CreateMap<BusnessEnums.CompetitionType, CompetitionType>()
                .ReverseMap();

            CreateMap<BusinessEntities.Coefficient, Coefficient>()
                .ReverseMap();
            CreateMap<BusinessEntities.CoefficientGroup, CoefficientGroup>()
                .ReverseMap();
            CreateMap<BusinessEntities.CompetitionBase, CompetitionBase>()
                .ReverseMap();
            CreateMap<BusinessEntities.CompetitionDota2, CompetitionDota2>()
                .ReverseMap();
        }
    }
}
