using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MayoristaElBrujo.Models
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

        [Column("creado_por")]
        public int? CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public Usuario? CreadoPor { get; set; }

        [Column("modificado_por")]
        public int? ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public Usuario? ModificadoPor { get; set; }
    }
}
