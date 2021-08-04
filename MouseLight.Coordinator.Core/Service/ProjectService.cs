using System;
using System.Collections.Generic;
using System.Linq;

using MouseLight.Core.Data;
using MouseLight.Core.Model;

namespace MouseLight.Core.Service
{
    public class ProjectService
    {
        private readonly PipelineContext _dbContext;

        public ProjectService(PipelineContext pipelineContext)
        {
            _dbContext = pipelineContext;
        }

        public Project GetProject(Guid id)
        {
            return _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IReadOnlyList<Project> GetProjects()
        {
            return _dbContext.Projects.ToList();
        }

        public Guid? ProjectIdForStage(Guid id)
        {
            return _dbContext.PipelineStages.FirstOrDefault(s => s.Id == id)?.ProjectId;
        }
    }
}
