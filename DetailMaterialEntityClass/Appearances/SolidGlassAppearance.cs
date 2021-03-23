using DetailMaterialEntityClass.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 实心玻璃外观
    /// </summary>
    public class SolidGlassAppearance : AppearanceBase
    {
        public SolidGlass SolidGlass { get; set; }
        public SolidGlassReliefPattern SolidGlassReliefPattern { get; set; }

        public SolidGlassAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            SolidGlass = new SolidGlass(keyValuesList);
            SolidGlassReliefPattern = new SolidGlassReliefPattern(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public SolidGlassAppearance()
        {

        }
    }

    public enum ColorType
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
        Grey,
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
        Bronze,
        /// <summary>
        /// 自定义
        /// </summary>
        Userdefined
    }

    /// <summary>
    /// 实体玻璃
    /// </summary>
    public class SolidGlass
    {
        /// <summary>
        /// 颜色类型
        /// </summary>
        public ColorType ColorType { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }
        /// <summary>
        /// 反射
        /// </summary>
        public int Reflect { get; set; }
        /// <summary>
        /// 折射
        /// </summary>
        public double Refraction { get; set; }
        /// <summary>
        /// 粗糙度
        /// </summary>
        public double Roughness { get; set; }

        public SolidGlass(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            ColorType = mainDict.ContainsKey("solidglass_transmittance") ? (ColorType)int.Parse(mainDict["solidglass_transmittance"]) : ColorType.Userdefined;
            Color = new Color(mainDict.ContainsKey("solidglass_transmittance_custom_color") ? mainDict["solidglass_transmittance_custom_color"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "solidglass_transmittance_custom_color");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            Reflect = mainDict.ContainsKey("solidglass_reflectance") ? (int)Math.Round(double.Parse(mainDict["solidglass_reflectance"]) * 100d) : 0;
            Refraction = mainDict.ContainsKey("solidglass_refr_ior") ? double.Parse(mainDict["solidglass_refr_ior"]) : 0d;
            Roughness = mainDict.ContainsKey("solidglass_glossiness") ? double.Parse(mainDict["solidglass_glossiness"]) : 0d;
        }

        public SolidGlass()
        {

        }
    }

    public enum SolidGlassReliefPatternType
    {
        Non = 0,
        /// <summary>
        /// 波纹
        /// </summary>
        Ripple = 1,
        /// <summary>
        /// 波状
        /// </summary>
        Undulating,
        /// <summary>
        /// 自定义
        /// </summary>
        Userdefined,
    }

    /// <summary>
    /// 浮雕图案
    /// </summary>
    public class SolidGlassReliefPattern
    {
        /// <summary>
        /// 是否勾选浮雕图案
        /// </summary>
        public bool UseReliefPattern { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public SolidGlassReliefPatternType SolidGlassReliefPatternType { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public double Amount { get; set; }

        public SolidGlassReliefPattern(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseReliefPattern = mainDict.ContainsKey("solidglass_bump_enable") ? int.Parse(mainDict["solidglass_bump_enable"]) != 0 : false;
            if (UseReliefPattern)
            {
                SolidGlassReliefPatternType = mainDict.ContainsKey("solidglass_bump_enable") ? (SolidGlassReliefPatternType)int.Parse(mainDict["solidglass_bump_enable"]) : SolidGlassReliefPatternType.Ripple;
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "solidglass_bump_enable");
                if (imageDict != null)
                {
                    Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Amount = mainDict.ContainsKey("solidglass_bump_amount") ? double.Parse(mainDict["solidglass_bump_amount"]) : 0d;
            }
        }

        public SolidGlassReliefPattern()
        {

        }
    }
}
