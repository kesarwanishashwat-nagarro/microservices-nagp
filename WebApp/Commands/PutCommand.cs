﻿using Microsoft.Extensions.Options;
using Steeltoe.CircuitBreaker.Hystrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class PutCommand<T> : HystrixCommand<string>
    {
        private T body;
        private Configuration _config { get; set; }
        private string apiBase { get; set; }

        private IGatewayService<T> gatewayService;
        public PutCommand(IHystrixCommandOptions options,
            IOptions<Configuration> configSettings, IGatewayService<T> service)
            : base(options)
        {
            this._config = configSettings.Value;
            this.apiBase = this._config.GatewayUrl;
            this.gatewayService = service;
        }

        public string put(T content, string path)
        {
            this.apiBase += path;
            this.body = content;
            return Execute();
        }

        protected override string Run()
        {
            return this.gatewayService.putData(this.apiBase, this.body);
        }


        protected override string RunFallback()
        {
            return "Hey I am from Get fallback";
            //return await new Task<string>(() => "Hey I am from Get fallback");
        }

    }
}
