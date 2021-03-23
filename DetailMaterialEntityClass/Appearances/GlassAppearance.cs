using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 玻璃外观
    /// </summary>
    public class GlassAppearance : AppearanceBase
    {
        /// <summary>
        /// 玻璃
        /// </summary>
        public Glass Glass { get; set; }

        public GlassAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Glass = new Glass(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public GlassAppearance()
        {

        }
    }

    /// <summary>
    /// 玻璃颜色
    /// </summary>
    public enum GlassColor
    {
        /// <summary>
        /// 清晰
        /// </summary>
        Distinct,
        /// <summary>
        /// 绿色
        /// </summary>
        Green,
        /// <summary>
        /// 灰色
        /// </summary>
        Gray,
        /// <summary>
        /// 蓝色
        /// </summary>
        Blue,
        /// <summary>
        /// 青绿色
        /// </summary>
        Turquoise,
        /// <summary>
        /// 青铜色
        /// </summary>
        Aeneous,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 玻璃
    /// </summary>
    public class Glass
    {
        /// <summary>
        /// 玻璃颜色 glazing_transmittance_color
        /// </summary>
        public GlassColor GlassColor { get; set; }

        /// <summary>
        /// 自定义颜色 glazing_transmittance_map
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 反射 glazing_reflectance * 100
        /// </summary>
        public int Reflect { get; set; }

        /// <summary>
        /// 玻璃片数 glazing_no_levels
        /// </summary>
        public int GlassCount { get; set; }

        public Glass(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            GlassColor = mainDict.ContainsKey("glazing_transmittance_color") ? (GlassColor)int.Parse(mainDict["glazing_transmittance_color"]) : GlassColor.Distinct;
            Color = new Color(mainDict.ContainsKey("glazing_transmittance_map") ? mainDict["glazing_transmittance_map"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "glazing_transmittance_map");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            Reflect = mainDict.ContainsKey("glazing_reflectance") ? (int)(Math.Round(double.Parse(mainDict["glazing_reflectance"]), 2) * 100) : 10;
            GlassCount = mainDict.ContainsKey("glazing_no_levels") ? (int)(Math.Round(double.Parse(mainDict["glazing_no_levels"]), 2) * 100) : 2;
        }

        public Glass()
        {

        }
    }
}
