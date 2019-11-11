using Microsoft.Extensions.Options;
using Steeltoe.CircuitBreaker.Hystrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class DeleteCommand : HystrixCommand<string>
    {
        private Configuration _config { get; set; }
        private string apiBase { get; set; }

        private IGatewayService<string> gatewayService;
        public DeleteCommand(IHystrixCommandOptions options,
            IOptions<Configuration> configSettings, IGatewayService<string> service)
            : base(options)
        {
            this._config = configSettings.Value;
            this.apiBase = this._config.GatewayUrl;
            this.gatewayService = service;
        }

        public string delete(string path)
        {
            this.apiBase += path;
            return Execute();
        }

        protected override string Run()
        {
            return this.gatewayService.deleteData(this.apiBase);
        }

        protected override string RunFallback()
        {
            return "This operation was not successful";
        }

    }
}
