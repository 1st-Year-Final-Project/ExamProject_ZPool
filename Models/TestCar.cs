using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Models
{
    public class TestCar
    {
        [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }

        public int UserId { get; set; }

    }
}
