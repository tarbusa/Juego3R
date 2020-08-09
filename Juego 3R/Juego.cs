using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_3R
{
    class Juego
    {

        private string[] vs = new string[10];
        private string gamer;
        public Juego()
        {
            iniciar();
            gamer = "NADIE";
        }

        private void iniciar()
        {
            vs[0] = "a";
            vs[1] = "a";
            vs[2] = "a";

            vs[3] = "0";
            vs[4] = "0";
            vs[5] = "0";

            vs[6] = "r";
            vs[7] = "r";
            vs[8] = "r";

        }
        public void updatePos(int nPosUpdate, int nPosAnterior, string color)
        {
            vs[nPosUpdate] = color;
            vs[nPosAnterior] = "0";
        }

        public string ganador()
        {
            if (vs[0] == "r" && vs[3] == "r" && vs[6] == "r") { gamer = "rojo"; }
            if (vs[1] == "r" && vs[4] == "r" && vs[7] == "r") { gamer = "rojo"; }
            if (vs[2] == "r" && vs[5] == "r" && vs[8] == "r") { gamer = "rojo"; }
            if (vs[3] == "r" && vs[4] == "r" && vs[5] == "r") { gamer = "rojo"; }
            if (vs[0] == "r" && vs[1] == "r" && vs[2] == "r") { gamer = "rojo"; }
            if (vs[0] == "r" && vs[4] == "r" && vs[8] == "r") { gamer = "rojo"; }
            if (vs[2] == "r" && vs[4] == "r" && vs[6] == "r") { gamer = "rojo"; }

            if (vs[0] == "a" && vs[3] == "a" && vs[6] == "a") { gamer = "amarillo"; }
            if (vs[1] == "a" && vs[4] == "a" && vs[7] == "a") { gamer = "amarillo"; }
            if (vs[2] == "a" && vs[5] == "a" && vs[8] == "a") { gamer = "amarillo"; }
            if (vs[3] == "a" && vs[4] == "a" && vs[5] == "a") { gamer = "amarillo"; }
            if (vs[6] == "a" && vs[7] == "a" && vs[8] == "a") { gamer = "amarillo"; }
            if (vs[0] == "a" && vs[4] == "a" && vs[8] == "a") { gamer = "amarillo"; }
            if (vs[2] == "a" && vs[4] == "a" && vs[6] == "a") { gamer = "amarillo"; }

            return gamer;
        }
        public void reset()
        {
            iniciar();
            gamer = "NADIE";
        }
    }
        
}
