using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mayorista_el_brujo.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("persona_id")]
        public int PersonaId { get; set; }

        [ForeignKey("PersonaId")]
        public Persona Persona { get; set; }

        [Required]
        [Column("nombre_usuario")]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [Column("rol")]
        [EnumDataType(typeof(RolUsuario))]
        public RolUsuario Rol { get; set; }

        
        [Column("estado")]
        [StringLength(20)]
        public string Estado { get; set; } = "ACTIVO";

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

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

   public enum RolUsuario
{
    admin = 0,
    empleado = 1
}
}