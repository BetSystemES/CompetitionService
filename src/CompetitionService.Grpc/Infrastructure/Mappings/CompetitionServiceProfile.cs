using AutoMapper;
using BetService.Grpc;
using CompetitionService.Grpc.Infrastructure.Mappings.Extensions;
using Google.Protobuf.WellKnownTypes;

using BusinessEntities = CompetitionService.BusinessLogic.Entities;
using BusnessEnums = CompetitionService.BusinessLogic.Models.Enums;
using BusnessModels = CompetitionService.BusinessLogic.Models;

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

            CreateMap<CoefficientCreateModel, BusinessEntities.Coefficient>()
                .Ignore(x => x.Id);
            CreateMap<CoefficientGroupCreateModel, BusinessEntities.CoefficientGroup>()
                .Ignore(x => x.Coefficients)
                .Ignore(x => x.Id);
            CreateMap<CompetitionBaseCreateModel, BusinessEntities.CompetitionBase>()
                .Ignore(x => x.CoefficientGroups)
                .Ignore(x => x.Id);
            CreateMap<CompetitionDota2CreateModel, BusinessEntities.CompetitionDota2>()
                .Ignore(x => x.CompetitionBase)
                .Ignore(x => x.Id);

            CreateMap<CoefficientUpdateModel, BusinessEntities.Coefficient>();
            CreateMap<CoefficientGroupUpdateModel, BusinessEntities.CoefficientGroup>()
                .Ignore(x => x.Coefficients);
            CreateMap<CompetitionBaseUpdateModel, BusinessEntities.CompetitionBase>()
                .Ignore(x => x.CoefficientGroups);
            CreateMap<CompetitionDota2UpdateModel, BusinessEntities.CompetitionDota2>()
                .Ignore(x => x.CompetitionBase);

            CreateMap<BusnessModels.CoefficientStatus, BetStatusUpdateModel>()
                .ForMember(dest => dest.StatusType,
                    opt => opt.MapFrom(src => src.OutcomeType))
                .ReverseMap();

        }
    }
}
