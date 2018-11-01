using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GestorAnimal
{
    class Menu
    {
        public const int minimo = 0;
        public const int maximo = 100;
        //nivel minimo para la Gallina 
        public const int minHGallina = 40;
        public const int minEGallina = 20;
        //nivel minimo para la Vaca 
        public const int minHVaca = 20;
        public const int minEVaca = 30;
        //nivel minimo para el Caballo 
        public const int minHCaballo = 25;
        public const int minECaballo = 50;
        private string archivo = "animales.txt";

        private List<string> lista = new List<string>();
        
        private string opcion;
        private List<Animal> animales;
        private DtaBse data;

        #region Menu
        public void show()
        {
            data = new DtaBse(archivo);
            animales = new List<Animal>();   
      
            do
            {
          
                    if (data.existeArchivoTxt())
                    {
                        animales = data.deserializar();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("===================================================");
                    Console.WriteLine("                Menu principal                     ");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("1.- Listar animal");
                    Console.WriteLine("2.- Listar animales");
                    Console.WriteLine("3.- Agregar animal");
                    Console.WriteLine("4.- Alimentar animal");
                    Console.WriteLine("5.- Alimentar animales");
                    Console.WriteLine("6.- Jugar con animal");
                    Console.WriteLine("7.- Jugar con animales");
                    Console.WriteLine("8.- Descansar animal");
                    Console.WriteLine("9.- Descansar animales ");
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("* Para salir Ingrese : exit");
                    Console.WriteLine("* Para limpiar la pantalla ingrese : clean");
                    Console.WriteLine("* Para guardar datos del sistema : save");
                    Console.WriteLine("* Para cargar datos del sistema : load");
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("Ecribe su opcion : ");
                    Console.ForegroundColor = ConsoleColor.White;

                    opcion = Console.ReadLine().ToLower();

                switch (opcion)
                {

                    case "1":
                        {
                            //cargar();
                            listarAnimal();
                            break;
                        }
                    case "2":
                        {
                            //cargar();
                            ListarAnimales();
                            break;
                        }
                    case "3":
                        {
                            agregarAnimal();
                            guardar();
                            break;
                        }
                    case "4":
                        {
                            alimentarAnimal();
                            break;
                        }
                    case "5":
                        {
                            alimentarAnimales();
                            break;
                        }
                    case "6":
                        {
                            jugarAnimal();
                            break;
                        }
                    case "7":
                        {
                            jugarAnimales();
                            break;
                        }
                    case "8":
                        {
                            descansarAnimal();
                            break;
                        }
                    case "9":
                        {
                            descansarAnimales();
                            break;
                        }

                    case "exit":
                        {
                            Console.WriteLine("Gracias por utilizar el GestorAnimal");
                            Console.ReadKey();
                            System.Environment.Exit(-1);
                            break;
                        }
                    case "save":
                        {
                            data.serializar(animales);
                            Console.WriteLine("Los datos han sido guardados en el sistema ");
                            break;
                        }
                    case "load":
                        {
                            if (File.Exists(archivo))
                            {
                                animales = data.deserializar();
                                Console.WriteLine("Los datos han sido cargados en el sistema ");
                            }
                            break;
                        }
                    case "clean":
                        {
                            Console.Clear();
                            break;
                        }
                }

               // presionartecla();

            } while (opcion!="exit");

        }
        #endregion

        public void cargar() {
            if (File.Exists(archivo))
                 {
                    animales = data.deserializar();
                    Console.WriteLine("Los datos han sido cargados en el sistema ");
                  }

        }
        public void guardar() {
            data.serializar(animales);
        }

        
        public void presionartecla() {
            Console.WriteLine(" ");
            Console.WriteLine("Presione una tecla para continuar ");
            Console.ReadLine();

        }

        #region metodo Listar Animal

        public void listarAnimal(){

            Console.WriteLine("ingrese el nombre :");
            string nombre = Console.ReadLine();
            if (animales.Count > 1)
            {
                foreach (Animal a in animales)
                {
                    if (a.Nombre == nombre)
                    {
                        Console.WriteLine("=============================");
                        Console.WriteLine(" nombre :" + a.Nombre);
                        Console.WriteLine(" E :" + a.Energia);
                        Console.WriteLine(" H :" + a.Hambre);
                    }
                }
            }
            else {
                Console.WriteLine("No hay animal cargado");
                

            }


        }
        #endregion

        #region Metodo listarAnimales
        public void ListarAnimales() {
            if (animales.Count > 1)
            {
                foreach (Animal a in animales)
                {

                    Console.WriteLine("=============================");
                    Console.WriteLine(" nombre :" + a.Nombre);
                    Console.WriteLine(" E :" + a.Energia);
                    Console.WriteLine(" H :" + a.Hambre);
                }

            }
            else {
                Console.WriteLine("No hay animal cargado");
            }
 
        }
        #endregion

        #region Metodo agregar Animal
        public void agregarAnimal() {
            bool aviso = true;
            string nombre = "";

            Animal animalNuevo = new Animal();

            Console.WriteLine("Ingrese el nombre del animal :");
            nombre = Console.ReadLine();
            if (animales.Count > 1) {
                foreach (Animal a in animales)
                {
                    if (nombre == a.Nombre)
                    {
                        aviso = false;
                    }
                }
                
            }
           
            if (aviso)
            {
                animalNuevo.Nombre = nombre;
                animalNuevo.Hambre = 0;
                animalNuevo.Energia = 100;
                animales.Add(animalNuevo);
                data.serializar(animales);
                Console.WriteLine("el animal fue agregado con exito");
            }
            else {
                Console.WriteLine("el nombre " + animalNuevo.Nombre + "ya existe ");
            }
            
            
        }
        #endregion

        #region Alimentar animales
        public void alimentarAnimales()
        {
            if (animales.Count > 1)
            {
                foreach (Animal a in animales)
                {
                   
                    if (a.Nombre != "caballo")
                    {
                        mostrarInfo(a);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("*****ALIMENTANDO******");
                        Console.ForegroundColor = ConsoleColor.White;
                        a.Hambre = a.Hambre - 23;
                        if (a.Hambre < 0) a.Hambre = 0;
                        mostrarInfo(a);

                    }
                    else
                    {
                        var randomNumber = new Random().Next(0, 100);
                        if (randomNumber >= 50)
                        {
                            mostrarInfo(a);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("*****ALIMENTANDO******");
                            Console.ForegroundColor = ConsoleColor.White;
                            a.Hambre = a.Hambre - 40;
                            if (a.Hambre < 0) a.Hambre = 0;
                            mostrarInfo(a);
                        }
                        else
                        {
                            mostrarInfo(a);
                            Console.WriteLine(" el caballo no se va alimentar");
                        }
                    }
                }

                data.serializar(animales);
            }
            else
            {
                Console.WriteLine("No hay ningun animal para alimentar");
            }
        }

        #endregion

        #region Alimentar animal

        public void alimentarAnimal()
        {

            Console.WriteLine("Ingrese el nombre del animal :");
            string nombre = Console.ReadLine().ToLower();

            if (animales.Count > 1)
            {
                foreach (Animal a in animales)
                {
                    if (nombre == a.Nombre)
                    {
                        

                        if (nombre == "gallina")
                        {
                            mostrarInfo(a);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("*****ALIMENTANDO******");
                            Console.ForegroundColor = ConsoleColor.White;
                            a.Hambre = a.Hambre - 30;
                            if (a.Hambre < 0) a.Hambre = 0;
                            mostrarInfo(a);

                        }
                        else if (nombre == "vaca")
                        {
                            mostrarInfo(a);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("*****ALIMENTANDO******");
                            Console.ForegroundColor = ConsoleColor.White;

                            a.Hambre = a.Hambre - 23;
                            if (a.Hambre < 0) a.Hambre = 0;
                            mostrarInfo(a);

                        }
                        else if (nombre == "caballo")
                        {

                            var randomNumber = new Random().Next(0, 100);
                            if (randomNumber >= 50)
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****ALIMENTANDO******");
                                Console.ForegroundColor = ConsoleColor.White;
                                a.Hambre = a.Hambre - 40;
                                if (a.Hambre < 0) a.Hambre = 0;
                                mostrarInfo(a);
                            }
                            else
                            {
                                mostrarInfo(a);
                                Console.WriteLine(" el caballo no se va alimentar");
                            }
                        }
                    }
                }

                data.serializar(animales);
            }
            else
            {
                Console.WriteLine("No hay animal para alimentar");
            }
        }
        #endregion

        #region Jugar con Animal

        public void jugarAnimal() {
            bool bandera = true;

            Console.WriteLine("Ingrese el nombre del animal :");
            string nombre = Console.ReadLine().ToLower();

            if (animales.Count > 1)
            {
                foreach (Animal a in animales)
                {
                    if (nombre == a.Nombre.ToLower())
                    {
                        if (nombre == "gallina")
                        {
                            bool jugarGallina = gallinaPuedeJugar(a);
                            if(jugarGallina)
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****JUGANDO******");
                                Console.ForegroundColor = ConsoleColor.White;
                                int randomNumber = new Random().Next(20, 50);
                                a.Hambre = a.Hambre + 20;
                                a.Energia = a.Energia - randomNumber;

                                if (a.Hambre > 100) a.Hambre = 100;
                                if (a.Energia < 0 ) a.Energia = 0;
                                mostrarInfo(a);
                                bandera = false;
                            }
                            else
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La GALLINA NO PUEDE JUGAR");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }
                        else if (nombre == "caballo")
                        {
                            bool jugarCaballo = caballoPuedeJugar(a);
                            if (jugarCaballo)
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****JUGANDO******");
                                Console.ForegroundColor = ConsoleColor.White;

                                a.Hambre = a.Hambre + 20;
                                a.Energia = a.Energia - 15;

                                if (a.Hambre > 100) a.Hambre = 100;
                                if (a.Energia < 0) a.Energia = 0;
                                mostrarInfo(a);
                                bandera = false;
                            }
                            else
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La CABALLO NO PUEDE JUGAR");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }
                        else if (nombre == "vaca")
                        {
                            bool jugarVaca = vacaPuedeJugar(a);
                            if (jugarVaca)
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****JUGANDO******");
                                Console.ForegroundColor = ConsoleColor.White;
                                a.Hambre = a.Hambre + 33;
                                a.Energia = a.Energia - 12;

                                if (a.Hambre > 100) a.Hambre = 100;
                                if (a.Energia < 0) a.Energia = 0;
                                mostrarInfo(a);
                                bandera = false;
                            }
                            else
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La VACA NO PUEDE JUGAR");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                    }
                }

                data.serializar(animales);
                if (!bandera){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No se encontró animal con el nombre de " + nombre);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                 

            }
            else
            {
                Console.WriteLine("No hay ningun animal para Jugar");
            }
        }

        #endregion

        #region Jugar con Animales
        public  void jugarAnimales()
        {
            if (animales.Count > 1)
            {
                foreach (Animal a in animales)
                {
                    

                        if (a.Nombre == "gallina")
                        {
                            bool jugarGallina = gallinaPuedeJugar(a);
                            if (jugarGallina)
                            {
                            mostrarInfo(a);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****JUGANDO******");
                            Console.ForegroundColor = ConsoleColor.White;
                            int randomNumber = new Random().Next(20, 50);
                                a.Hambre = a.Hambre + 20;
                                a.Energia = a.Energia - randomNumber;

                                if (a.Hambre > 100) a.Hambre = 100;
                                if (a.Energia < 0) a.Energia = 0;
                            mostrarInfo(a);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La GALLINA NO PUEDE JUGAR");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        }
                        else if (a.Nombre == "caballo")
                        {
                            bool jugarCaballo = caballoPuedeJugar(a);
                            if (jugarCaballo)
                            {
                            mostrarInfo(a);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****JUGANDO******");
                            Console.ForegroundColor = ConsoleColor.White;
                            a.Hambre = a.Hambre + 20;
                                a.Energia = a.Energia - 15;

                                if (a.Hambre > 100) a.Hambre = 100;
                                if (a.Energia < 0) a.Energia = 0;
                            mostrarInfo(a);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La CABALLO NO PUEDE JUGAR");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        }
                        else if (a.Nombre == "vaca")
                        {
                            bool jugarVaca = vacaPuedeJugar(a);
                            if (jugarVaca)
                            {
                                mostrarInfo(a);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("*****JUGANDO******");
                                Console.ForegroundColor = ConsoleColor.White;
                                a.Hambre = a.Hambre + 33;
                                a.Energia = a.Energia - 12;

                                if (a.Hambre > 100) a.Hambre = 100;
                                if (a.Energia < 0) a.Energia = 0;
                                mostrarInfo(a); 
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("La VACA NO PUEDE JUGAR");
                                Console.ForegroundColor = ConsoleColor.White;
                        }
                        

                    }
                }

                data.serializar(animales);
            }
            else
            {
                Console.WriteLine("No hay ningun animal para alimentar");
            }



        }

        #endregion

        #region Descansar Animal
        public void descansarAnimal()
        {
            bool bandera = true;
            Console.WriteLine("Ingrese el nombre del animal :");
            string nombre = Console.ReadLine().ToLower();
            foreach(Animal a in animales)
            {
                if (nombre == a.Nombre)
                {
                    mostrarInfo(a);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*****DESCANSANDO******");
                    Console.ForegroundColor = ConsoleColor.White;
                    a.Energia = 100;
                    a.Hambre = a.Hambre + 35;
                    if (a.Hambre > 100) a.Hambre = 100;
                    mostrarInfo(a);
                    bandera = false;

                }


            }
            if (bandera)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO SE ENCONTRO ANIMAL CON EL NOMBRE " + nombre);
                Console.ForegroundColor = ConsoleColor.White;
            }

            data.serializar(animales);


        }
        #endregion

        #region Descansar Animales 
        public void descansarAnimales()
        {
            foreach (Animal a in animales)
            {      
                    mostrarInfo(a);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*****DESCANSANDO******");
                    Console.ForegroundColor = ConsoleColor.White;
                    a.Energia = 100;
                    a.Hambre = a.Hambre + 35;
                    if (a.Hambre > 100) a.Hambre = 100;
                    mostrarInfo(a);
            }
            data.serializar(animales);


        }

        #endregion

        public void mostrarInfo(Animal a)
        {
            Console.WriteLine("             ");
            Console.WriteLine("==============================================================");
            Console.WriteLine(" nombre :" + a.Nombre + " E :" + a.Energia + " H :" + a.Hambre);
            Console.WriteLine("             ");
        }

        // verificar si la gallina puede jugar 
        public bool gallinaPuedeJugar(Animal a)
        {
            bool bandera = false;
         
                if (a.Nombre.ToLower() == "gallina")
                {
                    if (a.Energia > minEGallina && a.Hambre < minHGallina)
                    {
                        bandera = true;
                    }
                }
            
               return bandera;
        }

        // verificar si la Vaca puede jugar 
        public bool vacaPuedeJugar(Animal a)
        {
            bool bandera = false;
           
                if (a.Nombre.ToLower() == "vaca")
                {
                    if (a.Energia > minEVaca && a.Hambre < minHVaca)
                    {
                        bandera = true;
                    }

                }
            
            return bandera;
        }

        // verificar si la Caballo puede jugar 
        public bool caballoPuedeJugar(Animal a)
        {
            bool bandera = false;
           
                if (a.Nombre.ToLower() == "caballo")
                {
                    if (a.Energia > minECaballo && a.Hambre < minHCaballo)
                    {
                        bandera = true;
                    }

                }
            
            return bandera;
        }


  




    }







}
