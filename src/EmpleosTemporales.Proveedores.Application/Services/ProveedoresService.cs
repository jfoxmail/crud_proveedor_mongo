using AutoMapper;
using EmpleosTemporales.Proveedores.Application.DataBase;
using EmpleosTemporales.Proveedores.Application.DataBase.Models;
using EmpleosTemporales.Proveedores.Application.Interfaces;
using EmpleosTemporales.Proveedores.Domain.Entities.Proveedor;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace EmpleosTemporales.Proveedores.Application.Services
{
    public class ProveedoresService : IProveedorService
    {
        private readonly IMongoCollection<ProveedorEntity> _proveedores;
        private readonly IMapper _mapper;
        public ProveedoresService(MongoDbService mongoDbService, IMapper mapper)
        {
            _proveedores = mongoDbService.Database?.GetCollection<ProveedorEntity>("Proveedor");
            _mapper = mapper;
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedores()
        {
            List<ProveedorEntity> proveedoresEntity = await _proveedores.Find(FilterDefinition<ProveedorEntity>.Empty).ToListAsync();            
            return _mapper.Map<List<Proveedor>>(proveedoresEntity);            
        }

        public async Task<Proveedor> ObtenerProveedorPorId(string id)
        {
            var filter = Builders<ProveedorEntity>.Filter.Eq(x => x.Id, id);
            var proveedorItem = await _proveedores.Find(filter).FirstOrDefaultAsync();           
            return _mapper.Map<Proveedor>(proveedorItem);
        }

        public async Task<Proveedor?> CrearProveedor(Proveedor proveedor)
        {
            ProveedorEntity proveedorEntity = _mapper.Map<ProveedorEntity>(proveedor);
            await _proveedores.InsertOneAsync(proveedorEntity);
            return _mapper.Map<Proveedor>(proveedorEntity);
        }

        public async Task<Proveedor?> ActualizarProveedor(Proveedor proveedor)
        {
            ProveedorEntity proveedorEntity = _mapper.Map<ProveedorEntity>(proveedor);
            var filter = Builders<ProveedorEntity>.Filter.Eq("Id", proveedorEntity.Id);
            await _proveedores.ReplaceOneAsync(filter, proveedorEntity);
            return _mapper.Map<Proveedor>(proveedorEntity);
        }

        public async Task<bool> EliminarProveedor(string id)
        {
            var filter = Builders<ProveedorEntity>.Filter.Eq("Id", id);
            await _proveedores.DeleteOneAsync(filter);
            var proveedor = _proveedores.Find(filter).FirstOrDefaultAsync();
            return true;
        }
    }
}
