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
    public class GetAllCommand<T> : HystrixCommand<IEnumerable<T>>
    {
        private T body;
        private Configuration _config { get; set; }
        private string apiBase { get; set; }

        private IGatewayService<T> gatewayService;
        public GetAllCommand(IHystrixCommandOptions options,
            IOptions<Configuration> configSettings, IGatewayService<T> service)
            : base(options)
        {
            this._config = configSettings.Value;
            this.apiBase = this._config.GatewayUrl;
            this.gatewayService = service;
        }

        public IEnumerable<T> getAll(string path)
        {
            this.apiBase += path;
            return Execute();
        }

        protected override IEnumerable<T> Run()
        {
            return this.gatewayService.getAllData(this.apiBase);
        }

        protected override IEnumerable<T> RunFallback()
        {
            return new List<T>();
        }

    }
}
