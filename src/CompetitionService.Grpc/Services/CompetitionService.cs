using AutoMapper;
using BetService.Grpc;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Extensions;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Models;
using CompetitionService.Grpc.Extensions;
using Grpc.Core;
using Grpc.Net.ClientFactory;
using static BetService.Grpc.BetService;
using CompetitionBusinessEntities = CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.Grpc.Services
{
    public class CompetitionService : Grpc.CompetitionService.CompetitionServiceBase
    {
        private readonly ICompetitionService<CompetitionBusinessEntities.CompetitionDota2> _competitionDota2Service;
        private readonly ICoefficientService _coefficientService;
        private readonly ICompetitionBaseService _competitionBaseService;
        private readonly IMapper _mapper;
        private readonly GrpcClientFactory _grpcClientFactory;

        public CompetitionService(
            ICompetitionService<CompetitionBusinessEntities.CompetitionDota2> competitionDota2Service,
            ICoefficientService coefficientService,
            ICompetitionBaseService competitionBaseService,
            IMapper mapper,
            GrpcClientFactory grpcClientFactory)
        {
            _competitionDota2Service = competitionDota2Service;
            _coefficientService = coefficientService;
            _competitionBaseService = competitionBaseService;
            _mapper = mapper;
            _grpcClientFactory = grpcClientFactory;
        }

        public override async Task<CreateCompetitionDota2Response> CreateCompetitionDota2(CreateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var competitionDota2 = _mapper.Map<CompetitionBusinessEntities.CompetitionDota2>(request.CompetitionDota2);

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

            var updatedCompetition = _mapper.Map<CompetitionBusinessEntities.CompetitionDota2>(request.CompetitionDota2);

            await _competitionDota2Service.Update(updatedCompetition, token);

            var response = new UpdateCompetitionDota2Response();

            return response;
        }

        public override async Task<BlockCompetitionBaseByIdResponse> BlockCompetitionBaseById(BlockCompetitionBaseByIdRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitionBaseId = _mapper.Map<Guid>(request.Id);

            await _competitionBaseService.BlockCompetitionBaseById(competitionBaseId, token);

            var response = new BlockCompetitionBaseByIdResponse();

            return response;
        }

        public override async Task<CompleteCompetitionBaseOutcomesResponse> CompleteCompetitionBaseOutcomes(CompleteCompetitionBaseOutcomesRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var completedCompetitionBase = _mapper.Map<CompetitionBusinessEntities.CompetitionBase>(request.CompetitionBase);

            await _competitionBaseService.CompleteCompetitionBaseOutcomes(completedCompetitionBase, token);

            var updateModels = _mapper.Map<IEnumerable<BetServiceBetStatusUpdateModel>>(completedCompetitionBase.ToBetStatusUpdateModels());
            var grpcUpdateModels = _mapper.Map<IEnumerable<BetStatusUpdateModel>>(updateModels);

            var client = _grpcClientFactory.GetGrpcClient<BetServiceClient>();

            var requestUpdateStatuses = new UpdateBetStatusesRequest();
            requestUpdateStatuses.BetStatusUpdateModels.AddRange(grpcUpdateModels);

            await client.UpdateBetStatusesAsync(requestUpdateStatuses);

            var response = new CompleteCompetitionBaseOutcomesResponse();

            return response;
        }

        public override async Task<DepositToCoefficientByIdResponse> DepositToCoefficientById(DepositToCoefficientByIdRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var coefficientId = _mapper.Map<Guid>(request.CoefficientId);
            var amount = request.Amount;

            var rate = await _coefficientService.DepositToCoefficientById(coefficientId, amount, token);

            var response = new DepositToCoefficientByIdResponse
            {
                Rate = rate
            };

            return response;
        }
    }
}
