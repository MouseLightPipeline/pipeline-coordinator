using System;

using Microsoft.Extensions.Options;

namespace MouseLight.Core.Data
{
    public class PipelineContextConnection
    {
        public string ConnectionString { get; private set; }

        public PipelineContextConnection(IOptions<PipelineContextOptions> contextOptions)
        {
            if (contextOptions != null)
            {
                var options = contextOptions.Value;

                ConnectionString = $"Host={options.Host};Port={options.Port};Database={options.Database};Username={options.User};Password={options.Password};";
            }
        }

        public static PipelineContextConnection ForOptions(PipelineContextOptions options)
        {
            var connection = new PipelineContextConnection(null);

            connection.ConnectionString = $"Host={options.Host};Port={options.Port};Database={options.Database};Username={options.User};Password={options.Password};";

            return connection;
        }
    }
}
