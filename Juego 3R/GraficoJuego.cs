using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using InputKey;

namespace Juego_3R
{
    public partial class GraficoJuego : Form
    {
        
        private string botonPress;
        private int x;
        private int y; 
        private Juego juego;
        private string color;
        private string siguienteTurno;
        //private string jugadorAmarillo;
        //private string jugadorRojo;
        private string turnoInicial;
        private string turno;
        private int ptjeAma;
        private int ptjeRojo;
        public GraficoJuego()
        {
            
            InitializeComponent();
            posInicialBotontes();
            this.botonPress = "0";
            color = "0";
            x = 0;
            y = 0;
            juego = new Juego();
            numeroRandom();
            siguienteTurno = turno;
            //jugadorAmarillo = "PLAYER A";
            //jugadorRojo = "PLAYER B";
            iniciarTurno(turno);
            nameAmarillo.Text = "JUGADOR 1";
            nameRojo.Text = "JUGADOR 2";
            turnoInicial = turno;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void numeroRandom()
        {
            Random ran = new Random();
            int num = ran.Next(1,3);
            if (num == 1) { turno = "a"; }
            if (num == 2) { turno = "r"; }
        }

        private void iniciarTurno(string colorTurno)
        {
            if (colorTurno == "a") { flechaRoja.Visible = false; flechaAma.Visible = true; }
            if (colorTurno == "r") { flechaAma.Visible = false; flechaRoja.Visible = true; }
        }


        private void posInicialBotontes()
        {
            //POSICION INICIAL DE TODOS LOS BOTONES
            // LEFT = X
            // TOP = Y 

            /*-----------------BOTONES ROJOS----------------*/

            ///BOTON ROJO 1
            botonRojo1.Left =13;
            botonRojo1.Top = 415;

            //BOTON ROJO 2
            botonRojo2.Left = 214;
            botonRojo2.Top = 415;

            //BOTON ROJO 3
            botonRojo3.Left = 417;
            botonRojo3.Top = 415;

            /*-----------------BOTONES AMARILLOS----------------*/
            
            //BOTON AMARILLO 1
            botonAma1.Left = 13;
            botonAma1.Top = 12;

            //BOTON AMARILLO 2
            botonAma2.Left = 214;
            botonAma2.Top = 12;

            //BOTON AMARILLO 3
            botonAma3.Left = 417;
            botonAma3.Top = 12;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            botonAma1.Left = 13;  //X
            botonAma1.Top = 215;  //Y
            */
        }

        private void botonAma1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void botonAma1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void botonAma1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reiniciar();
        }

        private void reiniciar()
        {
            posInicialBotontes();
            juego.reset();
            //iniciarTurno(siguienteTurno);
            iniciarTurno(turnoInicial);
            siguienteTurno = turnoInicial;
            escojeTurno.Enabled = true;
            
    }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {
                nAnterior = buscarPosAnterior();
                juego.updatePos(4, nAnterior, color);
                posicionarse(214, 211);
                verGanador();
                turnoFlechas();
            }



            //pantalla.Text = juego.ganador();
            ///////4444444444444444444

        }

        private void btnPos4_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {
                //CONDICIONES PARA QUE LA FICHA NO SE MUEVA A UN LUGAR QUE NO LE CORRESPONDE
                if ((x == 13 && y == 12) || (x == 214 && y == 211) || (x == 13 && y == 415))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(3, nAnterior, color);
                    posicionarse(13, 215);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                    
                }
                
            }
            ////33333333333333
        }
        private void verGanador()
        {
            if (juego.ganador() == "amarillo")
            {
                MessageBox.Show("'"+nameAmarillo.Text+"'" + " GANA");
                reiniciar();
                ptjeAma ++; //AUMENTO EL PUNTAJE DEL JUGADOR AMARILLO
                puntajes();
                return;
            }
            if (juego.ganador() == "rojo")
            {
                MessageBox.Show("'"+nameRojo.Text+"'" + " GANA");
                reiniciar();
                ptjeRojo ++; //AUMENTO EL PUNTAJE DEL JUGADOR ROJO
                puntajes();
                return;
            }
        }
        private void puntajes()
        {
            if (ptjeRojo < 10)
            {
                lblPuntajeRojo.Text = "0"+Convert.ToString(ptjeRojo);
            }
            if(ptjeRojo >= 10)
            {
                lblPuntajeRojo.Text = Convert.ToString(ptjeRojo);
            }
            if(ptjeAma < 10)
            {
                lblPuntajeAma.Text = "0" + Convert.ToString(ptjeAma);
            }
            if(ptjeAma >= 10)
            {
                lblPuntajeAma.Text = Convert.ToString(ptjeAma);
            }
        }
       
        private int buscarPosAnterior()
        {
            int retorno = 0;
            if (x == 13  && y == 12 ) { retorno = 0; }
            if (x == 214 && y == 12 ) { retorno = 1; }
            if (x == 417 && y == 12 ) { retorno = 2; }
            if (x == 13  && y == 215) { retorno = 3; }
            if (x == 214 && y == 211) { retorno = 4; }
            if (x == 417 && y == 213) { retorno = 5; }
            if (x == 13  && y == 415) { retorno = 6; }
            if (x == 214 && y == 415) { retorno = 7; }
            if (x == 417 && y == 415) { retorno = 8; }
            return retorno;
        }

        private void posicionarse(int x, int y)
        {
            
            /*-------botones amarillos-----*/
            if (botonPress == "1A")
            {
                botonAma1.Left = x;
                botonAma1.Top = y;
            }
            if (botonPress == "2A")
            {
                botonAma2.Left = x;
                botonAma2.Top = y;
            }
            if (botonPress == "3A")
            {
                botonAma3.Left = x;
                botonAma3.Top = y;
            }
            
            /*-------botones rojos-----*/
            if (botonPress == "1R")
            {
                botonRojo1.Left = x;
                botonRojo1.Top = y;
            }
            if (botonPress == "2R")
            {
                botonRojo2.Left = x;
                botonRojo2.Top = y;
            }
            if (botonPress == "3R")
            {
                botonRojo3.Left = x;
                botonRojo3.Top = y;
            }
            
            botonPress = "0";
            //pantalla.Text = "0";
            escojeTurno.Enabled = false;
        }

        private void btnPos7_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {

                if ((x == 13 && y == 215) || (x == 214 && y == 211) || (x == 214 && y == 12))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(0, nAnterior, color);

                    posicionarse(13, 12);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }
            //////00000000000000000
        }

        private void botonAma1_Click(object sender, EventArgs e)
        {
            botonPress = "1A";
            //pantalla.Text = "1AMA";
            color = "a";
            x = botonAma1.Left;
            y = botonAma1.Top;
            
            //txtX.Text = Convert.ToString(x);
            //txtY.Text = Convert.ToString(y);



        }
        

        private void botonAma2_Click(object sender, EventArgs e)
        {
            botonPress = "2A";
            //pantalla.Text = "2AMA";
            color = "a";
            x = botonAma2.Left;
            y = botonAma2.Top;

            //txtX.Text = Convert.ToString(x);
            //txtY.Text = Convert.ToString(y);
        }

        private void botonAma3_Click(object sender, EventArgs e)
        {
            botonPress = "3A";
            //pantalla.Text = "3AMA";
            color = "a";
            x = botonAma3.Left;
            y = botonAma3.Top;

            //txtX.Text = Convert.ToString(x);
            //txtY.Text = Convert.ToString(y);
        }

        private void btnPos6_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {

                if ((x == 417 && y == 12) || (x == 417 && y == 415) || (x == 214 && y == 211))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(5, nAnterior, color);
                    posicionarse(417, 213);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }

            ///555555555555555555

        }
        private void turnoFlechas()
        {
            if (color == "a")
            {
                siguienteTurno = "r";
                flechaAma.Visible = false;
                flechaRoja.Visible = true;
            }
            if (color == "r")
            {
                siguienteTurno = "a";
                flechaRoja.Visible = false;
                flechaAma.Visible = true;
            }
        }

        private void botonRojo1_Click(object sender, EventArgs e)
        {
            botonPress = "1R";
            //pantalla.Text = "1rojo";
            color = "r";
            x = botonRojo1.Left;
            y = botonRojo1.Top;

            //txtX.Text = Convert.ToString(x);
            //txtY.Text = Convert.ToString(y);

        }

        
        private void botonRojo2_Click(object sender, EventArgs e)
        {
            botonPress = "2R";
            //pantalla.Text = "2rojo";
            color = "r";
            x = botonRojo2.Left;
            y = botonRojo2.Top;

            //txtX.Text = Convert.ToString(x);
            //txtY.Text = Convert.ToString(y);

        }

        private void botonRojo3_Click(object sender, EventArgs e)
        {
            botonPress = "3R";
            //pantalla.Text = "3rojo";
            color = "r";
            x = botonRojo3.Left;
            y = botonRojo3.Top;

            //txtX.Text = Convert.ToString(x);
            //txtY.Text = Convert.ToString(y);

        }

        private void btnPos8_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {

                if ((x == 13 && y == 12) || (x == 214 && y == 211) || (x == 417 && y == 12))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(1, nAnterior, color);
                    posicionarse(214, 12);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }


            //111111111111111111
        }

        private void btnPos9_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {
                if ((x == 214 && y == 12) || (x == 417 && y == 213) || (x == 214 && y == 211))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(2, nAnterior, color);
                    posicionarse(417, 12);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }


            //22222222222222222222222222222
            
        }

        private void btnPos1_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {
                if ((x == 13 && y == 215) || (x == 214 && y == 211) || (x == 214 && y == 415))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(6, nAnterior, color);
                    posicionarse(13, 415);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }
            

            //66666666666666666666666
            
        }

        private void btnPos2_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;
            
            if (color == siguienteTurno)
            {
                if ((x == 13 && y == 415) || (x == 214 && y == 211) || (x == 417 && y == 415))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(7, nAnterior, color);
                    posicionarse(214, 415);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }

            // 7777777777777777777777
            
        }

        private void btnPos3_Click(object sender, EventArgs e)
        {
            int nAnterior = 0;

            if (color == siguienteTurno)
            {

                if ((x == 214 && y == 211) || (x == 417 && y == 213) || (x == 214 && y == 415))
                {
                    nAnterior = buscarPosAnterior();
                    juego.updatePos(8, nAnterior, color);
                    posicionarse(417, 415);

                    //pantalla.Text = juego.ganador();
                    verGanador();
                    turnoFlechas();
                }
                
            }


            // 888888888888888888888888888
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GraficoJuego_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mens = "Desarrollado Por: TONY TAFUR\n" +
                            "Contacto: tarbusa@gmail.com\n\n" +
                            "Guadalupe - Perú"; ;
            MessageBox.Show(mens);
        }

        private void reiniciarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pLAYERBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nom = InputDialog.mostrar("INGRESA UN NOMBRE: ");
            //jugadorRojo = nom.ToUpper();
            nameRojo.Text = nom.ToUpper();
        }

        private void reiniciarJuegoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ptjeAma=0;
            ptjeRojo=0;
            puntajes();
            reiniciar();
            escojeTurno.Enabled = true;
        }

        private void iniciaAMARILLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            posInicialBotontes();
            juego.reset();
            //iniciarTurno(siguienteTurno);
            iniciarTurno("a");
            siguienteTurno = "a";
            escojeTurno.Enabled = false;
        }

        private void iniciaROJOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            posInicialBotontes();
            juego.reset();
            //iniciarTurno(siguienteTurno);
            iniciarTurno("r");
            siguienteTurno = "r";
            escojeTurno.Enabled = false;
        }

        private void rANDOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pLAYERAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nom = InputDialog.mostrar("INGRESA UN NOMBRE: ");
            //jugadorAmarillo = nom.ToUpper();
            nameAmarillo.Text = nom.ToUpper();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
