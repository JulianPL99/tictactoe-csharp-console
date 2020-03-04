using System;

namespace TicTacToeShell
{
    class Program
    {
        public static char signoJugador = ' ';

        static int turno = 0;

        static char[] arrTablero =
        {
            '1', '2', '3','4', '5', '6', '7', '8', '9'
        };

        public static void limpiarTablero() 
        {
            char[] iniciarArray =
            {
                '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

            arrTablero = iniciarArray;
            imprimirTablero();
            turno = 0;
        }

        public static void imprimirTablero()
        {
            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arrTablero[0], arrTablero[1], arrTablero[2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arrTablero[3], arrTablero[4], arrTablero[5]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arrTablero[6], arrTablero[7], arrTablero[8]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        } 

        static void Main(string[] args)
        {
            int jugador = 2;
            int posicion = 0;
            bool posicionCorrecta = true;

            do
            {
                if (jugador == 2)
                {
                    jugador = 1;
                    xO(jugador, posicion);
                }
                else if (jugador == 1)
                {
                    jugador = 2;
                    xO(jugador, posicion);
                }

                imprimirTablero();
                turno++;

                ganaHorizontal();
                ganaVertical();
                ganaDiagonal();

                if (turno >= 9)
                {
                    empate();
                }

                do
                {
                    Console.WriteLine("\nEs tu turno, Jugador {0}", jugador);
                    Console.WriteLine("Turno: "+turno);
                    try
                    {
                        posicion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Ingrese un número");
                    }

                    if ((posicion == 1) && (arrTablero[0] == '1'))
                        posicionCorrecta = true;
                    else if ((posicion == 2) && (arrTablero[1] == '2'))
                        posicionCorrecta = true;
                    else if ((posicion == 3) && (arrTablero[2] == '3'))
                        posicionCorrecta = true;
                    else if ((posicion == 4) && (arrTablero[3] == '4'))
                        posicionCorrecta = true;
                    else if ((posicion == 5) && (arrTablero[4] == '5'))
                        posicionCorrecta = true;
                    else if ((posicion == 6) && (arrTablero[5] == '6'))
                        posicionCorrecta = true;
                    else if ((posicion == 7) && (arrTablero[6] == '7'))
                        posicionCorrecta = true;
                    else if ((posicion == 8) && (arrTablero[7] == '8'))
                        posicionCorrecta = true;
                    else if ((posicion == 9) && (arrTablero[8] == '9'))
                        posicionCorrecta = true;
                    else
                    {
                        Console.WriteLine("Posición incorrecta, inserte una válida");
                        posicionCorrecta = false;
                    }


                } while (!posicionCorrecta);
            } while (true);

        }

        public static void xO(int jugador, int posicion)
        {

            if (jugador == 1) signoJugador = 'X';
            else if (jugador == 2) signoJugador = 'O';

            switch (posicion)
            {
                case 1: arrTablero[0] = signoJugador; break;
                case 2: arrTablero[1] = signoJugador; break;
                case 3: arrTablero[2] = signoJugador; break;
                case 4: arrTablero[3] = signoJugador; break;
                case 5: arrTablero[4] = signoJugador; break;
                case 6: arrTablero[5] = signoJugador; break;
                case 7: arrTablero[6] = signoJugador; break;
                case 8: arrTablero[7] = signoJugador; break;
                case 9: arrTablero[8] = signoJugador; break;
            }

        }

        public static void ganaHorizontal()
        {
            char[] signos = { 'X', 'O' };

            foreach (char signoJugador in signos)
            {
                if (((arrTablero[0] == signoJugador) && (arrTablero[1] == signoJugador) && (arrTablero[2] == signoJugador))
                    || ((arrTablero[3] == signoJugador) && (arrTablero[4] == signoJugador) && (arrTablero[5] == signoJugador))
                    || ((arrTablero[6] == signoJugador) && (arrTablero[7] == signoJugador) && (arrTablero[8] == signoJugador)))
                {
                    Console.Clear();
                    if (signoJugador == 'X')
                    {
                        Console.WriteLine("Gana el Jugador 1 en {0} turnos", turno);
                    }
                    else if (signoJugador == 'O')
                    {
                        Console.WriteLine("Gana el Jugador 2 en {0} turnos", turno);
                    }
                    Console.WriteLine("Presione cualquier tecla para volver a jugar.");
                    Console.ReadKey();
                    limpiarTablero();
                    break;
                }
            }
        } 

        public static void ganaVertical()
        {
            char[] signos = { 'X', 'O' };

            foreach (char signoJugador in signos)
            {
                if (((arrTablero[0] == signoJugador) && (arrTablero[3] == signoJugador) && (arrTablero[6] == signoJugador))
                    || ((arrTablero[1] == signoJugador) && (arrTablero[4] == signoJugador) && (arrTablero[7] == signoJugador))
                    || ((arrTablero[2] == signoJugador) && (arrTablero[5] == signoJugador) && (arrTablero[8] == signoJugador)))
                {
                    Console.Clear();
                    if (signoJugador == 'X')
                    {
                        Console.WriteLine("Gana el Jugador 1 en {0} turnos", turno);
                    }
                    else
                    {
                        Console.WriteLine("Gana el Jugador 2 en {0} turnos", turno);
                    }
                    Console.WriteLine("Presione cualquier tecla para volver a jugar.");
                    Console.ReadKey();
                    limpiarTablero();
                    break;
                }
            }
        }  

        public static void ganaDiagonal()
        {
            char[] signos = { 'X', 'O' };

            foreach (char signoJugador in signos)
            {
                if (((arrTablero[0] == signoJugador) && (arrTablero[4] == signoJugador) && (arrTablero[8] == signoJugador))
                    || ((arrTablero[6] == signoJugador) && (arrTablero[4] == signoJugador) && (arrTablero[2] == signoJugador)))
                {
                    Console.Clear();
                    if (signoJugador == 'X')
                    {
                        Console.WriteLine("Gana el Jugador 1 en {0} turnos", turno);
                    }
                    else
                    {
                        Console.WriteLine("Gana el Jugador 2 en {0} turnos", turno);
                    }
                    Console.WriteLine("Presione cualquier tecla para volver a jugar.");
                    Console.ReadKey();
                    limpiarTablero();
                    break;
                }
            }
        }

        public static void empate()
        {

            {
                Console.WriteLine("Es un EMPATE" +
                                  "\nPresione cualquier tecla para volver a jugar.");
                Console.ReadKey();
                limpiarTablero();

            }
        }
    }
}
