using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 颜色
    /// </summary>
    public class Color
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public double Alpha { get; set; }

        public Color(string rgba = null)
        {
            if (string.IsNullOrEmpty(rgba))
            {
                Red = 1;
                Green = 1;
                Blue = 1;
                Alpha = 1;
            }
            else
            {
                if (rgba.Contains(","))
                {
                    var array = rgba.Split(',');
                    Red = double.Parse(array[0]);
                    Green = double.Parse(array[1]);
                    Blue = double.Parse(array[2]);
                    Alpha = double.Parse(array[3]);
                }
                else if (rgba.Contains(" "))
                {
                    var array = rgba.Split(' ');
                    Red = double.Parse(array[0]);
                    Green = double.Parse(array[1]);
                    Blue = double.Parse(array[2]);
                    Alpha = double.Parse(array[3]);
                }
                else
                {
                    Red = 1;
                    Green = 1;
                    Blue = 1;
                    Alpha = 1;
                }
            }
        }

        public Color()
        {

        }

        public override string ToString()
        {
            return Red + "," + Green + "," + Blue + "," + Alpha;
        }

        public byte[] ToByteArray()
        {
            return new byte[] { (byte)(Red * 255), (byte)(Green * 255), (byte)(Blue * 255), (byte)(Alpha * 255) };
        }
    }
}
