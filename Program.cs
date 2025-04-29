using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPromedio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool jugar = true;

            while (jugar)
            {
                Console.Clear();

                Console.WriteLine("BIENVENIDO AL JUEGO");

                Console.WriteLine("Introduce la vida del jugador (Máximo 100): ");
                int vidaJugador = int.Parse(Console.ReadLine());
                if (vidaJugador > 100) vidaJugador = 100;

                Console.WriteLine("Introduce el daño del jugador (Máximo 100): ");
                int dañoJugador = int.Parse(Console.ReadLine());
                if (dañoJugador > 100) dañoJugador = 100;

                Jugador jugador = new Jugador(vidaJugador, dañoJugador);

                Console.WriteLine("¿Cuántas enemigos habrá?");
                int cantidadEnemigos = int.Parse(Console.ReadLine());

                List<Enemigo> enemigos = new List<Enemigo>();

                for (int i = 0; i < cantidadEnemigos; i++)
                {
                    Console.WriteLine($"Introduce la vida del enemigo {i + 1} (Máximo 100): ");
                    int vidaEnemigo = int.Parse(Console.ReadLine());
                    if (vidaEnemigo > 100) vidaEnemigo = 100;

                    Console.WriteLine($"Introduce el daño del enemigo {i + 1} (Máximo 100): ");
                    int dañoEnemigo = int.Parse(Console.ReadLine());
                    if (dañoEnemigo > 100) dañoEnemigo = 100;

                    enemigos.Add(new Enemigo(vidaEnemigo, dañoEnemigo));
                }

                bool partidaEnCurso = true;

                while(partidaEnCurso)
                {
                    Console.WriteLine("Tu vida actual es: " + jugador.ObtenerVida());
                    Console.WriteLine("Enemigos vivos");

                    for(int i = 0;i < enemigos.Count;i++)
                    {
                        if (enemigos[i].Estavivo())
                        {
                            Console.WriteLine($"[{i}] Enemigo {i + 1} - Vida: {enemigos[i].ObtenerVida()}");
                        }
                    }

                    Console.WriteLine("¿A qué enemigo quieres atacar?");
                    int objetivo = int.Parse(Console.ReadLine());

                    if(objetivo >= 0 && objetivo < enemigos.Count && enemigos[objetivo].Estavivo())
                    {
                        enemigos[objetivo].RecibirDaño(jugador.ObtenerDaño());
                        Console.WriteLine("Atacaste al enemigo");

                        if (!enemigos[objetivo].Estavivo())
                        {
                            Console.WriteLine($"El enemigo {objetivo + 1} ha sido derrotado");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Ese enemigo no está disponible para atacar.");
                    }

                    bool enemigosVivos = false;
                    foreach(var enemigo in enemigos)
                    {
                        if(enemigo.Estavivo())
                        {
                            enemigosVivos = true;break;
                        }
                    }

                    if(!enemigosVivos)
                    {
                        Console.WriteLine("Has ganado la partida");
                        partidaEnCurso = false;break;
                    }

                    Random random = new Random();
                    int enemigoQueAtaca = random.Next(enemigos.Count);

                    while (!enemigos[enemigoQueAtaca].Estavivo())
                    {
                        enemigoQueAtaca = random.Next(enemigos.Count);
                    }

                    Console.WriteLine($"El enemigo {enemigoQueAtaca + 1} te ataca");
                    jugador.RecibirDaño(enemigos[enemigoQueAtaca].ObtenerDaño());

                    if(!jugador.EstaVivo())
                    {
                        Console.WriteLine("Has sido derrotado");
                        partidaEnCurso = false ;break;
                    }
                }

                Console.WriteLine("¿Quieres jugar otra partida? (si/no)");
                string respuesta = Console.ReadLine();

                if(respuesta.ToLower() != "si")
                {
                    jugar = false;
                }
            }
        }
    }
}
