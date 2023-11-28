using System;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Models
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        public int Tipo => (int)Enums.Tipo.TrianguloEquilatero;
        private decimal Lado { get; }

        public TrianguloEquilatero(decimal lado)
        {
            Lado = lado;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}