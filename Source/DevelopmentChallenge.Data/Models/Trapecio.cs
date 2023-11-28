using System;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Models
{
    public class Trapecio : IFormaGeometrica
    {
        public int Tipo => (int)Enums.Tipo.Trapecio;
        private decimal Base1 { get; }
        private decimal Base2 { get; }
        private decimal Alto { get; }
        private decimal Lado1 { get; }
        private decimal Lado2 { get; }

        public Trapecio(decimal base1, decimal base2, decimal alto, decimal lado1, decimal lado2)
        {
            Base1 = base1;
            Base2 = base2;
            Alto = alto;
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public decimal CalcularArea()
        {
            return 0.5m * Alto * (Base1 + Base2);
        }

        public decimal CalcularPerimetro()
        {
            return Lado1 + Base1 + Base2 + Lado2;
        }
    }
}