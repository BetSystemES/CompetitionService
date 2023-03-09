using AutoMapper;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Models;
using Google.Protobuf.WellKnownTypes;
using BusinessModels = CompetitionService.BusinessLogic.Models.BetServiceModels.Models;
using BusinessEnums = CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;

namespace BetService.Grpc.Infrastructure.Mappings
{
    /// <summary>Profile of grpc layer</summary>
    public class BetServiceProfile : Profile
    {
        public BetServiceProfile()
        {
            CreateMap<string, Guid>()
                .ConvertUsing((x, res) => res = Guid.TryParse(x, out var id) ? id : Guid.Empty);
            CreateMap<Guid?, string>()
                .ConvertUsing((x, res) => res = x?.ToString() ?? string.Empty);
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(x));
            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(x => x.ToDateTime());
            CreateMap<Bet, Bet>()
                .ReverseMap();
            CreateMap<BetStatusUpdateModel, BetStatusUpdateModel>()
                .ReverseMap();
            CreateMap<BetCreateModel, Bet>();
            CreateMap<BetPayoutStatus, BetPayoutStatus>()
                .ReverseMap();
            CreateMap<BetStatusType, BetStatusType>()
                .ReverseMap();
        }
    }
}
