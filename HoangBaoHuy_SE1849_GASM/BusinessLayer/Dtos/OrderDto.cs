using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public decimal OrderAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
