using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MouseLight.Core.Data;
using MouseLight.Core.Service;

namespace MouseLight.Coordinator.Tests.Service
{
    [TestClass]
    public class TaskExecutionServiceTests
    {
        private static PipelineContextOptions _options;

        private static TaskExecutionConnectorService _taskExecutionServiceConnector;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _options = new PipelineContextOptions
            {
                Host = "localhost",
                Port = 6510,
                Database = "pipeline_production",
                User = "postgres",
                Password = "pgsecret"
            };

            _taskExecutionServiceConnector = new TaskExecutionConnectorService(_options);
        }

        [TestMethod]
        public async Task TestCreateTable()
        {
            var service = await _taskExecutionServiceConnector.ForStage(Guid.Parse("55c2a6d6-5c2b-4f42-81d9-45f81b4308f9"));

            Assert.IsNotNull(service);
        }
    }
}
