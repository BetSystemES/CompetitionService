using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using BusinessModels = CompetitionService.BusinessLogic.Models.BetServiceModels.Models;
using BusinessEnums = CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;
using BetService.Grpc;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Models;

namespace CompetitionService.Grpc.Infrastructure.Mappings
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
            CreateMap<BusinessModels.BetServiceBet, Bet>()
                .ReverseMap();
            CreateMap<CompetitionService.BusinessLogic.Models.BetStatusUpdateModel, BetStatusUpdateModel>()
                .ReverseMap();
            CreateMap<BetCreateModel, BusinessModels.BetServiceBet>();
            CreateMap<BusinessEnums.BetServiceBetPayoutStatus, BetPayoutStatus>()
                .ReverseMap();
            CreateMap<BusinessEnums.BetServiceBetStatusType, BetStatusType>()
                .ReverseMap();
        }
    }
}
