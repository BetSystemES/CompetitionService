using AutoMapper;
using FizzWare.NBuilder;
using NScenario;
using Xunit.Abstractions;
using CompetitionService.FunctionalTests.Adapters;
using CompetitionService.Grpc;
using static CompetitionService.Grpc.CompetitionService;
using Coefficient = CompetitionService.BusinessLogic.Entities.Coefficient;
using CoefficientGroup = CompetitionService.BusinessLogic.Entities.CoefficientGroup;
using CompetitionBase = CompetitionService.BusinessLogic.Entities.CompetitionBase;
using GrpcModels = CompetitionService.Grpc;

namespace CompetitionService.FunctionalTests.Scenaries.CompetitionDota2
{
    public class ScenarioCreateCompetitionDota2Tests : IClassFixture<TestServerFixture>
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly CompetitionServiceClient _client;
        private readonly IMapper _mapper;

        public ScenarioCreateCompetitionDota2Tests(TestServerFixture factory, ITestOutputHelper outputHelper, IMapper mapper)
        {
            _client = new CompetitionServiceClient(factory.GrpcChannel);
            _outputHelper = outputHelper;
            _mapper = mapper;
        }

        public async Task ScenarioCreateCompetitionDota2()
        {
            var scenario = TestScenarioFactory.Default(
                new XUnitOutputAdapter(_outputHelper),
                testMethodName: $"Create competition.");

            var coefficients = Builder<Coefficient>
                .CreateListOfSize(2)
                .All()
                .With(x => x.Id = Guid.NewGuid())
                .Build();

            var coefficientGroups = Builder<CoefficientGroup>
                .CreateListOfSize(2)
                .All()
                .With(x => x.Id = Guid.NewGuid())
                .With(x => x.Coefficients = coefficients.ToList())
                .Build();

            var competitionDota2 = Builder<BusinessLogic.Entities.CompetitionDota2>
                .CreateNew()
                .With(x => x.Id = Guid.NewGuid())
                .With(x => x.Team1Id = Guid.NewGuid())
                .With(x => x.Team2Id = Guid.NewGuid())
                .With(x => x.CompetitionBase = Builder<CompetitionBase>
                    .CreateNew()
                    .With(x => x.Id = Guid.NewGuid())
                    .With(x => x.CoefficientGroups = coefficientGroups.ToList())
                    .Build())
                .Build();

            var createCompetitionDota2Response = await scenario
                .Step($"Create competition dota2",
                async () =>
                {
                    var request = new CreateCompetitionDota2Request();

                    var competitionDota2Grpc = _mapper.Map<GrpcModels.CompetitionDota2CreateModel>(competitionDota2);
                    request.CompetitionDota2CreateModel = competitionDota2Grpc;

                    return await _client.CreateCompetitionDota2Async(request);
                });

            // TODO: please add assert
        }
    }
}
