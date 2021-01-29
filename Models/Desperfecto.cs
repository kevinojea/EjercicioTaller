using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioTaller.Models
{
    public class Desperfecto
    {
        [Key]
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public int ManoDeObra { get; set; }

        public int Tiempo { get; set; }

        [ForeignKey("Vehiculo")]
        public int VehiculoRefID { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public ICollection<Repuesto> Repuestos { get; set; }
    }
}
