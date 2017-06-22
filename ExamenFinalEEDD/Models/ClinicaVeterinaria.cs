using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalEEDD.Models
{
    class ClinicaVeterinaria
    {
        // Atributos
        private string _nombre;
        private List<Animal> lista;

        // Constructor
        public ClinicaVeterinaria(string nombre)
        {
            _nombre = nombre;
            lista = new List<Animal>();
        }


        /***********************************************************
         *                Muestra el menú principal                *                                                                              
         ***********************************************************/

        public void mostrarMenu()
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("Bienvenido a la clínica veterinaria " + _nombre);
            Console.WriteLine("======================================================");
            bool salir = false;
            do
            {
                int opcion;
                Console.WriteLine("\n\t\tMENU PRINCIPAL\t\t");
                Console.WriteLine("======================================================");
                Console.WriteLine("1. Añadir animal");
                Console.WriteLine("2. Modificar comentario.");
                Console.WriteLine("3. Mostrar ficha");
                Console.WriteLine("4. Pesar al animal");
                Console.WriteLine("5. Salir");
                Console.WriteLine("=====================================================");
                opcion = pedirEntero();

                switch (opcion)
                {
                    case 1:
                        insertarAnimal();
                        break;

                    case 2:
                        modificarComentario();
                        break;

                    case 3:
                        buscarAnimal();
                        break;
                    case 4:
                        pesarAnimal();
                        break;
                    case 5:
                        salir = true;
                        break;
                }
            } while (!salir);
        }
        /***********************************************************
         *                Muestra el menú secundario               *                                                                              
         ***********************************************************/
        private int menuSecundario()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n==================================================");
                Console.WriteLine("\n\t\tTIPO DE ANIMAL\t\t");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Perro.");
                Console.WriteLine("2. Gato.");
                Console.WriteLine("3. Pajaro.");
                Console.WriteLine("4. Reptil.");
                Console.WriteLine("==================================================");
                opcion = pedirEntero();
            } while (opcion < 1 || opcion > 4);
            return opcion;
        }
        /************************************************************
         *   Pide datos, lo construye y añade al animal a la lista  *                                                                              
         ***********************************************************/
        private void insertarAnimal()
        {
            string nombre, fechaNacimiento = "", auxFecha;
            double peso;
            int aux, dia, mes, anio; ;

            int opcion = menuSecundario();

            Console.Write("[>] Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("\tDia de nacimiento");
            dia = pedirEntero();
            Console.Write("\tMes de nacimiento");
            mes = pedirEntero();
            Console.Write("\tAño de nacimiento");
            anio = pedirEntero();
            auxFecha = dia.ToString();
            fechaNacimiento += (dia.ToString() + "/" + mes.ToString() + "/" + anio.ToString());
            Console.WriteLine("[>] Peso");
            peso = pedirDouble();

            switch (opcion)
            {
                case 1:
                    string razaPerro, microP;
                    Console.Write("[>] Raza: ");
                    razaPerro = Console.ReadLine();
                    Console.Write("[>] Número del microchip: ");
                    microP = Console.ReadLine();
                    Perro perro = new Perro(nombre, fechaNacimiento, peso, razaPerro, microP);
                    addAnimal(perro);
                    break;
                case 2:
                    string razaGato, microG;
                    Console.Write("[>] Raza: ");
                    razaGato = Console.ReadLine();
                    Console.Write("[>] Número del microchip: ");
                    microG = Console.ReadLine();
                    Gato gato = new Gato(nombre, fechaNacimiento, peso, razaGato, microG);
                    addAnimal(gato);
                    break;
                case 3:
                    string razaPajaro;
                    bool cantor = false;
                    Console.Write("[>] Raza: ");
                    razaPajaro = Console.ReadLine();
                    Console.Write("[>] Canta -> (1: Si - 2: No): ");
                    do
                    {
                        aux = pedirEntero();
                    } while (aux < 1 || aux > 2);
                    if (aux == 1)
                    {
                        cantor = true;
                    }
                    else if (aux == 2)
                    {
                        cantor = false;
                    }
                    else
                    {
                        Console.WriteLine("[X] ERROR. Opción incorrecta.");
                    }
                    Pajaro pajaro = new Pajaro(nombre, fechaNacimiento, peso, cantor, razaPajaro);
                    addAnimal(pajaro);
                    break;
                case 4:

                    String razaReptil;
                    bool venenoso = false;
                    Console.Write("[>] Raza: ");
                    razaReptil = Console.ReadLine();
                    Console.Write("[>] Venenoso -> (1: Si - 2: No): ");

                    do
                    {
                        aux = pedirEntero();
                    } while (aux < 1 || aux > 2);
                    if (aux == 1)
                    {
                        venenoso = true;
                    }
                    else if (aux == 2)
                    {
                        venenoso = false;
                    }
                    else
                    {
                        Console.WriteLine("[X] ERROR. Opción incorrecta.");
                    }
                    Reptil reptil = new Reptil(nombre, fechaNacimiento, peso, venenoso, razaReptil);
                    addAnimal(reptil);
                    break;
            }

        }
        /*********************************************************************
         *     Comprueba si existe el animal en la lista, si no, lo añade    *
         *     @param a Animal que se desea añadir                           *                                                                              
         *********************************************************************/
        private void addAnimal(Animal a)
        {
            int cont = 0;

            if (lista.Contains(a))
            {
                Console.WriteLine("[X] Ya existe este animal.");
                cont++;
            }
            foreach (Animal animal in lista)
            {
                if (animal.Nombre.Equals(a.Nombre))
                {
                    Console.WriteLine("[X] Ya existe un animal con este nombre.");
                    cont++;
                }
            }


            if (cont == 0)
            {
                Console.WriteLine("\n-----------------------------------------------------");
                Console.WriteLine("\n[>] Se ha añadido el animal correctamente.");
                lista.Add(a);
            }
        }

        /*********************************************************************
         *     Modifica el comentario si existe el animal en la lista        *                                                                              
         *********************************************************************/
        private void modificarComentario()
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("[X] No hay animales actualmente.");
            }
            else
            {

                Console.Write("[>] Nombre del animal: ");
                string nombreAux = Console.ReadLine();
                Animal busqueda = null;
                foreach (Animal a in lista)
                {
                    if (a.Nombre.ToUpper().Equals(nombreAux.ToUpper()))
                    {
                        busqueda = a;
                    }
                }
                // Si se encuentra, lo muestra.
                if (busqueda != null && lista.Contains(busqueda))
                {

                    String comentario;
                    Console.Write("[>] Introduzca el nuevo comentario: ");
                    comentario = Console.ReadLine();
                    busqueda.Comentarios = comentario;
                    Console.WriteLine("[>] El comentario se ha modificado correctamente");

                }
                else
                {
                    Console.WriteLine("[X] ERROR. Este animal no existe.");
                }
            }

        }
        /***************************************************
         *           Busca el animal en la lista           *                                                                              
         ***************************************************/
        private void buscarAnimal()
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("[X] No hay animales actualmente.");
            }
            else
            {

                Console.Write("[>] Nombre del animal: ");
                string nombreAux = Console.ReadLine();
                Animal busqueda = null;

                foreach (Animal a in lista)
                {
                    if (a.Nombre.ToUpper().Equals(nombreAux.ToUpper()))
                    {
                        busqueda = a;
                    }
                }
                // Si encuentra el animal, lo muestra
                if (busqueda != null && lista.Contains(busqueda))
                {

                    Console.WriteLine(busqueda.ToString());

                }
                else
                {
                    Console.WriteLine("[X] ERROR. Este animal no existe.");
                }
            }

        }
        private void pesarAnimal()
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("[X] No hay animales actualmente.");
            }
            else
            {
                Console.Write("[>] Nombre del animal: ");
                string nombreAux = Console.ReadLine();
                Animal busqueda = null;
                foreach (Animal a in lista)
                {
                    if (a.Nombre.ToUpper().Equals(nombreAux.ToUpper()))
                    {
                        busqueda = a;
                    }
                }
                // Si se encuentra, lo muestra.
                if (busqueda != null && lista.Contains(busqueda))
                {
                    double peso;
                    Console.Write("[>] Introduzca el nuevo peso: ");
                    peso = pedirDouble();
                    busqueda.Peso = peso;
                    Console.WriteLine("[>] El peso se ha modificado correctamente");

                }
                else
                {
                    Console.WriteLine("[X] ERROR. Este animal no existe.");
                }
            }
            }

        /***********************************************************
         *  Funciones de lectura de distintos tipos de datos       *                                                                              
         ***********************************************************/
        //LEER INT
        public static int pedirEntero()
        {
            string entrada = "";
            int numero = 0;
            bool esCorrecto = false;

            do
            {
                Console.Write("\n[>] Introduzca el número: ");
                entrada = Console.ReadLine();
                esCorrecto = Int32.TryParse(entrada, out numero);
                if (!esCorrecto)
                    Console.WriteLine("[X] ERROR: No has introducido un número válido.");
            } while (!esCorrecto);
            return numero;
        }
        // LEER DOBULE
        public static double pedirDouble()
        {

            string entrada = "";
            double numero = 0;
            bool esCorrecto = false;

            do
            {
                Console.Write("\n[>] Introduzca el número: ");

                entrada = Console.ReadLine();
                esCorrecto = double.TryParse(entrada, out numero);
                if (!esCorrecto)
                    Console.WriteLine("[X] ERROR: No has introducido un número válido.");

            } while (!esCorrecto);
            return numero;
        }

        public override string ToString()
        {
            string clinica = "";
            foreach (Animal animal in lista)
            {
                clinica += animal.ToString() + "\n";
            }
            return "Clinica Veterinaria " + _nombre + "\n Lista de animales: " + clinica;
        }

    }
}

