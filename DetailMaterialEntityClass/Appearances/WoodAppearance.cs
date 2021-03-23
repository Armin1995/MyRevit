using DetailMaterialEntityClass.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 木材外观
    /// </summary>
    public class WoodAppearance : AppearanceBase
    {
        /// <summary>
        /// 木材
        /// </summary>
        public Wood Wood { get; set; }

        /// <summary>
        /// 浮雕图案
        /// </summary>
        public WoodReliefPattern WoodReliefPattern { get; set; }

        public WoodAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Wood = new Wood(keyValuesList);
            WoodReliefPattern = new WoodReliefPattern(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public WoodAppearance()
        {

        }
    }

    /// <summary>
    /// 木材饰面
    /// </summary>
    public enum WoodFacing
    {
        /// <summary>
        /// 有光泽的清漆
        /// </summary>
        GlossyVarnish,
        /// <summary>
        /// 半光泽的清漆
        /// </summary>
        SemiGlossyVarnish,
        /// <summary>
        /// 绸缎清漆
        /// </summary>
        SilkinessVarnish,
        /// <summary>
        /// 未装饰
        /// </summary>
        Unadorned,
    }

    /// <summary>
    /// 木材用途
    /// </summary>
    public enum Purpose
    {
        /// <summary>
        /// 地板
        /// </summary>
        Floor,
        /// <summary>
        /// 家具
        /// </summary>
        Furniture,
    }

    /// <summary>
    /// 木材
    /// </summary>
    public class Wood
    {
        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 使用着色 hardwood_tint_enabled
        /// </summary>
        public bool UseTinting { get; set; }

        /// <summary>
        /// 着色 hardwood_tint_color
        /// </summary>
        public Color Tinting { get; set; }

        /// <summary>
        /// 饰面 hardwood_finish
        /// </summary>
        public WoodFacing WoodFacing { get; set; }

        /// <summary>
        /// 用途 hardwood_application
        /// </summary>
        public Purpose Purpose { get; set; }

        public Wood(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "hardwood_application");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            UseTinting = mainDict.ContainsKey("hardwood_tint_enabled") ? int.Parse(mainDict["hardwood_tint_enabled"]) != 0 : false;
            if (UseTinting)
            {
                Tinting = new Color(mainDict.ContainsKey("hardwood_tint_color") ? mainDict["hardwood_tint_color"] : string.Empty);
                WoodFacing = mainDict.ContainsKey("hardwood_finish") ? (WoodFacing)int.Parse(mainDict["hardwood_finish"]) : WoodFacing.SemiGlossyVarnish;
                Purpose = mainDict.ContainsKey("hardwood_application") ? (Purpose)int.Parse(mainDict["hardwood_application"]) : Purpose.Floor;
            }
        }

        public Wood()
        {

        }
    }

    /// <summary>
    /// 木材浮雕图案类型
    /// </summary>
    public enum WoodReliefPatternType
    {
        Non = 0,
        /// <summary>
        /// 基于木制颗粒
        /// </summary>
        WoodenParticleBased = 1,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 木材浮雕图案
    /// </summary>
    public class WoodReliefPattern
    {
        /// <summary>
        /// 使用木材浮雕图案 hardwood_imperfections == 0 false
        /// </summary>
        public bool UseWoodReliefPattern { get; set; }

        /// <summary>
        /// 类型 hardwood_imperfections
        /// </summary>
        public WoodReliefPatternType WoodReliefPatternType { get; set; }

        /// <summary>
        /// 自定义图像
        /// </summary>
        public ImageBase DefinedImage { get; set; }

        /// <summary>
        /// 数量 hardwood_imperfections_amount
        /// </summary>
        public double Count { get; set; }

        public WoodReliefPattern(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseWoodReliefPattern = mainDict.ContainsKey("hardwood_imperfections") ? int.Parse(mainDict["hardwood_imperfections"]) != 0 : false;
            if (UseWoodReliefPattern)
            {
                WoodReliefPatternType = mainDict.ContainsKey("hardwood_imperfections") ? (WoodReliefPatternType)int.Parse(mainDict["hardwood_imperfections"]) : WoodReliefPatternType.UserDefined;
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "hardwood_imperfections_amount");
                if (imageDict != null)
                {
                    DefinedImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Count = mainDict.ContainsKey("hardwood_imperfections_amount") ? double.Parse(mainDict["hardwood_imperfections_amount"]) : 0d;
            }
        }

        public WoodReliefPattern()
        {

        }
    }
}
