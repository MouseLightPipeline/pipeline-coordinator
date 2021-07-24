using System;

using Microsoft.Extensions.Options;

namespace MouseLight.Core.Data
{
    public class PipelineContextConnection
    {
        public string ConnectionString { get; }

        public PipelineContextConnection(IOptions<PipelineContextOptions> contextOptions)
        {
            var options = contextOptions.Value;

            ConnectionString = $"Host={options.Host};Port={options.Port};Database={options.Database};Username={options.User};Password={options.Password};";
        }
    }
}
