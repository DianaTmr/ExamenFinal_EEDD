using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenFinalEEDD.Models;

namespace ExamenFinalEEDD
{
    class Program
    {
        private static ClinicaVeterinaria c;

        static void Main(string[] args)
        {
            c = new ClinicaVeterinaria("Pasito a pasito");
            c.mostrarMenu();
        }
    }
}
