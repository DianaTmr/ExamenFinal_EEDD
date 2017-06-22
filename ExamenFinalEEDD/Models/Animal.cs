using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalEEDD.Models
{
    abstract class Animal
    {
        // ATRIBUTOS
        protected string _nombre, _fechaNacimiento, _comentarios;
        protected double _peso;

        // Constructor
        public Animal(string nombre, string fecha, double peso)
        {
            Nombre = nombre;
            FechaNacimiento = fecha;
            Peso = peso;
            Comentarios = "";
        }
        // Propiedades
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo del nombre está vacío.");
                }
                else
                {
                    _nombre = value;
                }
            }
        }

        public string FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de la fecha está vacío.");
                }
                else
                {
                    _fechaNacimiento = value;
                }
            }
        }

        public double Peso
        {
            get
            {
                return _peso;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("El peso está fuera de rango. Permitido 1-200.");
                }
                else { _peso = value; }
            }
        }

        public string Comentarios
        {
            get
            {
                return _comentarios;
            }
            set
            {
                _comentarios = value;
            }
        }
        public void Pesar(double peso)
        {
            Peso = peso;
        }
        public override string ToString()
        {
            return ("Ficha de: " + Nombre + "\n Fecha de nacimiento: " + FechaNacimiento + "\n Peso:" + Peso + "\n Comentarios: " + Comentarios);
        }
    }
}
