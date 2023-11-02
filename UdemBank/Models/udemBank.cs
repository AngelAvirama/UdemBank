using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemBank
{
    public class udemBank
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int comision { get; set; }
    }
}
