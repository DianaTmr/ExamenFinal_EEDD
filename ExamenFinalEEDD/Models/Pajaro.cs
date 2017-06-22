using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalEEDD.Models
{
    class Pajaro : Animal
    {
        // ATRIBUTOS
        private bool _esCantor;
        private string _especie;

        // Constructor
        public Pajaro(string nombre, string fecha, double peso, bool canta, string especie) : base(nombre, fecha, peso)
        {
            _esCantor = canta;
            Especie = especie;
        }
        // Propiedades
        public string Cantor
        {
            get
            {
                return _esCantor ? "Este pajarito canta" : "Este pajarito no canta";
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
            return ("-------------------------------------\nPajaro \n Nombre: " + Nombre + "\n Canta: " + Cantor + "\n Fecha de nacimiento: " + FechaNacimiento + "\n Peso: " + Peso + "\n Comentarios: " + Comentarios + "\nEspecie: " + Especie);

        }
    }
}
