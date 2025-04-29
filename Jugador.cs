using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPromedio1
{
    internal class Jugador
    {
        private int vida;
        private int daño;

        public Jugador( int vida, int daño)
        {
            this.vida = vida;
            this.daño = daño;
        }

        public void RecibirDaño(int cantidad)
        {
            vida -= cantidad;
            if (vida < 0) vida = 0;
        }

        public int ObtenerDaño()
        {
            return daño;
        }

        public bool EstaVivo()
        {
            return vida > 0;
        }

        public int ObtenerVida()
        {
            return vida;
        }
    }
}
