using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Models
{
    public class Rectangulo : IFormaGeometrica
    {
        public int Tipo => (int)Enums.Tipo.Rectangulo;
        private decimal Ancho { get; }
        private decimal Largo { get; }

        public Rectangulo(decimal ancho, decimal largo)
        {
            Ancho = ancho;
            Largo = largo;
        }

        public decimal CalcularArea()
        {
            return Ancho * Largo;
        }

        public decimal CalcularPerimetro()
        {
            return 2 * (Ancho + Largo);
        }
    }
}