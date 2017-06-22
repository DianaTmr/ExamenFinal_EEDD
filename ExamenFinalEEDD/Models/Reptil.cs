using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalEEDD.Models
{
    class Reptil : Animal
    {
        // ATRIBUTOS
        private bool _esVenenoso;
        private string _especie;


        // Constructor
        public Reptil(string nombre, string fecha, double peso, bool venenoso, string especie) : base(nombre, fecha, peso)
        {
            _esVenenoso = venenoso;
            Especie = especie;
        }
        // Propiedades
        public string esVenenoso
        {
            get
            {
                return _esVenenoso ? "El reptil es peligroso" : "El reptil no es peligroso";
            }
        }
        public string Especie
        {
            get
            {
                return _especie;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de la especie está vacío.");
                }
                else
                {
                    _especie = value;
                }
            }
        }

        public override string ToString()
        {
            return ("-------------------------------------\nReptil \n Nombre: " + Nombre + "\n Venenoso: " + esVenenoso + "\n Fecha de nacimiento: " + FechaNacimiento + "\n Peso: " + Peso + "\n Comentarios: " + Comentarios + "\n Especie: " + Especie);
        }
    }
}
