using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHT.Core.DTOs
{
    public class BuysDto
    {
        [Key]
        public int id { get; set; }
        public int idItem { get; set; }
        public DateTime dateBuy { get; set; }
        public int quantity { get; set; }
    }
}
