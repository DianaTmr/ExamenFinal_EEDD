using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalEEDD.Models
{
    class Gato : Animal
    {
        // ATRIBUTOS
        private string _raza, _microchip;

        // Constructor
        public Gato(String nombre, String fecha, double peso, string raza, string microChip) : base(nombre, fecha, peso)
        {
            Raza = raza;
            Microchip = microChip;
        }
        // Propiedades
        public string Raza
        {
            get
            {
                return _raza;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de raza está vacío");
                }
                else
                {
                    _raza = value;
                }
            }
        }

        public string Microchip
        {
            get
            {
                return _microchip;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo del microchip está vacío");
                }
                else
                {
                    _microchip = value;
                }
            }
        }

        public override string ToString()
        {
            return ("-------------------------------------\nGato \n Nombre: " + Nombre + "\n Raza: " + Raza + "\n Fecha de nacimiento: " + FechaNacimiento + "\n Peso: " + Peso + "\n Comentarios: " + Comentarios
      + "\n Microchip: " + Microchip);
        }
    }
}
