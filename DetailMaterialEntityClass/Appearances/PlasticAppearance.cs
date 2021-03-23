using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 塑料外观
    /// </summary>
    public class PlasticAppearance : AppearanceBase
    {
        /// <summary>
        /// 塑料
        /// </summary>
        public Plastic Plastic { get; set; }

        /// <summary>
        /// 饰面凹凸
        /// </summary>
        public FinishConcaveConvex FinishConcaveConvex { get; set; }

        /// <summary>
        /// 浮雕图案
        /// </summary>
        public PlasticReliefPattern MasonryReliefPattern { get; set; }

        public PlasticAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Plastic = new Plastic(keyValuesList);
            FinishConcaveConvex = new FinishConcaveConvex(keyValuesList);
            MasonryReliefPattern = new PlasticReliefPattern(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public PlasticAppearance()
        {

        }
    }

    /// <summary>
    /// 塑料类型
    /// </summary>
    public enum PlasticType
    {
        /// <summary>
        /// 塑料(实体)
        /// </summary>
        EntityPlastic,
        /// <summary>
        /// 塑料(透明)
        /// </summary>
        LucencyPlastic,
        /// <summary>
        /// 乙烯树脂
        /// </summary>
        Vinyl,
    }

    /// <summary>
    /// 塑料饰面
    /// </summary>
    public enum PlasticFinish
    {
        /// <summary>
        /// 抛光
        /// </summary>
        Full_polish,
        /// <summary>
        /// 有光泽
        /// </summary>
        Glossy,
        /// <summary>
        /// 粗面
        /// </summary>
        Asperities,
    }

    /// <summary>
    /// 塑料
    /// </summary>
    public class Plastic
    {
        /// <summary>
        /// 塑料类型 plasticvinyl_type
        /// </summary>
        public PlasticType PlasticType { get; set; }

        /// <summary>
        /// 颜色 plasticvinyl_color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 饰面 plasticvinyl_application
        /// </summary>
        public PlasticFinish PlasticFinish { get; set; }

        public Plastic(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            PlasticType = mainDict.ContainsKey("plasticvinyl_type") ? (PlasticType)int.Parse(mainDict["plasticvinyl_type"]) : PlasticType.LucencyPlastic;
            Color = new Color(mainDict.ContainsKey("plasticvinyl_color") ? mainDict["plasticvinyl_color"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "plasticvinyl_color");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            PlasticFinish = mainDict.ContainsKey("plasticvinyl_application") ? (PlasticFinish)int.Parse(mainDict["plasticvinyl_application"]) : PlasticFinish.Asperities;
        }

        public Plastic()
        {

        }
    }

    /// <summary>
    /// 饰面凹凸
    /// </summary>
    public class FinishConcaveConvex
    {
        /// <summary>
        /// 使用饰面凹凸 plasticvinyl_bump
        /// </summary>
        public bool UseFinishConcaveConvex { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 数量 plasticvinyl_bump_amount
        /// </summary>
        public double Count { get; set; }

        public FinishConcaveConvex(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseFinishConcaveConvex = mainDict.ContainsKey("plasticvinyl_bump") ? int.Parse(mainDict["plasticvinyl_bump"]) != 0 : false;
            if (UseFinishConcaveConvex)
            {
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "plasticvinyl_bump_amount");
                if (imageDict != null)
                {
                    Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Count = mainDict.ContainsKey("plasticvinyl_bump_amount") ? double.Parse(mainDict["plasticvinyl_bump_amount"]) : 0;

            }
        }

        public FinishConcaveConvex()
        {

        }
    }

    /// <summary>
    /// 塑料浮雕图案
    /// </summary>
    public class PlasticReliefPattern
    {
        /// <summary>
        /// 使用浮雕图案 plasticvinyl_pattern
        /// </summary>
        public bool UseReliefPattern { get; set; }

        /// <summary>
        /// 浮雕图案图像
        /// </summary>
        public ImageBase ReliefPatternImage { get; set; }

        /// <summary>
        /// 浮雕图案数量 plasticvinyl_pattern_amount
        /// </summary>
        public double ReliefPatternNumber { get; set; }

        public PlasticReliefPattern(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseReliefPattern = mainDict.ContainsKey("plasticvinyl_pattern") ? int.Parse(mainDict["plasticvinyl_pattern"]) != 0 : false;
            if (UseReliefPattern)
            {
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "");
                if (imageDict != null)
                {
                    ReliefPatternImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                ReliefPatternNumber = mainDict.ContainsKey("plasticvinyl_pattern_amount") ? double.Parse(mainDict["plasticvinyl_pattern_amount"]) : 0d;
            }
        }

        public PlasticReliefPattern()
        {

        }
    }
}
