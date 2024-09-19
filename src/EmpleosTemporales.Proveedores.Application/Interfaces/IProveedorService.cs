using EmpleosTemporales.Proveedores.Application.DataBase.Models;
using EmpleosTemporales.Proveedores.Domain.Entities.Proveedor;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosTemporales.Proveedores.Application.Interfaces
{
    public interface IProveedorService
    {
        public Task<IEnumerable<Proveedor>> ObtenerProveedores();
        public Task<Proveedor> ObtenerProveedorPorId(string id);
        public Task<Proveedor?> CrearProveedor(Proveedor proveedor);
        public Task<Proveedor?> ActualizarProveedor(Proveedor proveedor);
        public Task<bool> EliminarProveedor(string id);
        
    }
}
