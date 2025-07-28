using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string? Picture { get; set; }

        public string? Description { get; set; }
    }
}
