using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MouseLight.Core.Data;
using MouseLight.Core.Model;
using MouseLight.Core.Service;

namespace MouseLight.Coordinator.Tests.Service
{
    [TestClass]
    public class TaskExecutionServiceTests
    {
        private static PipelineContextOptions _options;

        private static TaskExecutionConnectorService _taskExecutionServiceConnector;

        private static Guid _projectId;

        private static Project _project;

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

            _taskExecutionServiceConnector = new TaskExecutionConnectorService(Options.Create(_options));

            _projectId = Guid.NewGuid();
        }

        [TestMethod]
        public async Task TestCreateTable()
        {
            using var db = new PipelineContext(_options);

            var projectService = new ProjectService(db);

            projectService.CreateOrFind(_projectId);

            var service = await _taskExecutionServiceConnector.ForProject(_projectId);

            Assert.IsNotNull(service);

            _taskExecutionServiceConnector.Drop(_projectId);
        }
    }
}
