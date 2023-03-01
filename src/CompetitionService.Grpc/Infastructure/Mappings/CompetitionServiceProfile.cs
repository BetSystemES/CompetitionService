using AutoMapper;
using Google.Protobuf.WellKnownTypes;

using BusinessModels = CompetitionService.BusinessLogic.Models;
using BusnessEnums = CompetitionService.BusinessLogic.Enums;

namespace CompetitionService.Grpc.Infastructure.Mappings
{
    // TODO: Rename folder from Infastructure to Infrastructure
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
            CreateMap<BusnessEnums.CompetitionStatusType, CompetitionStatusType>()
                .ReverseMap();
            CreateMap<BusnessEnums.CompetitionType, CompetitionType>()
                .ReverseMap();

            CreateMap<BusinessModels.Coefficient, Coefficient>()
                .ReverseMap();
            CreateMap<BusinessModels.CoefficientGroup, CoefficientGroup>()
                .ReverseMap();
            CreateMap<BusinessModels.Competitions.CompetitionBase, CompetitionBase>()
                .ReverseMap();
            CreateMap<BusinessModels.Competitions.CompetitionDota2, CompetitionDota2>()
                .ReverseMap();
        }
    }
}
