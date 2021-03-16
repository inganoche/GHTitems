using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Core.Entities
{
    [Table("Items")]
    public class Items
    {
        [Key]
        public int id { get; set; }
        public string nameItems { get; set; }
        public float unitValue { get; set; }
        public int residue { get; set; }

    }
}
