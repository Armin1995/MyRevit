using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 噪波类型
    /// </summary>
    public enum NoiseType
    {
        /// <summary>
        /// 规则
        /// </summary>
        Rule,
        /// <summary>
        /// 分形
        /// </summary>
        Fractal,
        /// <summary>
        /// 紊乱
        /// </summary>
        Chaos,
    }

    /// <summary>
    /// 噪波
    /// </summary>
    public class NoiseImage : ImageBase
    {
        /// <summary>
        /// 噪波类型 noise_Type
        /// </summary>
        public NoiseType NoiseType { get; set; }

        /// <summary>
        /// 大小 noise_Size
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// 颜色1 noise_Color1
        /// </summary>
        public Color Color1 { get; set; }

        /// <summary>
        /// 颜色2 noise_Color2
        /// </summary>
        public Color Color2 { get; set; }

        /// <summary>
        /// 阈值低 noise_ThresholdLow
        /// </summary>
        public double ThresholdLow { get; set; }

        /// <summary>
        /// 阈值高 noise_ThresholdHigh
        /// </summary>
        public double ThresholdHeight { get; set; }

        /// <summary>
        /// 阈值级别 noise_Levels
        /// </summary>
        public double ThresholdLevel { get; set; }

        /// <summary>
        /// 阈值相位 noise_Phase
        /// </summary>
        public double ThresholdPhase { get; set; }

        public NoiseImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            NoiseType = dict.ContainsKey("noise_Type") ? (NoiseType)int.Parse(dict["noise_Type"]) : NoiseType.Rule;
            Size = dict.ContainsKey("noise_Size") ? double.Parse(dict["noise_Size"]) : 0;
            Color1 = new Color(dict.ContainsKey("noise_Color1") ? dict["noise_Color1"] : string.Empty);
            Color2 = new Color(dict.ContainsKey("noise_Color2") ? dict["noise_Color2"] : string.Empty);
            ThresholdLow = dict.ContainsKey("noise_ThresholdLow") ? double.Parse(dict["noise_ThresholdLow"]) : 0;
            ThresholdHeight = dict.ContainsKey("noise_ThresholdHigh") ? double.Parse(dict["noise_ThresholdHigh"]) : 0;
            ThresholdLevel = dict.ContainsKey("noise_Levels") ? double.Parse(dict["noise_Levels"]) : 0;
            ThresholdPhase = dict.ContainsKey("noise_Phase") ? double.Parse(dict["noise_Phase"]) : 0;
        }

        public NoiseImage()
        {

        }
    }
}
