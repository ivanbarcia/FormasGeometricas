namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        int Tipo { get; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}