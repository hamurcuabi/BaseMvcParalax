using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseMvcParalax.Models
{
    public class HomeAll
    {
        public ContactU ContactUs { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public IEnumerable<Slider> Sliders { get; set; }

        public IEnumerable<SliderText> SliderTexts { get; set; }

        public IEnumerable<TopSlider> TopSliders { get; set; }



    }
}