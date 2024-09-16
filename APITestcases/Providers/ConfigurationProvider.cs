using APITestcases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestcases.Providers
{
    internal class ConfigurationProvider :APICore.Providers.ConfigurationProvider
    {
        const string filePath = @"..\..\..\TestSettings.json";
        protected static string fullPath= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath); 

        public static APIDetails apiDetails => Load<APIDetails>(fullPath);
        
    }
}
