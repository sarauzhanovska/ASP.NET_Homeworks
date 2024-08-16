using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain
{
    public class Location : BaseEntity
    {
        public string LocationName { get; set; }

        public string Address { get; set; }

        public DateTime OpensAt { get; set; }

        public DateTime ClosesAt { get; set; }
    }
}
