﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Oppo.ObjectModel
{
    public class OpcuaServerApp : IOpcuaServerApp
    {
        public OpcuaServerApp()
        {
        }

        public OpcuaServerApp(string name, string url, string port)
        {
            Name = name;
            Url = url;
			Port = port;
        }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

		[JsonProperty("type")]
		public string Type { get; set;  } = Constants.ApplicationType.Server;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

		[JsonProperty("port")]
		public string Port { get; set; } = string.Empty;
        
    }
}