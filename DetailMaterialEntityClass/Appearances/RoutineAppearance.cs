using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 常规外观
    /// </summary>
    public class RoutineAppearance : AppearanceBase
    {
        /// <summary>
        /// 常规
        /// </summary>
        public Routine Routine { get; set; }

        /// <summary>
        /// 反射率
        /// </summary>
        public Reflectivity Reflectivity { get; set; }

        /// <summary>
        /// 透明度
        /// </summary>
        public Transparency Transparency { get; set; }

        /// <summary>
        /// 剪切
        /// </summary>
        public Shear Shear { get; set; }

        /// <summary>
        /// 自发光
        /// </summary>
        public SelfLuminous SelfLuminous { get; set; }

        /// <summary>
        /// 凹凸
        /// </summary>
        public ConcaveConvex ConcaveConvex { get; set; }

        public RoutineAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Routine = new Routine(keyValuesList);
            Reflectivity = new Reflectivity(keyValuesList);
            Transparency = new Transparency(keyValuesList);
            Shear = new Shear(keyValuesList);
            SelfLuminous = new SelfLuminous(keyValuesList);
            ConcaveConvex = new ConcaveConvex(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public RoutineAppearance()
        {

        }
    }

    /// <summary>
    /// 高光
    /// </summary>
    public enum Highlight
    {
        /// <summary>
        /// 非金属
        /// </summary>
        Nonmetal = 0,
        /// <summary>
        /// 金属
        /// </summary>
        Metal = 1,
    }

    /// <summary>
    /// 常规
    /// </summary>
    public class Routine
    {
        /// <summary>
        /// 颜色 generic_diffuse
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 图像褪色 generic_diffuse_image_fade
        /// </summary>
        public int ColorFading { get; set; }

        /// <summary>
        /// 光泽度 generic_glossiness
        /// </summary>
        public int Glossiness { get; set; }

        /// <summary>
        /// 高光 generic_is_metal
        /// </summary>
        public Highlight Highlight { get; set; }

        public Routine(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            Color = new Color(mainDict.ContainsKey("generic_diffuse") ? mainDict["generic_diffuse"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_diffuse");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            ColorFading = mainDict.ContainsKey("generic_diffuse_image_fade") ? (int)Math.Round(double.Parse(mainDict["generic_diffuse_image_fade"]) * 100) : 0;
            Glossiness = mainDict.ContainsKey("generic_glossiness") ? (int)Math.Round(double.Parse(mainDict["generic_glossiness"]) * 100) : 0;
            Highlight = mainDict.ContainsKey("generic_is_metal") ? (bool.Parse(mainDict["generic_is_metal"]) ? Highlight.Metal : Highlight.Nonmetal) : Highlight.Nonmetal;
        }

        public Routine()
        {

        }
    }

    /// <summary>
    /// 反射率
    /// </summary>
    public class Reflectivity
    {
        /// <summary>
        /// 使用反射率
        /// </summary>
        public bool UseReflectivity { get; set; }

        /// <summary>
        /// 直接 generic_reflectivity_at_0deg * 100
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 直接图像
        /// </summary>
        public ImageBase DirectImage { get; set; }

        /// <summary>
        /// 倾斜 generic_reflectivity_at_90deg * 100
        /// </summary>
        public int Sloping { get; set; }

        /// <summary>
        /// 倾斜图像
        /// </summary>
        public ImageBase SpopingImage { get; set; }

        public Reflectivity(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            Direct = mainDict.ContainsKey("generic_reflectivity_at_0deg") ? (int)Math.Round(double.Parse(mainDict["generic_reflectivity_at_0deg"]) * 100) : 0;
            Sloping = mainDict.ContainsKey("generic_reflectivity_at_90deg") ? (int)Math.Round(double.Parse(mainDict["generic_reflectivity_at_90deg"]) * 100) : 0;
            UseReflectivity = Direct != 0 || Sloping != 0;
            var directImageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_reflectivity_at_0deg");
            if (directImageDict != null)
            {
                DirectImage = ImageBase.Init(directImageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { directImageDict }).ToList());
            }
            var slpoingImageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_reflectivity_at_90deg");
            if (slpoingImageDict != null)
            {
                SpopingImage = ImageBase.Init(slpoingImageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { slpoingImageDict }).ToList());
            }
        }

        public Reflectivity()
        {

        }
    }

    /// <summary>
    /// 折射
    /// </summary>
    public enum Refraction
    {
        /// <summary>
        /// 空气
        /// </summary>
        Air,
        /// <summary>
        /// 水
        /// </summary>
        Water,
        /// <summary>
        /// 酒精
        /// </summary>
        EthylAlcohol,
        /// <summary>
        /// 石英
        /// </summary>
        Quartz,
        /// <summary>
        /// 玻璃
        /// </summary>
        Glass,
        /// <summary>
        /// 钻石
        /// </summary>
        Diamond,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }


    /// <summary>
    /// 透明度
    /// </summary>
    public class Transparency
    {
        /// <summary>
        /// 使用透明度
        /// </summary>
        public bool UseTransparency { get; set; }

        /// <summary>
        /// 数量 generic_transparency
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 图像褪色 generic_transparency_image_fade
        /// </summary>
        public int ImageFading { get; set; }

        /// <summary>
        /// 半透明度 generic_refraction_translucency_weight * 100
        /// </summary>
        public int HalfTransparency { get; set; }

        /// <summary>
        /// 半透明度图像
        /// </summary>
        public ImageBase HalfTransparencyImage { get; set; }

        /// <summary>
        /// 折射
        /// </summary>
        public Refraction Refraction { get; set; }

        /// <summary>
        /// 折射值 generic_refraction_index
        /// </summary>
        public double RefractionValue { get; set; }

        public Transparency(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseTransparency = mainDict.ContainsKey("generic_transparency") ? (int)Math.Round(double.Parse(mainDict["generic_transparency"]) * 100) != 0 : false;
            if (UseTransparency)
            {
                Count = mainDict.ContainsKey("generic_transparency") ? (int)Math.Round(double.Parse(mainDict["generic_transparency"]) * 100) : 0;
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_transparency");
                if (imageDict != null)
                {
                    Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                ImageFading = mainDict.ContainsKey("generic_transparency_image_fade") ? (int)Math.Round(double.Parse(mainDict["generic_transparency_image_fade"]) * 100) : 0;
                HalfTransparency = mainDict.ContainsKey("generic_refraction_translucency_weight") ? (int)Math.Round(double.Parse(mainDict["generic_refraction_translucency_weight"]) * 100) : 0;
                var halfImageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_refraction_translucency_weight");
                if (halfImageDict != null)
                {
                    HalfTransparencyImage = ImageBase.Init(halfImageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { halfImageDict }).ToList());
                }
                RefractionValue = mainDict.ContainsKey("generic_refraction_index") ? double.Parse(mainDict["generic_refraction_index"]) : 0d;
            }
        }

        public Transparency()
        {

        }
    }

    /// <summary>
    /// 剪切
    /// </summary>
    public class Shear
    {
        /// <summary>
        /// 使用剪切
        /// </summary>
        public bool UseShear { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        public Shear(List<Dictionary<string, string>> keyValuesList)
        {
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_cutout_opacity");
            if (imageDict != null)
            {
                UseShear = true;
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
        }

        public Shear()
        {

        }
    }

    /// <summary>
    /// 亮度类型
    /// </summary>
    public enum LuminanceType
    {
        /// <summary>
        /// 暗发光
        /// </summary>
        DarkLight,
        /// <summary>
        /// LED面板
        /// </summary>
        LEDFaceplate,
        /// <summary>
        /// LED屏幕
        /// </summary>
        LEDScreen,
        /// <summary>
        /// 手机屏幕
        /// </summary>
        MobileScreen,
        /// <summary>
        /// CRT电视
        /// </summary>
        CRTTelevision,
        /// <summary>
        /// 灯罩外部
        /// </summary>
        ChimneyOutside,
        /// <summary>
        /// 灯罩内部
        /// </summary>
        ChimneyInside,
        /// <summary>
        /// 桌灯
        /// </summary>
        DeskLamp,
        /// <summary>
        /// 卤素灯
        /// </summary>
        Halogen,
        /// <summary>
        /// 磨砂灯
        /// </summary>
        FrostedGlassLamp,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 色温类型
    /// </summary>
    public enum ColorTemperatureType
    {
        /// <summary>
        /// 蜡烛
        /// </summary>
        Candle,
        /// <summary>
        /// 白炽灯
        /// </summary>
        IncandescentLamp,
        /// <summary>
        /// 泛光灯
        /// </summary>
        Floodlight,
        /// <summary>
        /// 月光
        /// </summary>
        Moonlight,
        /// <summary>
        /// 日光(暖)
        /// </summary>
        WarmSunlight,
        /// <summary>
        /// 日光(冷)
        /// </summary>
        ColdSunlight,
        /// <summary>
        /// 氙弧灯
        /// </summary>
        XenonArcLamp,
        /// <summary>
        /// TV屏幕
        /// </summary>
        TVScreen,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 自发光
    /// </summary>
    public class SelfLuminous
    {
        /// <summary>
        /// 使用自发光
        /// </summary>
        public bool UseSelfLuminous { get; set; }

        /// <summary>
        /// 过滤颜色 generic_self_illum_filter_map
        /// </summary>
        public Color FilterColor { get; set; }

        /// <summary>
        /// 过滤颜色图像
        /// </summary>
        public ImageBase FilterColorImage { get; set; }

        /// <summary>
        /// 亮度类型
        /// </summary>
        public LuminanceType LuminanceType { get; set; }

        /// <summary>
        /// 亮度 generic_self_illum_luminance
        /// </summary>
        public double Luminance { get; set; }

        /// <summary>
        /// 色温类型
        /// </summary>
        public ColorTemperatureType ColorTemperatureType { get; set; }

        /// <summary>
        /// 色温 generic_self_illum_color_temperature
        /// </summary>
        public double ColorTemperature { get; set; }

        public SelfLuminous(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseSelfLuminous = mainDict.ContainsKey("generic_self_illum_luminance") ? double.Parse(mainDict["generic_self_illum_luminance"]) != 0 : false;
            if (UseSelfLuminous)
            {
                FilterColor = new Color(mainDict.ContainsKey("generic_self_illum_filter_map") ? mainDict["generic_self_illum_filter_map"] : string.Empty);
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_self_illum_filter_map");
                if (imageDict != null)
                {
                    FilterColorImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Luminance = mainDict.ContainsKey("generic_self_illum_luminance") ? double.Parse(mainDict["generic_self_illum_luminance"]) : 0;
                ColorTemperature = mainDict.ContainsKey("generic_self_illum_color_temperature") ? double.Parse(mainDict["generic_self_illum_color_temperature"]) : 0;
            }
        }

        public SelfLuminous()
        {

        }
    }

    /// <summary>
    /// 凹凸
    /// </summary>
    public class ConcaveConvex
    {
        /// <summary>
        /// 使用凹凸
        /// </summary>
        public bool UseConcaveConvex { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 数量 generic_bump_amount
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 数量图像
        /// </summary>
        public ImageBase CountImage { get; set; }

        public ConcaveConvex(List<Dictionary<string, string>> keyValuesList)
        {
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_bump_map");
            if (imageDict != null)
            {
                UseConcaveConvex = true;
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            var mainDict = keyValuesList.First();
            Count = mainDict.ContainsKey("generic_bump_amount") ? (int)Math.Round(double.Parse(mainDict["generic_bump_amount"]) * 100) : 0;
            var countImageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "generic_bump_amount");
            if (countImageDict != null)
            {
                CountImage = ImageBase.Init(countImageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { countImageDict }).ToList());
            }
        }

        public ConcaveConvex()
        {

        }
    }
}
