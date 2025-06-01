using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public double Rating { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
