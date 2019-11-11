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
    public class GetCommand<P,Q> : HystrixCommand<Q>
    {
        private Configuration _config { get; set; }
        private string apiBase { get; set; }

        private IGatewayService<P> gatewayService;
        public GetCommand(IHystrixCommandOptions options,
            IOptions<Configuration> configSettings, IGatewayService<P> service)
            : base(options)
        {
            this._config = configSettings.Value;
            this.apiBase = this._config.GatewayUrl;
            this.gatewayService = service;
        }

        public Q get(string path)
        {
            this.apiBase += path;
            return Execute();
        }

        protected override Q Run()
        {
            return this.gatewayService.getData<Q>(this.apiBase);
        }

        protected override Q RunFallback()
        {
            return default(Q);
        }

    }
}
