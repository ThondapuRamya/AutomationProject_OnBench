﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Providers
{
    public class ConfigurationProvider
    {
        public static T Load<T>(string filePath) => JObject.Parse(File.ReadAllText(filePath)).ToObject<T>();
    }
}