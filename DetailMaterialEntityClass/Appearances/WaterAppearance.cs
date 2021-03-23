using DetailMaterialEntityClass.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 水外观
    /// </summary>
    public class WaterAppearance : AppearanceBase
    {
        public Water Water { get; set; }

        public WaterAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Water = new Water(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public WaterAppearance()
        {

        }
    }

    public enum WaterType
    {
        /// <summary>
        /// 游泳池
        /// </summary>
        SwimmingPool,
        /// <summary>
        /// 倒影池
        /// </summary>
        ReflectionPool,
        /// <summary>
        /// 河流
        /// </summary>
        River,
        /// <summary>
        /// 湖泊
        /// </summary>
        Lake,
        /// <summary>
        /// 海洋
        /// </summary>
        Sea,
    }

    public enum WaterColorType
    {
        /// <summary>
        /// 热带
        /// </summary>
        Tropical,
        /// <summary>
        /// 绿色
        /// </summary>
        Green,
        /// <summary>
        /// 褐色
        /// </summary>
        Brown,
        /// <summary>
        /// 倒影池
        /// </summary>
        ReflectionPool,
        /// <summary>
        /// 河流
        /// </summary>
        River,
        /// <summary>
        /// 湖泊
        /// </summary>
        Lake,
        /// <summary>
        /// 海洋
        /// </summary>
        Sea,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined
    }

    public class Water
    {
        /// <summary>
        /// 类型
        /// </summary>
        public WaterType WaterType { get; set; }

        /// <summary>
        /// 颜色类型
        /// </summary>
        public WaterColorType ColorType { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 波浪高度
        /// </summary>
        public double WaveHeight { get; set; }

        public Water(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            WaterType = mainDict.ContainsKey("water_type") ? (WaterType)int.Parse(mainDict["water_type"]) : WaterType.SwimmingPool;
            ColorType = mainDict.ContainsKey("water_tint_enable") ? (WaterColorType)int.Parse(mainDict["water_tint_enable"]) : WaterColorType.Tropical;
            Color = new Color(mainDict.ContainsKey("water_tint_color") ? mainDict["water_tint_color"] : string.Empty);
            WaveHeight = mainDict.ContainsKey("water_bump_amount") ? double.Parse(mainDict["water_bump_amount"]) : 0d;
        }

        public Water()
        {

        }
    }
}
