using AutoMapper;
using CompetitionService.BusinessLogic.Contracts.Services;
using Grpc.Core;

using CompetitionBusinessModels = CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.Grpc.Services
{
    public class CompetitionService : Grpc.CompetitionService.CompetitionServiceBase
    {
        private readonly ICompetitionService<CompetitionBusinessModels.CompetitionDota2> _competitionDota2Service;
        private readonly IMapper _mapper;

        public CompetitionService(
            ICompetitionService<CompetitionBusinessModels.CompetitionDota2> competitionDota2Service,
            IMapper mapper)
        {
            _competitionDota2Service = competitionDota2Service;
            _mapper = mapper;
        }

        public override async Task<CreateCompetitionDota2Response> CreateCompetitionDota2(CreateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var competitionDota2 = _mapper.Map<CompetitionBusinessModels.CompetitionDota2>(request.CompetitionDota2);

            await _competitionDota2Service.Create(competitionDota2, token);

            var response = new CreateCompetitionDota2Response();

            return response;
        }

        public override Task<GetCompetitionsDota2Response> GetCompetitionsDota2(GetCompetitionsDota2Request request, ServerCallContext context)
        {
            return base.GetCompetitionsDota2(request, context);
        }

        public override Task<UpdateCompetitionDota2Response> UpdateCompetitionDota2(UpdateCompetitionDota2Request request, ServerCallContext context)
        {
            return base.UpdateCompetitionDota2(request, context); 
        }

        public override Task<BlockCompetitionBaseByIdResponse> BlockCompetitionBaseById(BlockCompetitionBaseByIdRequest request, ServerCallContext context)
        {
            return base.BlockCompetitionBaseById(request, context);
        }

        public override Task<CalculateCompetitionBaseOutcomesResponse> CalculateCompetitionBaseOutcomes(CalculateCompetitionBaseOutcomesRequest request, ServerCallContext context)
        {
            return base.CalculateCompetitionBaseOutcomes(request, context);
        }

        public override Task<DepositToCoefficientByIdResponse> DepositToCoefficientById(DepositToCoefficientByIdRequest request, ServerCallContext context)
        {
            return base.DepositToCoefficientById(request, context);
        }
    }
}
