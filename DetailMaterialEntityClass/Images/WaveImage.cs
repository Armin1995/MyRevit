using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 波浪分布
    /// </summary>
    public enum WaveDistribution
    {
        TwoDimension,
        ThreeDimension,
    }

    /// <summary>
    /// 波浪
    /// </summary>
    public class WaveImage : ImageBase
    {
        /// <summary>
        /// 颜色1 wave_Color1
        /// </summary>
        public Color Color1 { get; set; }

        /// <summary>
        /// 颜色2 wave_Color2
        /// </summary>
        public Color Color2 { get; set; }

        /// <summary>
        /// 分布 wave_Distribution
        /// </summary>
        public WaveDistribution WaveDistribution { get; set; }

        /// <summary>
        /// 数量 wave_NumWaveSets
        /// </summary>
        public int WaveCount { get; set; }

        /// <summary>
        /// 半径 wave_WaveRadius
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// 最小长度 wave_WaveLenMin
        /// </summary>
        public double MinLength { get; set; }

        /// <summary>
        /// 最大长度 wave_WaveLenMax
        /// </summary>
        public double MaxLength { get; set; }

        /// <summary>
        /// 峰值 wave_Amplitude
        /// </summary>
        public double Peak { get; set; }

        /// <summary>
        /// 相位 wave_Phase
        /// </summary>
        public double Phase { get; set; }

        /// <summary>
        /// 随机种子 wave_RandomSeed
        /// </summary>
        public int RandomSeed { get; set; }

        public WaveImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            Color1 = new Color(dict.ContainsKey("wave_Color1") ? dict["wave_Color1"] : string.Empty);
            Color2 = new Color(dict.ContainsKey("wave_Color2") ? dict["wave_Color2"] : string.Empty);
            WaveDistribution = dict.ContainsKey("WaveDistribution") ? (WaveDistribution)int.Parse(dict["WaveDistribution"]) : WaveDistribution.ThreeDimension;
            WaveCount = dict.ContainsKey("wave_NumWaveSets") ? int.Parse(dict["wave_NumWaveSets"]) : 0;
            Radius = dict.ContainsKey("wave_WaveRadius") ? int.Parse(dict["wave_WaveRadius"]) : 0;
            MinLength = dict.ContainsKey("wave_WaveLenMin") ? double.Parse(dict["wave_WaveLenMin"]) : 0;
            MaxLength = dict.ContainsKey("wave_WaveLenMax") ? double.Parse(dict["wave_WaveLenMax"]) : 0;
            Peak = dict.ContainsKey("wave_Amplitude") ? double.Parse(dict["wave_Amplitude"]) : 0;
            Phase = dict.ContainsKey("wave_Phase") ? double.Parse(dict["wave_Phase"]) : 0;
            RandomSeed = dict.ContainsKey("wave_RandomSeed") ? int.Parse(dict["wave_RandomSeed"]) : 0;
        }

        public WaveImage()
        {

        }
    }
}
