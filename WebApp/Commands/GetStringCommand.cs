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
    public class GetStringCommand<P> : HystrixCommand<string>
    {
        private Configuration _config { get; set; }
        private string apiBase { get; set; }

        private IGatewayService<P> gatewayService;
        public GetStringCommand(IHystrixCommandOptions options,
            IOptions<Configuration> configSettings, IGatewayService<P> service)
            : base(options)
        {
            this._config = configSettings.Value;
            this.apiBase = this._config.GatewayUrl;
            this.gatewayService = service;
        }

        public string get(string path)
        {
            this.apiBase += path;
            return Execute();
        }

        protected override string Run()
        {
            return this.gatewayService.getStringData(this.apiBase);
        }

        protected override string RunFallback()
        {
            return "failed to get string data";
        }

    }
}
