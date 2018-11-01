using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GestorAnimal
{
    class DtaBse
    {
        private String ruta;

        public DtaBse(String ruta)
        {
            this.ruta = ruta;
                
        }

        public bool existeArchivoTxt() {
            return File.Exists(ruta);

        }

        public void serializar(List<Animal> listaAnimales) {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo,listaAnimales);
            flujo.Close();

        }

        public List<Animal> deserializar() {
            Stream flujo = File.Open(ruta,FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter(); 
            List<Animal> listaAnimales = (List<Animal>)bin.Deserialize(flujo);
            flujo.Close();
           return listaAnimales;
  
           

        }


    }
}
