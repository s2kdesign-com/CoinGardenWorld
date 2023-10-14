

namespace CoinGardenWorldMobileApp_Api.Tests
{
    [TestClass]
    public class ChatHubSignalrFunctionTest : BaseTest
    {
        [TestMethod]
        public async Task Negotiate_ReturnsCorrectModel_Test()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();

            //mock the dependencies for injection
            var context = new Mock<FunctionContext>();
            var httpRequestData = new Mock<HttpRequestData>(context.Object);



            // Logger
            var mockLogger = new Mock<ILogger<ChatHubSignalRFunction>>();
            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));
            var loggerFactoryMoc = new Mock<ILoggerFactory>();
            loggerFactoryMoc.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);


            // Unit test negotiate
            var userId = Guid.NewGuid().ToString();

            var azureSignalrConnectionString = BaseTest.SignalRConnectionString;

            // Start signalr service
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.SetupGet(x => x[It.Is<string>(s => s == "AzureSignalRConnectionString")]).Returns(azureSignalrConnectionString);

            // add IConfiguration to services
            services.AddSingleton(mockConfig.Object);
            // add ILoggerFactory to services
            services.AddSingleton(loggerFactoryMoc.Object);

            SignalRService signalRService = new SignalRService(mockConfig.Object, loggerFactoryMoc.Object);
            
            services.AddScoped<IHostedService, SignalRService>(o => signalRService);
            //services.AddScoped<IHubContextStore, SignalRService>();
            var serviceProvider = services.BuildServiceProvider();
            var hostedService = serviceProvider.GetService<IHostedService>();
            await hostedService.StartAsync(CancellationToken.None);

            //Act
            var myHub = new ChatHubSignalRFunction(loggerFactoryMoc.Object, signalRService);
            var connectionInfo =  await myHub.Negotiate(httpRequestData.Object);

            Assert.IsNotNull(connectionInfo.AccessToken);
            Assert.IsNotNull(connectionInfo.Url);

            // Unit test broadcast method
            var target = Guid.NewGuid().ToString();
            var message = Guid.NewGuid().ToString();
            await myHub.Broadcast(new SignalRInvocationContext(),  message);

            // TODO:  Check https://github.dev/Azure/azure-functions-signalrservice-extension/blob/3e87c3ce277265866ca9d0bf51bb9c7ecea39e14/test/SignalRServiceExtension.Tests/Trigger/ServerlessHubTest.cs#L51#L58
            // For correct tests

            //clientProxyMoc.Verify(c => c.SendCoreAsync(target, It.IsAny<object[]>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}