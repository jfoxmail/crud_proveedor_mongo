using EmpleosTemporales.Proveedores.Api.Controllers;
using EmpleosTemporales.Proveedores.Application.Services;

namespace EmpleosTemporales.Proveedores.Test.Unitarias
{
    using System.Threading.Tasks;
    using Xunit;
    using Moq;
    using Microsoft.AspNetCore.Mvc;
    using global::EmpleosTemporales.Proveedores.Application.DataBase.Models;
    using global::EmpleosTemporales.Proveedores.Application.Interfaces;
    using global::EmpleosTemporales.Proveedores.Api.Controllers;

    namespace EmpleosTemporales.Tests
    {
        public class ProveedoresControllerTest
        {
            private readonly Mock<IProveedorService> _proveedorServiceMock;
            private readonly Mock<IGetTokenJwtService> _getTokenJwtServiceMock;
            private readonly ProveedoresController _controller;

            public ProveedoresControllerTest()
            {
                _proveedorServiceMock = new Mock<IProveedorService>();
                _getTokenJwtServiceMock = new Mock<IGetTokenJwtService>();
                _controller = new ProveedoresController();
            }

            [Fact]
            public async Task GetToken_ReturnsOkResult_WithValidToken()
            {
                // Arrange
                var expectedToken = "valid_token";
                _getTokenJwtServiceMock.Setup(s => s.Execute(It.IsAny<string>())).Returns(expectedToken);

                // Act
                var result = await _controller.GetToken(_getTokenJwtServiceMock.Object);

                // Assert
                var okResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode);
            }

            [Fact]
            public async Task GetToken_Returns204NoContent_WhenTokenIsNull()
            {
                // Arrange
                _getTokenJwtServiceMock.Setup(s => s.Execute(It.IsAny<string>())).Returns((string)null);

                // Act
                var result = await _controller.GetToken(_getTokenJwtServiceMock.Object);

                // Assert
                var noContentResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(204, noContentResult.StatusCode);
            }

            [Fact]
            public async Task Create_ReturnsOkResult_WithValidProveedor()
            {
                // Arrange
                var proveedor = new Proveedor();
                _proveedorServiceMock.Setup(s => s.CrearProveedor(proveedor)).ReturnsAsync(proveedor);

                // Act
                var result = await _controller.Create(proveedor, _proveedorServiceMock.Object);

                // Assert
                var okResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode);
            }

            [Fact]
            public async Task Create_Returns204NoContent_WhenProveedorIsNull()
            {
                // Arrange
                Proveedor nullProveedor = null;
                _proveedorServiceMock.Setup(s => s.CrearProveedor(It.IsAny<Proveedor>())).ReturnsAsync(nullProveedor);

                // Act
                var result = await _controller.Create(new Proveedor(), _proveedorServiceMock.Object);

                // Assert
                var noContentResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(204, noContentResult.StatusCode);
            }

            [Fact]
            public async Task GetById_ReturnsOkResult_WithValidId()
            {
                // Arrange
                var proveedor = new Proveedor();
                _proveedorServiceMock.Setup(s => s.ObtenerProveedorPorId("valid_id")).ReturnsAsync(proveedor);

                // Act
                var result = await _controller.GetById("valid_id", _proveedorServiceMock.Object);

                // Assert
                var okResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode);
            }

            [Fact]
            public async Task GetById_Returns204NoContent_WhenProveedorIsNull()
            {
                // Arrange
                Proveedor nullProveedor = null;
                _proveedorServiceMock.Setup(s => s.ObtenerProveedorPorId("valid_id")).ReturnsAsync(nullProveedor);

                // Act
                var result = await _controller.GetById("valid_id", _proveedorServiceMock.Object);

                // Assert
                var noContentResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(204, noContentResult.StatusCode);
            }

            [Fact]
            public async Task Delete_ReturnsOkResult_WhenProveedorDeleted()
            {
                // Arrange
                _proveedorServiceMock.Setup(s => s.EliminarProveedor("valid_id")).ReturnsAsync(true);

                // Act
                var result = await _controller.Delete("valid_id", _proveedorServiceMock.Object);

                // Assert
                var okResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode);
            }

            [Fact]
            public async Task Delete_Returns204NoContent_WhenProveedorNotDeleted()
            {
                // Arrange
                _proveedorServiceMock.Setup(s => s.EliminarProveedor("valid_id")).ReturnsAsync(false);

                // Act
                var result = await _controller.Delete("valid_id", _proveedorServiceMock.Object);

                // Assert
                var noContentResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(204, noContentResult.StatusCode);
            }
        }
    }
}
