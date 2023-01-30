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

        public override async Task<GetCompetitionsDota2Response> GetCompetitionsDota2(GetCompetitionsDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var page = request.Page;
            var pageSize = request.PageSize;

            var competitions = await _competitionDota2Service.GetRange(page, pageSize, token);

            var grpcCompetitions = _mapper.Map<IEnumerable<CompetitionDota2>>(competitions);

            var response = new GetCompetitionsDota2Response();

            response.CompetitionsDota2.AddRange(grpcCompetitions);

            return response;
        }

        public override async Task<UpdateCompetitionDota2Response> UpdateCompetitionDota2(UpdateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var updatedCompetition = _mapper.Map<CompetitionBusinessModels.CompetitionDota2>(request.CompetitionDota2);

            await _competitionDota2Service.Update(updatedCompetition, token);

            var response = new UpdateCompetitionDota2Response();

            return response;
        }

        public override async Task<BlockCompetitionBaseByIdResponse> BlockCompetitionBaseById(BlockCompetitionBaseByIdRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var response = new BlockCompetitionBaseByIdResponse();

            return response;
        }

        public override async Task<CompleteCompetitionBaseOutcomesResponse> CompleteCompetitionBaseOutcomes(CompleteCompetitionBaseOutcomesRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var response = new CompleteCompetitionBaseOutcomesResponse();

            return response;
        }

        public override async Task<DepositToCoefficientByIdResponse> DepositToCoefficientById(DepositToCoefficientByIdRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var response = new DepositToCoefficientByIdResponse();

            return response;
        }
    }
}
