using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 混凝土外观
    /// </summary>
    public class ConcreteAppearance : AppearanceBase
    {
        /// <summary>
        /// 混凝土
        /// </summary>
        public Concrete Concrete { get; set; }

        /// <summary>
        /// 饰面凹凸
        /// </summary>
        public ConcreteFinishConcaveConvex ConcreteFinishConcaveConvex { get; set; }

        /// <summary>
        /// 风化
        /// </summary>
        public Weathering Weathering { get; set; }

        public ConcreteAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Concrete = new Concrete(keyValuesList);
            ConcreteFinishConcaveConvex = new ConcreteFinishConcaveConvex(keyValuesList);
            Weathering = new Weathering(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public ConcreteAppearance()
        {

        }
    }

    /// <summary>
    /// 密封层
    /// </summary>
    public enum SealType
    {
        /// <summary>
        /// 无
        /// </summary>
        Non,
        /// <summary>
        /// 环氧树脂
        /// </summary>
        EpoxyResin,
        /// <summary>
        /// 丙烯酸树脂
        /// </summary>
        AcrylicResin,
    }

    /// <summary>
    /// 混凝土
    /// </summary>
    public class Concrete
    {
        /// <summary>
        /// 颜色 concrete_color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 密封层 concrete_sealant
        /// </summary>
        public SealType SealType { get; set; }

        public Concrete(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "concrete_color");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            else
            {
                Color = new Color(mainDict.ContainsKey("concrete_color") ? mainDict["concrete_color"] : string.Empty);
            }
            SealType = mainDict.ContainsKey("concrete_sealant") ? (SealType)int.Parse(mainDict["concrete_sealant"]) : SealType.Non;
        }

        public Concrete()
        {

        }
    }

    /// <summary>
    /// 混凝土饰面凹凸
    /// </summary>
    public enum ConcreteFinishConcaveConvexType
    {
        /// <summary>
        /// 直扫面
        /// </summary>
        DirectScanning,
        /// <summary>
        /// 弯曲扫面
        /// </summary>
        BendingSweep,
        /// <summary>
        /// 平滑
        /// </summary>
        Smoothness,
        /// <summary>
        /// 抛光
        /// </summary>
        Polishing,
        /// <summary>
        /// 戳记
        /// </summary>
        Countermark,
    }

    /// <summary>
    /// 饰面凹凸
    /// </summary>
    public class ConcreteFinishConcaveConvex
    {
        /// <summary>
        /// 类型 concrete_finish
        /// </summary>
        public ConcreteFinishConcaveConvexType ConcreteFinishConcaveConvexType { get; set; }

        /// <summary>
        /// 自定义图像
        /// </summary>
        public ImageBase DefinedImage { get; set; }

        /// <summary>
        /// 数量 concrete_bump_amount
        /// </summary>
        public double Count { get; set; }

        public ConcreteFinishConcaveConvex(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            ConcreteFinishConcaveConvexType = mainDict.ContainsKey("concrete_finish") ? (ConcreteFinishConcaveConvexType)int.Parse(mainDict["concrete_finish"]) : ConcreteFinishConcaveConvexType.DirectScanning;
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "concrete_bump_amount" || o.First().Key == "concrete_finish");
            if (imageDict != null)
            {
                DefinedImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            Count = mainDict.ContainsKey("concrete_bump_amount") ? double.Parse(mainDict["concrete_bump_amount"]) : 1d;
        }

        public ConcreteFinishConcaveConvex()
        {

        }
    }

    public enum WeatheringType
    {
        Non = 0,
        /// <summary>
        /// 自动
        /// </summary>
        Automation = 1,
        /// <summary>
        /// 自定义图像
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 风化
    /// </summary>
    public class Weathering
    {
        /// <summary>
        /// 使用风化 concrete_brightmode == 0 false
        /// </summary>
        public bool UseWeathering { get; set; }
        /// <summary>
        /// 风化类型 concrete_brightmode
        /// </summary>
        public WeatheringType WeatheringType { get; set; }

        /// <summary>
        /// 自定义图像
        /// </summary>
        public ImageBase DefinedImage { get; set; }

        public Weathering(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseWeathering = mainDict.ContainsKey("concrete_brightmode") ? int.Parse(mainDict["concrete_brightmode"]) != 0 : false;
            if (UseWeathering)
            {
                WeatheringType = mainDict.ContainsKey("concrete_brightmode") ? (WeatheringType)int.Parse(mainDict["concrete_brightmode"]) : WeatheringType.Automation;
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "concrete_ao_samples" || o.First().Key == "concrete_brightmode");
                if (imageDict != null)
                {
                    DefinedImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
            }
        }

        public Weathering()
        {

        }
    }
}
