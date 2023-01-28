using CompetitionService.BusinessLogic.Contracts.Services;
using Grpc.Core;

using CompetitionBusinessModels = CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.Grpc.Services
{
    public class CompetitionService : Grpc.CompetitionService.CompetitionServiceBase
    {
        private readonly ICompetitionService<CompetitionBusinessModels.CompetitionDota2> _competitionDota2Service;

        public CompetitionService(ICompetitionService<CompetitionBusinessModels.CompetitionDota2> competitionDota2Service)
        {
            _competitionDota2Service = competitionDota2Service;
        }

        public override Task<CreateCompetitionDota2Response> CreateCompetitionDota2(CreateCompetitionDota2Request request, ServerCallContext context)
        {
            return base.CreateCompetitionDota2(request, context);
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
