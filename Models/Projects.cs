using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseMvcParalax.Models
{
    public class Projects
    {
        public Project current { get; set; }
        public Project next { get; set; }
        public Project before { get; set; }
    }
}