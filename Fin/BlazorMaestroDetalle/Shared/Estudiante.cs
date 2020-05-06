using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMaestroDetalle.Shared
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>();
    }
}
