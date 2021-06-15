using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FyJCel.Models
{
    [Table("t_producto")]
    public class Producto{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Column("prod_nombre")]
        public string prod_nombre { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Column("prod_detalle")]
        public string prod_detalle { get; set; }

        [Column("prod_imagen")]
        public string prod_imagen { get; set; }

        [Column("prod_precio")]
        public decimal prod_precio { get; set; }

        [NotMapped]
        public string Mensaje { get; set; }
    }

}