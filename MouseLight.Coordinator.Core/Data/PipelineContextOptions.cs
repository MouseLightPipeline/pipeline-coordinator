using System;

namespace MouseLight.Core.Data
{
    public class PipelineContextOptions
    {
        public const string PipelineContext = "PipelineContext";

        public string Host { get; set; }

        public int Port { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public PipelineContextOptions() { }
    }
}
