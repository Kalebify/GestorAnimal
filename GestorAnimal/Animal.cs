using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAnimal
{
    [Serializable()]
    class Animal
    {
        private string nombre;
        private int energia;
        private int hambre;
      
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Energia
        {
            get
            {
                return energia;
            }

            set
            {
                energia = value;
            }
        }

        public int Hambre
        {
            get
            {
                return hambre;
            }

            set
            {
                hambre = value;
            }
        }
    }
}
