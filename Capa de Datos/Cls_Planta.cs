using System;

namespace ProyectoPlantas.CapaDatos
{
    public class Cls_Planta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        
        public int CategoriaId { get; set; }

        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}

