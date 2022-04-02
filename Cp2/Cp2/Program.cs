using System;

namespace Cp2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre: ");
            String nombre = Console.ReadLine();
            
            Console.WriteLine("Ingrese su DUI: ");
            String dui = Console.ReadLine();

            Votante votante = new Votante(nombre, dui);

            bool continuar = true;
            do
            {
                Console.Write("Desea votar por a o b? (a/b): ");
                char opcion = Console.ReadLine()[0];

                switch (opcion)
                {
                    case 'a':
                        Urna.votar(votante, 'a');
                        break;
                    case 'b':
                        Urna.votar(votante, 'b');
                        break;
                    default:
                        continuar = false;
                        break;
                }
            } while (continuar);
            
            Console.WriteLine( Urna.Ganador());
        }
    }

    public class Votante
    {
        public string nombre { get; set; }
        public string dui { get; set; }

        public Votante(string nombre, string dui)
        {
            this.nombre = nombre;
            this.dui = dui;
        }
    }

    public static class Urna
    {
        private static int VotosA = 0;
        private static int VotosB = 0;
        
        public static void votar(Votante x, char partido)
        {
            Console.WriteLine("Voto de" + x.nombre);
            if (partido == 'a')
            {
                VotosA++;
            }
            else
            {
                VotosB++;
            }
        }

        public static string Ganador(){
            if (VotosA > VotosB)
            {
                return "Ganador es el partido A";
            }
            else if (VotosA < VotosB)
            {
                return "Ganador es el partido B";
            }
            else
            {
                return "Hubo empate :) ";
            }
        }
    }
}
