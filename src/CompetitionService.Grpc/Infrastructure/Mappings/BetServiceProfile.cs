using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using BetService.Grpc;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Models;
using CompetitionService.BusinessLogic.Models;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;

namespace CompetitionService.Grpc.Infrastructure.Mappings
{
    /// <summary>Profile of grpc layer</summary>
    public class BetServiceProfile : Profile
    {
        public BetServiceProfile()
        {
            CreateMap<BetServiceBet, Bet>()
                .ReverseMap();
            CreateMap<BetServiceBetStatusUpdateModel, BetStatusUpdateModel>()
                .ReverseMap();
            CreateMap<BetCreateModel, BetServiceBet>();
            CreateMap<BetServiceBetPayoutStatus, BetPayoutStatus>()
                .ReverseMap();
            CreateMap<BetServiceBetStatusType, BetStatusType>()
                .ReverseMap();
            CreateMap<BetServiceBetStatusUpdateModel, CoefficientStatus>()
                .ForMember(dest => dest.OutcomeType,
                    opt =>
                        opt.MapFrom(src => src.StatusType))
                .ReverseMap();
        }
    }
}
