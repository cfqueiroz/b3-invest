using Xunit;
using calculo_b3.Models;
using calculo_b3.Services;

namespace calculo_b3.Tests.Services
{
    public class CdbServiceTests
    {
        private readonly CdbService _service;

        public CdbServiceTests()
        {
            _service = new CdbService();
        }

        [Fact]
        public void CalculaCDB_ShouldReturnError_WhenValorInicialIsZero()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = 0, Meses = 12 };

            // Act
            var response = _service.CalculaCDB(request);

            // Assert
            Assert.True(response.Erro);
            Assert.Equal("Valor inicial deve ser positivo.", response.MsgErro);
        }

        [Fact]
        public void CalculaCDB_ShouldReturnError_WhenValorInicialIsNegative()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = -100, Meses = 12 };

            // Act
            var response = _service.CalculaCDB(request);

            // Assert
            Assert.True(response.Erro);
            Assert.Equal("Valor inicial deve ser positivo.", response.MsgErro);
        }

        [Fact]
        public void CalculaCDB_ShouldReturnError_WhenMesesIsOne()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = 1000, Meses = 1 };

            // Act
            var response = _service.CalculaCDB(request);

            // Assert
            Assert.True(response.Erro);
            Assert.Equal("Prazo deve ser maior que 1.", response.MsgErro);
        }

        [Fact]
        public void CalculaCDB_ShouldReturnCorrectValues_WhenRequestIsValid()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = 1000, Meses = 12 };

            // Act
            var response = _service.CalculaCDB(request);

            // Assert
            Assert.False(response.Erro);
            Assert.True(response.ValorBruto > request.ValorInicial);
            Assert.True(response.ValorLiquido < response.ValorBruto);
        }
    }
}
