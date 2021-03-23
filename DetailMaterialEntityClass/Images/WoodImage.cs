using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 木材
    /// </summary>
    public class WoodImage : ImageBase
    {
        /// <summary>
        /// 颜色1 wood_Color1
        /// </summary>
        public Color Color1 { get; set; }

        /// <summary>
        /// 颜色2 wood_Color2
        /// </summary>
        public Color Color2 { get; set; }

        /// <summary>
        /// 径向噪波 wood_RadialNoise
        /// </summary>
        public double RadialNoise { get; set; }

        /// <summary>
        /// 轴向噪波 wood_AxialNoise
        /// </summary>
        public double AxialNoise { get; set; }

        /// <summary>
        /// 颗粒密度 wood_Thickness
        /// </summary>
        public double GgrainDensity { get; set; }

        public WoodImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            Color1 = new Color(dict.ContainsKey("wood_Color1") ? dict["wood_Color1"] : string.Empty);
            Color2 = new Color(dict.ContainsKey("wood_Color2") ? dict["wood_Color2"] : string.Empty);
            RadialNoise = dict.ContainsKey("wood_RadialNoise") ? double.Parse(dict["wood_RadialNoise"]) : 0;
            AxialNoise = dict.ContainsKey("wood_AxialNoise") ? double.Parse(dict["wood_AxialNoise"]) : 0;
            GgrainDensity = dict.ContainsKey("wood_Thickness") ? double.Parse(dict["wood_Thickness"]) : 0;
        }

        public WoodImage()
        {

        }
    }
}
