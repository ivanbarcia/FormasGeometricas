using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Traducciones
    {
        public static string ObtenerLinea(int cantidad, string area, string perimetro, int tipo, int idioma)
        {
            if (cantidad <= 0) return string.Empty;

            string areaLabel;
            string perimetroLabel;

            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    areaLabel = "Area";
                    perimetroLabel = "Perimetro";
                    break;
                case (int)Idioma.Italiano:
                    areaLabel = "Settore";
                    perimetroLabel = "Perimetro";
                    break;
                default:
                    areaLabel = "Area";
                    perimetroLabel = "Perimeter";
                    break;
            }

            return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | {areaLabel} {area} | {perimetroLabel} {perimetro} <br/>";
        }

        public static string GetFormaPlural(int idioma)
        {
            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    return "formas";
                case (int)Idioma.Italiano:
                    return "forme";
                default:
                    return "shapes";
            }
        }

        public static string GetPerimetroLabel(int idioma)
        {
            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    return "Perimetro ";
                case (int)Idioma.Italiano:
                    return "Perimetro ";
                default:
                    return "Perimeter ";
            }
        }

        #region Private Methods
        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case (int)Tipo.Cuadrado:
                    return GetTranslation("Cuadrado", "Square", "Quadrato", cantidad, idioma);
                case (int)Tipo.Circulo:
                    return GetTranslation("Círculo", "Circle", "Cerchio", cantidad, idioma);
                case (int)Tipo.TrianguloEquilatero:
                    return GetTranslation("Triángulo", "Triangle", "Triangolo", cantidad, idioma);
                case (int)Tipo.Rectangulo:
                    return GetTranslation("Rectangulo", "Rectangle", "Rettangolo", cantidad, idioma);
                case (int)Tipo.Trapecio:
                    return GetTranslation("Trapecio", "Trapeze", "Trapezio", cantidad, idioma);
            }

            return string.Empty;
        }

        private static string GetTranslation(string singularES, string singularEN, string singularIT, int cantidad, int idioma)
        {
            string singular;
            string plural;

            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    singular = singularES;
                    plural = cantidad == 1 ? singularES : singularES + "s";
                    break;
                case (int)Idioma.Italiano:
                    singular = singularIT;
                    plural = cantidad == 1 ? singularIT : singularIT + "s";
                    break;
                default:
                    singular = singularEN;
                    plural = cantidad == 1 ? singularEN : singularEN + "s";
                    break;
            }

            return cantidad == 1 ? singular : plural;
        }
        #endregion
    }
}