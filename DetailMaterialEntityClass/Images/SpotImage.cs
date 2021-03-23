using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 斑点
    /// </summary>
    public class SpotImage : ImageBase
    {
        /// <summary>
        /// 颜色1 speckle_Color1
        /// </summary>
        public Color Color1 { get; set; }

        /// <summary>
        /// 颜色2 speckle_Color2
        /// </summary>
        public Color Color2 { get; set; }

        /// <summary>
        /// 大小 speckle_Size
        /// </summary>
        public double Size { get; set; }

        public SpotImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            Color1 = new Color(dict.ContainsKey("speckle_Color1") ? dict["speckle_Color1"] : string.Empty);
            Color2 = new Color(dict.ContainsKey("speckle_Color2") ? dict["speckle_Color2"] : string.Empty);
            Size = dict.ContainsKey("speckle_Size") ? double.Parse(dict["speckle_Size"]) : 0;
        }

        public SpotImage()
        {

        }
    }
}
