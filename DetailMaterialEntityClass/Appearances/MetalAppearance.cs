using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 金属外观
    /// </summary>
    public class MetalAppearance : AppearanceBase
    {
        /// <summary>
        /// 金属
        /// </summary>
        public Metal Metal { get; set; }

        /// <summary>
        /// 金属浮雕图案
        /// </summary>
        public MetalReliefPattern MetalReliefPattern { get; set; }

        /// <summary>
        /// 金属剪切
        /// </summary>
        public MetalShear MetalShear { get; set; }

        public MetalAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Metal = new Metal(keyValuesList);
            MetalReliefPattern = new MetalReliefPattern(keyValuesList);
            MetalShear = new MetalShear(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public MetalAppearance()
        {

        }
    }

    /// <summary>
    /// 金属类型
    /// </summary>
    public enum MetalType
    {
        /// <summary>
        /// 铝
        /// </summary>
        Aluminum = 0,
        /// <summary>
        /// 阳极氧化铝
        /// </summary>
        Anodised_Aluminium = 1,
        /// <summary>
        /// 铬
        /// </summary>
        Chromium = 2,
        /// <summary>
        /// 铜
        /// </summary>
        Cuprum = 3,
        /// <summary>
        /// 黄铜
        /// </summary>
        Brass = 4,
        /// <summary>
        /// 青铜
        /// </summary>
        Bronze = 5,
        /// <summary>
        /// 不锈钢
        /// </summary>
        Stainless_Steel = 6,
        /// <summary>
        /// 锌
        /// </summary>
        Zinc = 7,
    }

    /// <summary>
    /// 金属饰面
    /// </summary>
    public enum MetalFinish
    {
        /// <summary>
        /// 抛光
        /// </summary>
        Full_polish = 0,
        /// <summary>
        /// 半抛光
        /// </summary>
        Semi_polish = 1,
        /// <summary>
        /// 缎光
        /// </summary>
        Satin = 2,
        /// <summary>
        /// 拉丝
        /// </summary>
        Drawbench = 3,
    }

    /// <summary>
    /// 金属
    /// </summary>
    public class Metal
    {
        /// <summary>
        /// 类型 metal_type
        /// </summary>
        public MetalType MetalType { get; set; }

        /// <summary>
        /// 饰面 metal_finish
        /// </summary>
        public MetalFinish MetalFinish { get; set; }

        /// <summary>
        /// 颜色 metal_color
        /// </summary>
        public Color Color { get; set; }

        public Metal(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            MetalType = mainDict.ContainsKey("metal_type") ? (MetalType)int.Parse(mainDict["metal_type"]) : MetalType.Aluminum;
            MetalFinish = mainDict.ContainsKey("metal_finish") ? (MetalFinish)int.Parse(mainDict["metal_finish"]) : MetalFinish.Full_polish;
            Color = new Color(mainDict.ContainsKey("metal_color") ? mainDict["metal_color"] : string.Empty);
        }

        public Metal()
        {

        }
    }

    /// <summary>
    /// 金属浮雕图案类型
    /// </summary>
    public enum MetalReliefPatternType
    {
        Non = 0,
        /// <summary>
        /// 滚花
        /// </summary>
        Knurl = 1,
        /// <summary>
        /// 花纹板
        /// </summary>
        CheckeredPlate,
        /// <summary>
        /// 方格板
        /// </summary>
        SquarePlate,
        /// <summary>
        /// 自定义图像
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 金属浮雕图案
    /// </summary>
    public class MetalReliefPattern
    {
        /// <summary>
        /// 使用浮雕图案 metal_pattern == 0 false
        /// </summary>
        public bool UseMetalReliefPattern { get; set; }

        /// <summary>
        /// 类型 metal_pattern
        /// </summary>
        public MetalReliefPatternType ReliefPatternType { get; set; } = MetalReliefPatternType.Knurl;

        /// <summary>
        /// 自定义图像
        /// </summary>
        public ImageBase DefinedImage { get; set; }

        /// <summary>
        /// 数量 metal_pattern_height
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// 比例 metal_pattern_scale
        /// </summary>
        public double Ratio { get; set; }

        public MetalReliefPattern(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseMetalReliefPattern = mainDict.ContainsKey("metal_pattern") ? int.Parse(mainDict["metal_pattern"]) != 0 : false;
            ReliefPatternType = mainDict.ContainsKey("metal_pattern") ? (MetalReliefPatternType)int.Parse(mainDict["metal_pattern"]) : MetalReliefPatternType.Knurl;
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "metal_pattern_scale");
            if (imageDict != null)
            {
                DefinedImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            Count = mainDict.ContainsKey("metal_pattern_height") ? double.Parse(mainDict["metal_pattern_height"]) : 1d;
            Ratio = mainDict.ContainsKey("metal_pattern_scale") ? double.Parse(mainDict["metal_pattern_scale"]) : 1d;
        }

        public MetalReliefPattern()
        {

        }
    }

    /// <summary>
    /// 金属剪切类型
    /// </summary>
    public enum MetalShearType
    {
        Non = 0,
        /// <summary>
        /// 交错圆
        /// </summary>
        StaggeredRound = 1,
        /// <summary>
        /// 直圆
        /// </summary>
        StraightRound,
        /// <summary>
        /// 方形
        /// </summary>
        Square,
        /// <summary>
        /// 希腊式
        /// </summary>
        Greek,
        /// <summary>
        /// 苜蓿叶状
        /// </summary>
        AlfalfaLeaf,
        /// <summary>
        /// 六边形
        /// </summary>
        Hexagon,
        /// <summary>
        /// 用户自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 金属剪切
    /// </summary>
    public class MetalShear
    {
        /// <summary>
        /// 使用剪切 metal_perforations == 0 false
        /// </summary>
        public bool UseShear { get; set; }

        /// <summary>
        /// 剪切类型 metal_perforations
        /// </summary>
        public MetalShearType ShearType { get; set; }

        /// <summary>
        /// 自定义图像
        /// </summary>
        public ImageBase DefinedIamge { get; set; }

        /// <summary>
        /// 直径 metal_perforations_size
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// 中心间距 metal_perforations_center
        /// </summary>
        public double CenterDistance { get; set; }

        public MetalShear(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseShear = mainDict.ContainsKey("metal_perforations") ? int.Parse(mainDict["metal_perforations"]) != 0 : false;
            if (UseShear)
            {
                ShearType = mainDict.ContainsKey("metal_perforations") ? (MetalShearType)int.Parse(mainDict["metal_perforations"]) : MetalShearType.StaggeredRound;
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "metal_perforations_center");
                if (imageDict != null)
                {
                    DefinedIamge = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Diameter = mainDict.ContainsKey("metal_perforations_size") ? double.Parse(mainDict["metal_perforations_size"]) : 0.5d;
                CenterDistance = mainDict.ContainsKey("metal_perforations_center") ? double.Parse(mainDict["metal_perforations_center"]) : 0.6875d;
            }
        }

        public MetalShear()
        {

        }
    }
}
