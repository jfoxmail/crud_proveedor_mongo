using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosTemporales.Proveedores.Domain.Entities.Proveedor
{
    public class ProveedorEntity
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nit"), BsonRepresentation(BsonType.String)]
        public string NIT { get; set; }
        [BsonElement("razon_social"), BsonRepresentation(BsonType.String)]
        public string RazonSocial { get; set; }
        [BsonElement("direccion"), BsonRepresentation(BsonType.String)]
        public string Direccion { get; set; }
        [BsonElement("ciudad"), BsonRepresentation(BsonType.String)]
        public string Ciudad { get; set; }
        [BsonElement("departamento"), BsonRepresentation(BsonType.String)]
        public string Departamento { get; set; }
        [BsonElement("correo"), BsonRepresentation(BsonType.String)]
        public string Correo { get; set; }
        [BsonElement("activo"), BsonRepresentation(BsonType.Boolean)]
        public bool Activo { get; set; }
        [BsonElement("fecha_creacion"), BsonRepresentation(BsonType.DateTime)]
        public DateTime FechaCreacion { get; set; }
        [BsonElement("nombre_contacto"), BsonRepresentation(BsonType.String)]
        public string NombreContacto { get; set; }
        [BsonElement("correo_contacto"), BsonRepresentation(BsonType.String)]
        public string CorreoContacto { get; set; }
        

    }
}
