using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FyJCel.Models
{
    [Table("t_pedido")]
    public class Pedido{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter producto id")]
        [Column("pedi_id_produ")]
        public int pedi_id_produ { get; set; }

        [Required(ErrorMessage = "Please enter producto id")]
        [Column("pedi_id_conta")]
        public int pedi_id_conta { get; set; }

        [Required(ErrorMessage = "Please enter el precio")]
        [Column("pedi_precio")]
        public decimal pedi_precio { get; set; }

        [Column("pedi_cantidad")]
        public int pedi_cantidad { get; set; }

        [Column("pedi_nombres")]
        public string pedi_nombres { get; set; }

        [Column("pedi_domicilio")]
        public string pedi_domicilio { get; set; }
        
        [Column("pedi_referenc")]
        public string pedi_referenc { get; set; }
        [NotMapped]
        public string Mensaje { get; set; }

        [Column("pedi_estado")]
        public string pedi_estado { get; set; }

        [Column("pedi_fecha")]
        public DateTime pedi_fecha { get; set; }
    }

}