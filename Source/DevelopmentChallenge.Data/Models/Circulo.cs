using System;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Models
{
    public class Circulo : IFormaGeometrica
    {
        public int Tipo => (int)Enums.Tipo.Circulo;
        private decimal Radio { get; }

        public Circulo(decimal radio)
        {
            Radio = radio;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (Radio / 2) * (Radio / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Radio;
        }
    }
}