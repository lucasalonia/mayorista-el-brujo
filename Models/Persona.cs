using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mayorista_el_brujo.Models
{
    [Table("personas")]
    public class Persona
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [Column("apellido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        [Column("dni")]
        public string Dni { get; set; }

        [Required]
        [StringLength(50)]
        [Column("telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Column("estado")]
        public string Estado { get; set; } = "ACTIVO";

        [Required]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        [Column("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;


    }
}
