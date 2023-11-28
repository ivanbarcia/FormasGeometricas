/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO:
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo.
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                ListaVacia(idioma, sb);
            }
            else
            {
                // Header
                CultureInfo culture;
                string formato;

                culture = AgregarHeader(idioma, sb, out formato);

                var resumenFormas = CalcularFormas(formas, idioma, sb, formato, culture);

                // Footer
                AgregarFooter(idioma, sb, resumenFormas, formato, culture);
            }

            return sb.ToString();
        }

        #region Private Methods
        private static void AgregarFooter(int idioma, StringBuilder sb, Dictionary<int, (int count, decimal area, decimal perimeter)> resumenFormas, string formato,
            CultureInfo culture)
        {
            sb.Append($"TOTAL:<br/>{resumenFormas.Sum(s => s.Value.count)} {Traducciones.GetFormaPlural(idioma)} ");
            sb.Append(
                $"{Traducciones.GetPerimetroLabel(idioma)}{FormatNumber(resumenFormas.Sum(s => s.Value.perimeter), formato, culture)} ");
            sb.Append($"Area {FormatNumber(resumenFormas.Sum(s => s.Value.area), formato, culture)}");
        }

        private static Dictionary<int, (int count, decimal area, decimal perimeter)> CalcularFormas(List<IFormaGeometrica> formas, int idioma, StringBuilder sb, string formato, CultureInfo culture)
        {
            var resumenFormas = new Dictionary<int, (int count, decimal area, decimal perimeter)>();

            foreach (var forma in formas)
            {
                if (!resumenFormas.ContainsKey(forma.Tipo))
                {
                    resumenFormas[forma.Tipo] = (0, 0m, 0m);
                }

                var (count, area, perimeter) = resumenFormas[forma.Tipo];

                count++;
                area += forma.CalcularArea();
                perimeter += forma.CalcularPerimetro();

                resumenFormas[forma.Tipo] = (count, area, perimeter);
            }

            foreach (var kvp in resumenFormas)
            {
                sb.Append(Traducciones.ObtenerLinea(kvp.Value.count, FormatNumber(kvp.Value.area, formato, culture),
                    FormatNumber(kvp.Value.perimeter, formato, culture), kvp.Key, idioma));
            }

            return resumenFormas;
        }

        private static CultureInfo AgregarHeader(int idioma, StringBuilder sb, out string formato)
        {
            CultureInfo culture;
            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    sb.Append("<h1>Reporte de Formas</h1>");
                    culture = new CultureInfo("es-ES");
                    formato = "N2";
                    break;
                case (int)Idioma.Italiano:
                    sb.Append("<h1>Rapporto delle forme</h1>");
                    culture = new CultureInfo("it-IT");
                    formato = "N2"; // Adjust format if needed
                    break;
                default:
                    sb.Append("<h1>Shapes report</h1>");
                    culture = new CultureInfo("en-US");
                    formato = "#.##";
                    break;
            }

            return culture;
        }

        private static void ListaVacia(int idioma, StringBuilder sb)
        {
            switch (idioma)
            {
                case (int)Idioma.Castellano:
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                    break;
                case (int)Idioma.Italiano:
                    sb.Append("<h1>Elenco vuoto di forme!</h1>");
                    break;
                default:
                    sb.Append("<h1>Empty list of shapes!</h1>");
                    break;
            }
        }

        private static string FormatNumber(decimal numero, string formato, CultureInfo culture)
        {
            var formattedNumber = numero.ToString(formato, culture);
            if (formattedNumber.EndsWith(".00") || formattedNumber.EndsWith(",00"))
            {
                formattedNumber = numero.ToString("N0", culture);
            }
            else if (formattedNumber.EndsWith(".0") || formattedNumber.EndsWith(",0"))
            {
                formattedNumber = numero.ToString("N1", culture);
            }
            return formattedNumber;
        }
        #endregion
    }
}