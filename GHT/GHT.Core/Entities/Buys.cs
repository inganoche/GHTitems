using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Core.Entities
{
    [Table("Buys")]
    public class Buys
    {
        [Key]
        public int id { get; set; }
        public int idItem { get; set; }
        public DateTime dateBuy { get; set; }
        public int quantity { get; set; }

        [ForeignKey("ItemId")]
        public Items Items { get; set; }
    }
}
