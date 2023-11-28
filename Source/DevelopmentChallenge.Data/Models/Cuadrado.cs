using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Models
{
    public class Cuadrado : IFormaGeometrica
    {
        public int Tipo => (int)Enums.Tipo.Cuadrado;
        private decimal Lado { get; }

        public Cuadrado(decimal lado)
        {
            Lado = lado;
        }

        public decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return 4 * Lado;
        }
    }
}