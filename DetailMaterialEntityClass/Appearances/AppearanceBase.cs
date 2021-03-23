using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 外观类型
    /// </summary>
    public enum AppearanceType
    {
        /// <summary>
        /// 混凝土
        /// </summary>
        Concrete,
        /// <summary>
        /// 玻璃
        /// </summary>
        Glazing,
        /// <summary>
        /// 砖石
        /// </summary>
        Masonry,
        /// <summary>
        /// 砖石
        /// </summary>
        MasonryCMU,
        /// <summary>
        /// 金属
        /// </summary>
        Metal,
        /// <summary>
        /// 金属漆
        /// </summary>
        MetallicPaint,
        /// <summary>
        /// 金属漆
        /// </summary>
        MetalPaint,
        /// <summary>
        /// 塑料
        /// </summary>
        Plastic,
        /// <summary>
        /// 塑料
        /// </summary>
        PlasticVinyl,
        /// <summary>
        /// 常规
        /// </summary>
        Generic,
        /// <summary>
        /// 常规
        /// </summary>
        ACADGen,
        /// <summary>
        /// 石料
        /// </summary>
        Stone,
        /// <summary>
        /// 墙漆
        /// </summary>
        WallPaint,
        /// <summary>
        /// 墙漆
        /// </summary>
        Paint,
        /// <summary>
        /// 木料
        /// </summary>
        Wood,
        /// <summary>
        /// 木料
        /// </summary>
        Hardwood,
        /// <summary>
        /// 陶瓷
        /// </summary>
        Ceramic,
        /// <summary>
        /// 实体玻璃
        /// </summary>
        Glass,
        /// <summary>
        /// 水
        /// </summary>
        Water,
    }

    [XmlInclude(typeof(ConcreteAppearance))]
    [XmlInclude(typeof(GlassAppearance))]
    [XmlInclude(typeof(MasonryAppearance))]
    [XmlInclude(typeof(MetalAppearance))]
    [XmlInclude(typeof(MetallicPaintAppearance))]
    [XmlInclude(typeof(PlasticAppearance))]
    [XmlInclude(typeof(RoutineAppearance))]
    [XmlInclude(typeof(StoneAppearance))]
    [XmlInclude(typeof(WallPaintAppearance))]
    [XmlInclude(typeof(WoodAppearance))]
    [XmlInclude(typeof(CeramicAppearance))]
    [XmlInclude(typeof(SolidGlassAppearance))]
    [XmlInclude(typeof(WaterAppearance))]
    [KnownType(typeof(ConcreteAppearance))]
    [KnownType(typeof(GlassAppearance))]
    [KnownType(typeof(MasonryAppearance))]
    [KnownType(typeof(MetalAppearance))]
    [KnownType(typeof(MetallicPaintAppearance))]
    [KnownType(typeof(PlasticAppearance))]
    [KnownType(typeof(RoutineAppearance))]
    [KnownType(typeof(StoneAppearance))]
    [KnownType(typeof(WallPaintAppearance))]
    [KnownType(typeof(WoodAppearance))]
    [KnownType(typeof(CeramicAppearance))]
    [KnownType(typeof(SolidGlassAppearance))]
    [KnownType(typeof(WaterAppearance))]
    /// <summary>
    /// 外观基类
    /// </summary>
    public class AppearanceBase
    {
        /// <summary>
        /// 信息
        /// </summary>
        public Information Information { get; set; }

        /// <summary>
        /// 染色
        /// </summary>
        public Dye Dye { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public AppearanceType Type { get; set; }

        public static AppearanceBase Init(string assetType, List<Dictionary<string, string>> keyValuesList)
        {
            if (keyValuesList.Count == 0)
            {
                return null;
            }

            Enum.TryParse(assetType, out AppearanceType appearanceType);
            switch (appearanceType)
            {
                case AppearanceType.Concrete:
                    return new ConcreteAppearance(appearanceType, keyValuesList);
                case AppearanceType.Glazing:
                    return new GlassAppearance(appearanceType, keyValuesList);
                case AppearanceType.Masonry:
                case AppearanceType.MasonryCMU:
                    return new MasonryAppearance(appearanceType, keyValuesList);
                case AppearanceType.Metal:
                    return new MetalAppearance(appearanceType, keyValuesList);
                case AppearanceType.MetallicPaint:
                case AppearanceType.MetalPaint:
                    return new MetallicPaintAppearance(appearanceType, keyValuesList);
                case AppearanceType.Plastic:
                case AppearanceType.PlasticVinyl:
                    return new PlasticAppearance(appearanceType, keyValuesList);
                case AppearanceType.Generic:
                case AppearanceType.ACADGen:
                    return new RoutineAppearance(appearanceType, keyValuesList);
                case AppearanceType.Stone:
                    return new StoneAppearance(appearanceType, keyValuesList);
                case AppearanceType.WallPaint:
                case AppearanceType.Paint:
                    return new WallPaintAppearance(appearanceType, keyValuesList);
                case AppearanceType.Wood:
                case AppearanceType.Hardwood:
                    return new WoodAppearance(appearanceType, keyValuesList);
                case AppearanceType.Ceramic:
                    return new CeramicAppearance(appearanceType, keyValuesList);
                case AppearanceType.Glass:
                    return new SolidGlassAppearance(appearanceType, keyValuesList);
                case AppearanceType.Water:
                    return new WaterAppearance(appearanceType, keyValuesList);
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// 信息
    /// </summary>
    public class Information
    {
        /// <summary>
        /// 名称 UIName
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 说明 description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 关键字 keyword
        /// </summary>
        public string Keywords { get; set; }

        public Information(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            Name = mainDict.ContainsKey("UIName") ? mainDict["UIName"] : string.Empty;
            Description = mainDict.ContainsKey("description") ? mainDict["description"] : string.Empty;
            Keywords = mainDict.ContainsKey("keyword") ? mainDict["keyword"] : string.Empty;
        }

        public Information()
        {

        }
    }

    /// <summary>
    /// 染色
    /// </summary>
    public class Dye
    {
        /// <summary>
        /// 使用染色 common_Tint_toggle
        /// </summary>
        public bool UseDye { get; set; }

        /// <summary>
        /// 染色 common_Tint_color
        /// </summary>
        public Color DyeColor { get; set; }

        public Dye(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseDye = mainDict.ContainsKey("common_Tint_toggle") ? bool.Parse(mainDict["common_Tint_toggle"]) : false;
            DyeColor = new Color(mainDict.ContainsKey("common_Tint_color") ? mainDict["common_Tint_color"] : string.Empty);
        }

        public Dye()
        {

        }
    }
}
