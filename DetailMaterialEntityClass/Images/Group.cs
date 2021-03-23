using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    public class Group
    {
        public Color Color { get; set; }
        public InterpolationType InterpolationType { get; set; }
        public double Position { get; set; }

        public Group()
        {

        }

        public Group(Color color, InterpolationType interpolationType, double position)
        {
            Color = color;
            InterpolationType = InterpolationType;
            Position = position;
        }
    }
}
