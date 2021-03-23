using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 大理石
    /// </summary>
    public class MarbleImage : ImageBase
    {
        /// <summary>
        /// 石料颜色 marble_Color1
        /// </summary>
        public Color StoneColor { get; set; }

        /// <summary>
        /// 纹理颜色 marble_Color2
        /// </summary>
        public Color TextureColor { get; set; }

        /// <summary>
        /// 纹理间距 marble_Size
        /// </summary>
        public double TextureDistance { get; set; }

        /// <summary>
        /// 纹理宽度 marble_Width
        /// </summary>
        public double TextureWidth { get; set; }

        public MarbleImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            StoneColor = new Color(dict.ContainsKey("marble_Color1") ? dict["marble_Color1"] : string.Empty);
            TextureColor = new Color(dict.ContainsKey("marble_Color2") ? dict["marble_Color2"] : string.Empty);
            TextureDistance = dict.ContainsKey("marble_Size") ? double.Parse(dict["marble_Size"]) : 0;
            TextureWidth = dict.ContainsKey("marble_Width") ? double.Parse(dict["marble_Width"]) : 0;
        }

        public MarbleImage()
        {

        }
    }
}
