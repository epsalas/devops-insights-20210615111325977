using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FyJCel.Models
{
    [Table("t_reclamos")]
    public class Reclamo{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        
        [Column("id_pedido")]
        public int id_pedido { get; set; }

        
        [Column("comentario")]
        public string comentario { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }
        
        [Column("usuario")]
        public string usuario { get; set; }

        [NotMapped]
        public string Mensaje { get; set; }
    }

}