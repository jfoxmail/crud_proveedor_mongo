using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosTemporales.Proveedores.Application.Interfaces
{
    public interface IGetTokenJwtService
    {
        string Execute(string id);
    }
}
