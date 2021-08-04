
using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MouseLight.Core.Data;
using MouseLight.Core.Service;

namespace MouseLight.Coordinator.Tests.Service
{
    [TestClass]
    public class ProjectServiceTests
    {
        private static PipelineContextOptions _options;
        
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _options = new PipelineContextOptions
            {
                Host = "localhost",
                Port = 6510,
                Database = "pipeline_production",
                User = "postgres",
                Password= "pgsecret"
            };
        }
        
        [TestMethod]
        public void TestGetProjects()
        {
            using var db = new PipelineContext(_options);

            var service = new ProjectService(db);

            var projects = service.GetProjects();

            Assert.AreEqual(3, projects.Count);
        }
    }
}
