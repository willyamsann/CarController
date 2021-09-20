using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICarService
    {
        IEnumerable<CarViewModel> SearchByFilter(string color,string brand);
    }
}
