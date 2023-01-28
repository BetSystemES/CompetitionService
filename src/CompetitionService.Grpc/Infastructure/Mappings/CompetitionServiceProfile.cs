using AutoMapper;
using Google.Protobuf.WellKnownTypes;

using BusinessModels = CompetitionService.BusinessLogic.Models;

namespace CompetitionService.Grpc.Infastructure.Mappings
{
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
