using AutoMapper;
using CompetitionService.FunctionalTests.Adapters;
using CompetitionService.FunctionalTests.TestData;
using CompetitionService.Grpc;
using NScenario;
using Xunit.Abstractions;
using static CompetitionService.Grpc.CompetitionService;

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

            var createCompetitionDota2Response = await scenario
                .Step($"Create competition dota2",
                async () =>
                {
                    var request = new CreateCompetitionDota2Request();

                    var competitionDota2Grpc = _mapper.Map<GrpcModels.CompetitionDota2>(CompetitionDota2Samples._competitionDota2_ValidModel);
                    request.CompetitionDota2 = competitionDota2Grpc;

                    return await _client.CreateCompetitionDota2Async(request);
                });
        }
    }
}
