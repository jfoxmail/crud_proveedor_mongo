using AutoMapper;
using EmpleosTemporales.Proveedores.Application.DataBase.Models;
using EmpleosTemporales.Proveedores.Domain.Entities.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosTemporales.Proveedores.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ProveedorEntity, Proveedor>().ReverseMap();
        }


    }
}
