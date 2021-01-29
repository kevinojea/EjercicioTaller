using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioTaller.Models
{
    public abstract class Vehiculo
    {
        [Key]
        public int ID { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Patente { get; set; }

        public ICollection<Desperfecto> Desperfectos { get; set; }
    }
}
