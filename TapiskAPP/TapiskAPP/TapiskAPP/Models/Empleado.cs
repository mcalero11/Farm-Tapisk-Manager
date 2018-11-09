using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models
{
    public class Empleado : BaseResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Usuario Usuario { get; set; }
    }

    public class MockEmpleados{
        public static List<Empleado> GetEmpleados()
        {
            return new List<Empleado>()
            {
                new Empleado()
                {
                    Id          = 1,
                    Nombre      = "Nombre 1",
                    Apellido    = "Apellido 1",
                },
                new Empleado()
                {
                    Id          = 2,
                    Nombre      = "Nombre 2",
                    Apellido    = "Apellido 2",
                },
                new Empleado()
                {
                    Id          = 3,
                    Nombre      = "Nombre 3",
                    Apellido    = "Apellido 3",
                },
                new Empleado()
                {
                    Id          = 4,
                    Nombre      = "Nombre 4",
                    Apellido    = "Apellido 4",
                },
                new Empleado()
                {
                    Id          = 5,
                    Nombre      = "Nombre 5",
                    Apellido    = "Apellido 5",
                },
                new Empleado()
                {
                    Id          = 6,
                    Nombre      = "Nombre 6",
                    Apellido    = "Apellido 6",
                },
                new Empleado()
                {
                    Id          = 7,
                    Nombre      = "Nombre 7",
                    Apellido    = "Apellido 7",
                },
                new Empleado()
                {
                    Id          = 8,
                    Nombre      = "Nombre 8",
                    Apellido    = "Apellido 8",
                },
                new Empleado()
                {
                    Id          = 9,
                    Nombre      = "Nombre 9",
                    Apellido    = "Apellido 9",
                },
                new Empleado()
                {
                    Id          = 10,
                    Nombre      = "Nombre 10",
                    Apellido    = "Apellido 10",
                },

            }; 
        }
    } 
}
