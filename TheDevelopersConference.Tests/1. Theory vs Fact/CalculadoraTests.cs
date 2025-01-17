﻿using TheDevelopersConference.Demonstracao.Calculadora;
using Xunit;

namespace TheDevelopersConference.Tests.TheoryVSFact
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(4, 2, 6)]
        [InlineData(7, 3, 10)]
        [InlineData(9, 9, 18)]
        public void Calculadora_Somar_RetornarValoresSoma(double v1, double v2, double total)
        {
            //AAA
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(v1, v2);

            // Assert
            Assert.Equal(total, resultado);
        }      

        [Fact]
        public void Calculadora_Dividir_RetornarValorDivisao()
        {
            //// Arrange
            var calculadora = new Calculadora();

            //// Act
            var resultado = calculadora.Dividir(2, 2);

            //// Assert
            Assert.Equal(1, resultado);
        }
    }
}
