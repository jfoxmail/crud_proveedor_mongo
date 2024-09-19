using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using EmpleosTemporales.Proveedores.Api;
using EmpleosTemporales.Proveedores.Application.DataBase.Models;
using IdentityModel.Client;

namespace EmpleosTemporales.Proveedores.Test.Integracion
{
    public class ProveedoresControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProveedoresControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // Prueba de integración para el endpoint GetToken
        [Fact]
        public async Task GetToken_ReturnsOk()
        {
            // Act
            var response = await _client.GetAsync("/api/proveedores/Get-token");

            // Assert
            response.EnsureSuccessStatusCode(); // Se espera que sea un éxito
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // Prueba de integración para el endpoint Create
        [Fact]
        public async Task CreateProveedor_ReturnsUnauthorized()
        {
            // Arrange
            var proveedor = new Proveedor
            {
                NIT = "123456",
                RazonSocial = "Empresa Ejemplo",
                Direccion = "Calle 123",
                Ciudad = "Bogotá",
                Departamento = "Cundinamarca",
                Correo = "example@empresa.com",
                Activo = true,
                FechaCreacion = DateTime.Parse("2024-09-10T00:00:00Z"),
                NombreContacto = "Juan Pérez",
                CorreoContacto = "juan@empresa.com"
            };

            var content = new StringContent(JsonSerializer.Serialize(proveedor), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/proveedores/Create", content);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode); // Se espera que sea Unauthorized
        }

        // Prueba de integración para el endpoint Read-all
        [Fact]
        public async Task GetAllProveedores_ReturnsUnauthorized()
        {
            // Act
            var response = await _client.GetAsync("/api/proveedores/Read-all");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode); // Se espera que sea Unauthorized
        }

        // Prueba de integración para el endpoint Read-by-id
        [Fact]
        public async Task GetProveedorById_ReturnsUnauthorized()
        {
            // Act
            var response = await _client.GetAsync("/api/proveedores/Read-by-id/valid_id");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode); // Se espera que sea Unauthorized
        }

        // Prueba de integración para el endpoint Update
        [Fact]
        public async Task UpdateProveedor_ReturnsUnauthorized()
        {
            // Arrange
            var proveedor = new Proveedor
            {
                NIT = "654321",
                RazonSocial = "Empresa Actualizada",
                Direccion = "Calle 456",
                Ciudad = "Medellín",
                Departamento = "Antioquia",
                Correo = "nuevo@empresa.com",
                Activo = true,
                FechaCreacion = DateTime.Parse("2024-09-10T00:00:00Z"),
                NombreContacto = "Pedro Pérez",
                CorreoContacto = "pedro@empresa.com"
            };

            var content = new StringContent(JsonSerializer.Serialize(proveedor), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/proveedores/Update", content);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode); // Se espera que sea Unauthorized
        }

        // Prueba de integración para el endpoint Delete
        [Fact]
        public async Task DeleteProveedor_ReturnsUnauthorized()
        {
            // Act
            var response = await _client.DeleteAsync("/api/proveedores/Delete/valid_id");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode); // Se espera que sea Unauthorized
        }

        // Método para obtener el token de autenticación
        private async Task<string> GetAuthTokenAsync()
        {
            var response = await _client.GetAsync("/api/proveedores/Get-token");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseString);

            return tokenResponse?.AccessToken; // Ajusta esto según la estructura de tu respuesta de token
        }
    }
}
