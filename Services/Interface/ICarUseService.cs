using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICarUseService
    {
        IEnumerable<CarUseViewModel> GetAll();
        CarUseViewModel GetById(int id);

        CarUseViewModel GetByDriverId(int idDriver);

        CarUseViewModel CreateRegister(CarUseViewModel obj);

        CarUseViewModel Finished(int id);
    }
}
