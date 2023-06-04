using System;

namespace Juego_pastores_piedras
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nombresGanadores = new string[0];//Array que guardará el nombre de los vencedores
            int[] puntuacionesGanadores = new int[0];//Array que guardará las puntuaciones de los vencedores
            string nombreJugador1 = "Jugador 1";//Nombre genérico
            string nombreJugador2 = "Jugador 2";//Nombre genérico
            int filas = 6;//Filas estándar
            int columnas = 4;//Filas estándar
            bool repetir = true;//Para que entre
            while (repetir == true)//Para que pueda salir
            {
                Console.Clear();
                int[] tablero = new int[filas];//Array que representa el tablero
                for (int i = 0; i <= filas - 1; i++)//Para crear correctamente el tablero dentro del array ya declarado
                {
                    tablero[i] = columnas;
                }
                Console.WriteLine("\n\n\tElija una opción:");//Opciones a elegir
                Console.WriteLine("\t1-Mostrar reglas");
                Console.WriteLine("\t2-Personalizar");
                Console.WriteLine("\t3-Jugar");
                Console.WriteLine("\t4-Puntuaciones más altas");
                Console.WriteLine("\t5-Jugar contra la IA");
                Console.WriteLine("\t6-Salir del programa");
                Console.Write("\n\t");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Reglas();//Muestra las normas
                        break;

                    case "2":
                        Console.Write("\n\t");
                        Console.WriteLine("¿Qué quiere modificar?");//Para no obligar a cambiar cosas que nose quieren modificar
                        Console.Write("\n\t");
                        Console.WriteLine("1-Tablero");
                        Console.Write("\n\t");
                        Console.WriteLine("2-Nombres");
                        Console.Write("\n\t");
                        Console.WriteLine("3-Ambos");
                        Console.Write("\n\t");
                        string opcionPersonalizar = Console.ReadLine();
                        switch (opcionPersonalizar)
                        {
                            case "1":
                                ModificarTablero(ref filas, ref columnas);
                                break;
                            case "2":
                                ModificarNombres(ref nombreJugador1, ref nombreJugador2);
                                break;
                            case "3":
                                ModificarAmbos(ref filas, ref columnas, ref nombreJugador1, ref nombreJugador2);
                                break;
                        }
                        break;
                    case "3":
                        Partida(tablero, nombreJugador1, nombreJugador2, ref nombresGanadores, ref puntuacionesGanadores);//Lleva a la partida con 2 jugadores

                        break;

                    case "4":
                        if (nombresGanadores.Length > 0)
                        {
                            for (int i = 0; i < nombresGanadores.Length; i++)
                            {
                                Console.Write("\n\t");
                                Console.Write(nombresGanadores[i] + " ha ganado " + puntuacionesGanadores[i]);
                                if (puntuacionesGanadores[i]>1)
                                {
                                    Console.WriteLine(" partidas.");
                                }
                                else
                                {
                                    Console.WriteLine(" partida.");
                                }
                            }
                        }
                        else
                        {
                            Console.Write("\n\t");
                            Console.WriteLine("No ha ganado nadie todavía");
                        }
                        Console.Write("\n\t");
                        Console.WriteLine("Pulse Enter");
                        Console.ReadLine();
                        break;

                    case "5":
                        JugarContraIA(tablero);
                        break;

                    case "6":
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
        }







        static void Reglas()
        {
            Console.Write("\n\t");
            Console.WriteLine("Dos jugadores deben retirar, turnándose, piedras del tablero y pierde quien retire la última");
            Console.Write("\n\t");
            Console.WriteLine("Los turnos se suceden tras decidir la fila de la que retirar y la cantidad");
            Console.Write("\n\t");
            Console.WriteLine("Cada jugador puede quitar desde una única piedra hasta todas las de una misma fila pero nunca piedras de distintas filas.");
            Console.Write("\n\t");
            Console.WriteLine("Pulse Enter");
            Console.ReadLine();
        }


        static void ModificarTablero(ref int filas, ref int columnas)
        {
            Console.Write("\n\t");
            Console.WriteLine("¿Cuántas filas quiere?");
            Console.Write("\n\t");
            filas = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\t");
            Console.WriteLine("¿Cuántas columnas quiere?");
            Console.Write("\n\t");
            columnas = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\t");
            Console.WriteLine("Pulse Enter");
            Console.ReadLine();
        }

        static void ModificarNombres(ref string nombreJugador1, ref string nombreJugador2)
        {
            Console.Write("\n\t");
            Console.WriteLine("¿Cómo se llama el jugador 1?");
            Console.Write("\n\t");
            nombreJugador1 = Console.ReadLine();
            Console.Write("\n\t");
            Console.WriteLine("¿Cómo se llama el jugador 2?");
            Console.Write("\n\t");
            nombreJugador2 = Console.ReadLine();
            Console.Write("\n\t");
            Console.WriteLine("Pulse Enter");
            Console.ReadLine();
        }

        static void ModificarAmbos(ref int filas, ref int columnas, ref string nombreJugador1, ref string nombreJugador2)
        {
            Console.Write("\n\t");
            Console.WriteLine("¿Cuántas filas quiere?");
            Console.Write("\n\t");
            filas = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\t");
            Console.WriteLine("¿Cuántas columnas quiere?");
            Console.Write("\n\t");
            columnas = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\t");
            Console.WriteLine("¿Cómo se llama el jugador 1?");
            Console.Write("\n\t");
            nombreJugador1 = Console.ReadLine();
            Console.Write("\n\t");
            Console.WriteLine("¿Cómo se llama el jugador 2?");
            Console.Write("\n\t");
            nombreJugador2 = Console.ReadLine();
            Console.Write("\n\t");
            Console.WriteLine("Pulse Enter");
            Console.ReadLine();
        }








        static void Partida(int[] tablero, string nombreJugador1, string nombreJugador2, ref string[] nombresGanadores, ref int[] puntuacionesGanadores)
        {
            bool jugador1 = true;//Indica el turno(true=turno del jugador 1 y false=turno del jugador 2
            bool primeraVez = true;//Para saber si hay que elegir turno o solo cambiarlo
            bool finPartida = false;//Para cuando finalice
            int filaQuitar = 0;//Para cuando el jugador decida de qué fila quitar
            int cantidadQuitar = 0;//Para cuando el jugador decida de cuántas quitar
            //
            string ganador;//Guarda el nombre del vencedor de esta partida concretamente
            //
            while (finPartida == false)//Para que se repita hasta que acabe
            {
                Console.Clear();
                if (primeraVez == true)//Indica el turno
                {
                    jugador1 = ElegirTurno();
                    primeraVez = false;
                }
                else
                {
                    jugador1 = CambioTurno(jugador1);
                }
                Mostrartablero(tablero);//Muestra el tablero
                Console.Write("\n\t");
                if (jugador1 == true)//Para que sepan a quien la toca
                {
                    Console.WriteLine("Turno de: " + nombreJugador1);
                }
                else
                {
                    Console.WriteLine("Turno de: " + nombreJugador2);
                }
                Elegir(ref filaQuitar, ref cantidadQuitar, tablero);//Para decidir dónde y cuántas quitar
                tablero[filaQuitar] = tablero[filaQuitar] - cantidadQuitar;//Para extraer del tablero
                finPartida = ComprobarFinal(tablero);//Para comprobar si la partida continúa
            }
            if (jugador1 == true)//Así se decide quién gana
            {
                Console.Write("\n\t");
                Console.WriteLine("Gana " + nombreJugador2);
                ganador = nombreJugador2;
            }
            else
            {
                Console.Write("\n\t");
                Console.WriteLine("Gana " + nombreJugador1);
                ganador = nombreJugador1;
            }
            Console.WriteLine("Pulse Enter");
            Console.ReadLine();

            AñadirAHighScores(ref nombresGanadores, ref puntuacionesGanadores, ganador);//Para añadir al vencedor en las "High Scores"
        }















        static void Mostrartablero(int[] tablero)
        {
            Console.Write("\n");
            for (int i = 0; i <= tablero.Length - 1; i++)//Este muestra las filas...
            {
                Console.Write("\t");
                Console.Write("Fila " + (i + 1) + "     ");
                for (int u = 0; u <= tablero[i] - 1; u++)//...Y este las piedras de cada fila
                {
                    Console.Write("O ");
                }
                Console.WriteLine("");
            }
        }








        static bool ElegirTurno()
        {
            bool jugador1;
            int seed = Environment.TickCount;//Para que no sea siempre el mismo
            Random rng = new Random();//Elección aleatoria
            int jugadoruno = rng.Next(0, 2);
            if (jugadoruno < 1)
            {
                jugador1 = true;
            }
            else
            {
                jugador1 = false;
            }
            return jugador1;
        }













        static bool CambioTurno(bool jugador1)
        {
            if (jugador1 == true)//Para que cambie
            {
                jugador1 = false;
            }
            else
            {
                jugador1 = true;
            }
            return jugador1;
        }







        static int Elegir(ref int filaQuitar, ref int cantidadQuitar, int[] tablero)
        {

            bool filaQuitarCorrecto = false;//Para asegurarse de que esa fila tiene piedras
            while (filaQuitarCorrecto == false)//Para asegurarse de que esa fila tiene piedras
            {
                Console.Write("\n\t");
                Console.Write("¿De qué fila desea extraer?  ");
                filaQuitar = Convert.ToInt32(Console.ReadLine()) - 1;//Porque en el array es -1
                if (filaQuitar <= tablero.Length - 1 && filaQuitar > -1 && tablero[filaQuitar] > 0)//Para asegurarse de que esa fila tiene piedras
                {
                    filaQuitarCorrecto = true;
                }
                else
                {
                    Console.Write("\n\t");
                    Console.WriteLine("Fila no disponible");
                }
            }
            bool cantidadQuitarCorrecto = false;//Para asegurarse de que hay esa cantidad de piedras
            while (cantidadQuitarCorrecto == false)//Para asegurarse de que hay esa cantidad de piedras
            {
                Console.Write("\n\t");
                Console.Write("¿Cuántas piedras desea extraer?  ");
                cantidadQuitar = Convert.ToInt32(Console.ReadLine());
                if (cantidadQuitar <= tablero[filaQuitar] && cantidadQuitar > 0)//Para asegurarse de que hay esa cantidad de piedras
                {
                    cantidadQuitarCorrecto = true;
                }
                else
                {
                    Console.Write("\n\t");
                    Console.WriteLine("Cantidad no disponible");
                }
            }
            return (filaQuitar);
        }



        static bool ComprobarFinal(int[] tablero)
        {
            bool finPartida;
            int piedrasrestantes = 0;
            for (int i = 0; i <= tablero.Length - 1; i++)//Sila suma de todo el array tablero es igual a 0 es que no queda ninguna piedra
            {
                piedrasrestantes += tablero[i];
            }
            if (piedrasrestantes < 1)
            {
                finPartida = true;
            }
            else
            {
                finPartida = false;
            }

            return finPartida;
        }





        static void AñadirAHighScores(ref string[] nombresGanadores, ref int[] puntuacionesGanadores, string ganador)
        {
            string[] nombresGanadoresNuevo;//Para un nuevo nombre
            int[] puntuacionesGanadoresNuevo;//Para la
            bool nombreRepetido = false;
            int i = 0;
            if (ganador != "Jugador 1" && ganador != "Jugador 2")//Para que los nombres genéricos no se lleven las puntuaciones si no se modifican
            {
                while (nombreRepetido == false && i < nombresGanadores.Length)
                {
                    if (nombresGanadores[i] == ganador)//Para comprobar si es un nombre ya registrado
                    {
                        nombreRepetido = true;
                    }
                    i++;
                }
            }
            i--;
            if (nombreRepetido == true)
            {//El ganador ya ha vencido alguna vez
                puntuacionesGanadores[i] += 1;//Suma 1 a su puntuación
                while (i > 0 && puntuacionesGanadores[i - 1] < puntuacionesGanadores[i])//Para hacer subir en el rancking si es necesario//Uso while y no for para evitar que se repita más de las veces necesarias
                {
                    //Sustitución de arrays
                    string nombreVariableProvisional;
                    nombreVariableProvisional = nombresGanadores[i - 1];
                    nombresGanadores[i - 1] = nombresGanadores[i];
                    nombresGanadores[i] = nombreVariableProvisional;
                    int puntuacionVariableProvisional;
                    puntuacionVariableProvisional = puntuacionesGanadores[i - 1];
                    puntuacionesGanadores[i - 1] = puntuacionesGanadores[i];
                    puntuacionesGanadores[i] = puntuacionVariableProvisional;
                    i--;
                }

            }
            else//Gana por 1ª vez
            {
                nombresGanadoresNuevo = new string[nombresGanadores.Length + 1];//Para aumentar el tamaño del array
                puntuacionesGanadoresNuevo = new int[nombresGanadores.Length + 1];//Para aumentar el tamaño del array
                for (i = 0; i < nombresGanadores.Length; i++)//Para no perder la información del anterior array
                {
                    nombresGanadoresNuevo[i] = nombresGanadores[i];
                    puntuacionesGanadoresNuevo[i] = puntuacionesGanadores[i];
                }
                nombresGanadoresNuevo[nombresGanadores.Length] = ganador;//Para incluir al nuevo ganador
                puntuacionesGanadoresNuevo[nombresGanadores.Length] = 1;//Para incluir la puntuación del nuevo ganador
                //A partir de ahora para asignar la información del nuevo array al original
                nombresGanadores = new string[nombresGanadoresNuevo.Length];
                puntuacionesGanadores = new int[puntuacionesGanadoresNuevo.Length];
                for (i = 0; i < nombresGanadoresNuevo.Length; i++)
                {
                    nombresGanadores[i] = nombresGanadoresNuevo[i];
                    puntuacionesGanadores[i] = puntuacionesGanadoresNuevo[i];
                }
            }
        }











        static void JugarContraIA(int[] tablero)
        {
            bool jugador1 = true;//En este caso, true significa que es el turno del jugador y false que es el de la IA
            //A partir de aquí todo es igual salvo por el momento en el que es el turno de la IA, que le lleva a su respectiva función (la última del código)
            bool primeraVez = true;
            bool finPartida = false;
            int filaQuitar = 0;
            int cantidadQuitar = 0;
            while (finPartida == false)
            {
                Console.Clear();
                if (primeraVez == true)
                {
                    jugador1 = ElegirTurno();
                    primeraVez = false;
                }
                else
                {
                    jugador1 = CambioTurno(jugador1);
                }
                Mostrartablero(tablero);
                if (jugador1 == true)
                {
                    Console.Write("\n\t");
                    Console.WriteLine("Tu turno");
                    Elegir(ref filaQuitar, ref cantidadQuitar, tablero);
                    tablero[filaQuitar] = tablero[filaQuitar] - cantidadQuitar;
                }
                else
                {
                    Console.Write("\n\t");
                    Console.WriteLine("Turno del rival");
                    Console.Write("\n\t");
                    Console.WriteLine("Pulse Enter");
                    Console.ReadLine();
                    tablero= IA(tablero);
                }
                finPartida = ComprobarFinal(tablero);
            }
            if (jugador1 == true)
            {
                Console.Write("\n\t");
                Console.WriteLine("Derrota");
            }
            else
            {
                Console.Write("\n\t");
                Console.WriteLine("Victoria");
            }
        }

        //La IA ha sido creada pensando que la clave está a partir de que queden 2 filas y la condición de victoria principal parte principalmente desde que quedan dos filas con 2 piedras.
        //La IA intentará propiciar esa situación desde que queden 2 filas y, a partir de ahí, si el jugador quita 1 piedra, la IA quitará 2 de la otra fila, y si quita la 2, quitará 1 de la restante.
        //Si es la IA la que queda en desventaja, mantendrá las 2 filas para intentar confundir al rival.
        //Cada vez que de igual de qué fila extraer, lo eligirá aleatoriamente para aportar mayor realismo.
        //Mientras queden más de 2 filas, sus elecciones serán aleatorias
        static int[] IA (int[] tablero)
        {
            int filaOcupada=-1;
            int filaOcupadados = -1;
            int filasRestantes = 0;
            for(int i=0; i<tablero.Length; i++)
            {
                if(tablero[i]>0)
                {
                    filasRestantes++;
                    if (filaOcupada<0)
                    {
                        filaOcupada = i;//Si quedan 2 filas o menos con piedras, ésta será la 1ª
                    }
                    else
                    {
                        filaOcupadados = i;//Si quedan 2 filas, ésta será la 2ª
                    }
                }
            }
            if (filasRestantes <= 2)
            {//En este caso quedan 2 filas o menos, así que la IA actúa
                int filaQuitar;
                if (filaOcupadados<0)
                {//Solo queda 1 fila
                    if (tablero[filaOcupada] <= 1)
                    {//La IA ya ha perdido
                        tablero[filaOcupada] = 0;
                    }
                    else//La IA ya ha ganado
                    {
                        tablero[filaOcupada] = 1;
                    }
                }
                else
                {//Todavía quedan 2 filas
                    if (tablero[filaOcupada] > 2 && tablero[filaOcupadados]>2)
                    {
                        int seed = Environment.TickCount;//Para que el random no sea siempre igual
                        Random rng = new Random();
                        filaQuitar = rng.Next(0, 2);
                        if (filaQuitar <= 0)
                        {
                            tablero[filaOcupada] = 2;
                        }
                        else
                        {
                            tablero[filaOcupadados] = 2;
                        }
                    }
                    else if (tablero[filaOcupada] > 2 && tablero[filaOcupadados] == 2)
                    {
                        tablero[filaOcupada] = 2;
                    }
                    else if (tablero[filaOcupadados] > 2 && tablero[filaOcupada] == 2)
                    {
                        tablero[filaOcupadados] = 2;
                    }
                    else if (tablero[filaOcupadados] > 2 && tablero[filaOcupada] == 1)
                    {
                        tablero[filaOcupadados] = 0;
                    }
                    else if (tablero[filaOcupada] > 2 && tablero[filaOcupadados] == 1)
                    {
                        tablero[filaOcupada] = 0;
                    }
                    else if (tablero[filaOcupadados] == 2 && tablero[filaOcupada] == 2)
                    {
                        int seed = Environment.TickCount;
                        Random rng = new Random();
                        filaQuitar = rng.Next(0, 2);
                        if (filaQuitar<=0)
                        {
                            tablero[filaOcupada] = 1;
                        }
                        else
                        {
                            tablero[filaOcupadados] = 1;
                        }
                    }
                    else if (tablero[filaOcupada] == 1 && tablero[filaOcupadados] == 2)
                    {
                        tablero[filaOcupadados] = 0;
                    }
                    else if (tablero[filaOcupadados] == 1 && tablero[filaOcupada] == 2)
                    {
                        tablero[filaOcupada] = 0;
                    }
                    else
                    {//Queda 1 en ambas filas//La IA ya ha ganado  
                        int seed = Environment.TickCount;
                        Random rng = new Random();
                        filaQuitar = rng.Next(0, 2);
                        if (filaQuitar <= 0)
                        {
                            tablero[filaOcupada] = 0;
                        }
                        else
                        {
                            tablero[filaOcupadados] = 0;
                        }
                    }
                }
            }
            else//A partir de aquí, la IA elije de for,a aleatoria comprobando que sea posible
            {
                int filaQuitar;
                bool filaValida;
                do
                {
                    int seed = Environment.TickCount;//Para que el random no sea siempre igual
                    Random rng = new Random();
                    filaQuitar = rng.Next(0, tablero.Length);
                    if (tablero[filaQuitar] <= 0)
                    {
                        filaValida = false;
                    }
                    else
                    {
                        filaValida = true;
                    }
                } while (filaValida == false);
                int seed2 = Environment.TickCount;
                Random rng2 = new Random();
                int cantidadQuitar = rng2.Next(1, tablero[filaQuitar] + 1);
                tablero[filaQuitar] -= cantidadQuitar;
            }
            return tablero;
        }
    }
}
