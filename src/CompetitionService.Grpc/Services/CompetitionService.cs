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
        private readonly ICoefficientGroupService _coefficientGroupService;
        private readonly ILogger<CompetitionService> _logger;
        private readonly ICompetitionBaseService _competitionBaseService;
        private readonly IMapper _mapper;
        private readonly GrpcClientFactory _grpcClientFactory;

        public CompetitionService(
            ICompetitionService<CompetitionBusinessEntities.CompetitionDota2> competitionDota2Service,
            ICoefficientService coefficientService,
            ICompetitionBaseService competitionBaseService,
            IMapper mapper,
            GrpcClientFactory grpcClientFactory,
            ICoefficientGroupService coefficientGroupService,
            ILogger<CompetitionService> logger)
        {
            _competitionDota2Service = competitionDota2Service;
            _coefficientService = coefficientService;
            _competitionBaseService = competitionBaseService;
            _mapper = mapper;
            _grpcClientFactory = grpcClientFactory;
            _coefficientGroupService = coefficientGroupService;
            _logger = logger;
        }

        public override async Task<GetCompetitionDota2Response> GetCompetitionDota2(GetCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitionId = _mapper.Map<Guid>(request.Id);

            var competition = await _competitionDota2Service.GetById(competitionId, token);

            var grpcCompetition = _mapper.Map<CompetitionDota2>(competition);

            var response = new GetCompetitionDota2Response
            {
                CompetitionDota2 = grpcCompetition,
            };

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

            var updatedCompetition = _mapper.Map<CompetitionBusinessEntities.CompetitionDota2>(request.CompetitionDota2UpdateModel);

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

            var coefficientGuid = _mapper.Map<Guid>(request.CoefficientId);
            var depositAmount = request.Amount;

            var rate = await _coefficientService.DepositToCoefficientById(coefficientGuid, depositAmount, token);

            var response = new DepositToCoefficientByIdResponse
            {
                Rate = rate
            };

            var betServiceClient = _grpcClientFactory.GetGrpcClient<BetServiceClient>();
            var betCreateModel = new BetCreateModel()
            {
                UserId = request.UserId,
                CoefficientId = request.CoefficientId,
                Amount = request.Amount,
                Rate = response.Rate
            };

            var createBetRequest = new CreateBetRequset
            {
                BetCreateModel = betCreateModel
            };

            await betServiceClient.CreateBetAsync(createBetRequest);

            return response;
        }

        public override async Task<UpdateCoefficientResponse> UpdateCoefficient(UpdateCoefficientRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var coefficient = _mapper.Map<CompetitionBusinessEntities.Coefficient>(request.CoefficientUpdateModel);

            await _coefficientService.Update(coefficient, token);
            _logger.LogDebug("coefficient with Id={id} updated", coefficient.Id);
            var betUpdateModel = coefficient.ToBetStatusUpdateModel();
            var grpcUpdateModel = _mapper.Map<BetStatusUpdateModel>(betUpdateModel);

            var client = _grpcClientFactory.GetGrpcClient<BetServiceClient>();
            var requestUpdateStatuses = new UpdateBetStatusRequest()
            {
                BetStatusUpdateModel = grpcUpdateModel,
            };

            await client.UpdateBetStatusAsync(requestUpdateStatuses);
            _logger.LogDebug($"!!!!!betUpdateModel: {betUpdateModel.CoefficientId} {betUpdateModel.OutcomeType}");

            var response = new UpdateCoefficientResponse();

            return response;
        }

        public override async Task<UpdateOutcomeResponse> UpdateOutcome(UpdateOutcomeRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var coefficientGroup = _mapper.Map<CompetitionBusinessEntities.CoefficientGroup>(request.OutcomeUpdateModel);

            await _coefficientGroupService.Update(coefficientGroup, token);

            var response = new UpdateOutcomeResponse();

            return response;
        }

        public override async Task<UpdateCompetitionBaseResponse> UpdateCompetitionBase(UpdateCompetitionBaseRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;

            var competitionBase = _mapper.Map<CompetitionBusinessEntities.CompetitionBase>(request.CompetitionBaseUpdateModel);

            await _competitionBaseService.Update(competitionBase, token);

            var response = new UpdateCompetitionBaseResponse();

            return response;
        }

        public override async Task<CreateCompetitionDota2Response> CreateCompetitionDota2(CreateCompetitionDota2Request request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var competitionDota2 = _mapper.Map<CompetitionBusinessEntities.CompetitionDota2>(request.CompetitionDota2CreateModel);

            await _competitionDota2Service.Create(competitionDota2, token);

            var response = new CreateCompetitionDota2Response();

            return response;
        }

        public override async Task<CreateCoefficientResponse> CreateCoefficient(CreateCoefficientRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var coefficient = _mapper.Map<CompetitionBusinessEntities.Coefficient>(request.CoefficientCreateModel);

            await _coefficientService.Create(coefficient, token);

            var response = new CreateCoefficientResponse();

            return response;
        }

        public override async Task<CreateCompetitionBaseResponse> CreateCompetitionBase(CreateCompetitionBaseRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var competitionBase = _mapper.Map<CompetitionBusinessEntities.CompetitionBase>(request.CompetitionBaseCreateModel);

            var addedCompetitionBase = await _competitionBaseService.Create(competitionBase, token);
            var addedCompetitionBaseGrpc = _mapper.Map<CompetitionBase>(addedCompetitionBase);

            var response = new CreateCompetitionBaseResponse()
            {
                CompetitionBase = addedCompetitionBaseGrpc,
            };

            return response;
        }

        public override async Task<CreateOutcomeResponse> CreateOutcome(CreateOutcomeRequest request, ServerCallContext context)
        {
            var token = context.CancellationToken;
            var coefficientGroup = _mapper.Map<CompetitionBusinessEntities.CoefficientGroup>(request.CoefficientGroupCreateModel);

            await _coefficientGroupService.Create(coefficientGroup, token);

            var response = new CreateOutcomeResponse();

            return response;
        }
    }
}
