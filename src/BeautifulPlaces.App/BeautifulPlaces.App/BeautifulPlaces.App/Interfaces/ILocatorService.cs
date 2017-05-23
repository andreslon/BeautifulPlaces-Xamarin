using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulPlaces.App.Interfaces
{
    public interface ILocatorService
    {
        T Get<T>() where T : class;
    }
}
