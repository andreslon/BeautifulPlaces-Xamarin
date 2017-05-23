using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Resources
{
    public static class LocalizedStrings
    {
        public static string Get(string key)
        {
            return AppResource.ResourceManager.GetString(key);
        }
    }
}
