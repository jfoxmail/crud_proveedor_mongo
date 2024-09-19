using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosTemporales.Proveedores.Application.DataBase.Models
{
    public class Proveedor
    {        
        public string Id { get; set; }        
        public string NIT { get; set; }        
        public string RazonSocial { get; set; }        
        public string Direccion { get; set; }        
        public string Ciudad { get; set; }        
        public string Departamento { get; set; }        
        public string Correo { get; set; }        
        public bool Activo { get; set; }        
        public DateTime FechaCreacion { get; set; }        
        public string NombreContacto { get; set; }        
        public string CorreoContacto { get; set; }
    }
}
