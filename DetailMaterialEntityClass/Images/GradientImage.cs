using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 渐变类型
    /// </summary>
    public enum GradientType
    {
        /// <summary>
        /// 线形不对称
        /// </summary>
        LinearAsymmetry,
        /// <summary>
        /// 长方体
        /// </summary>
        Cuboid,
        /// <summary>
        /// 对角线
        /// </summary>
        Diagonal,
        /// <summary>
        /// 照明法线
        /// </summary>
        NormalIllumination,
        /// <summary>
        /// 线性
        /// </summary>
        Linear,
        /// <summary>
        /// 相机法线
        /// </summary>
        NormalCamera,
        /// <summary>
        /// 对角
        /// </summary>
        OppositeAngles,
        /// <summary>
        /// 径向
        /// </summary>
        RadialDirection,
        /// <summary>
        /// 螺旋
        /// </summary>
        Spiral,
        /// <summary>
        /// 扇叶
        /// </summary>
        flabellum,
        /// <summary>
        /// 格子
        /// </summary>
        Grid,
    }

    /// <summary>
    /// 插值类型
    /// </summary>
    public enum InterpolationType
    {
        /// <summary>
        /// 缓入
        /// </summary>
        EaseIn,
        /// <summary>
        /// 缓入缓出
        /// </summary>
        EaseInOut,
        /// <summary>
        /// 缓出
        /// </summary>
        EaseOut,
        /// <summary>
        /// 线性
        /// </summary>
        Linear,
        /// <summary>
        /// 实体
        /// </summary>
        Entity,
    }

    public enum GradientNoiseType
    {
        Rule,
        Fractal,
        Chaos,
    }

    /// <summary>
    /// 渐变
    /// </summary>
    public class GradientImage : ImageBase
    {
        /// <summary>
        /// 渐变类型 gradient_type
        /// </summary>
        public GradientType GradientType { get; set; }

        /// <summary>
        /// 颜色、插值、位置 组 gradient_Color    gradient_interpolation     gradient_Position
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// 使用噪波 gradient_noise_amount == 0 false
        /// </summary>
        public bool UseNoise { get; set; }

        /// <summary>
        /// 噪波类型 gradient_noise
        /// </summary>
        public GradientNoiseType NoiseType { get; set; }

        /// <summary>
        /// 数量 gradient_noise_amount
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// 大小 gradient_noise_size
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// 相位 gradient_noise_phase
        /// </summary>
        public double Phase { get; set; }

        /// <summary>
        /// 等级 gradient_noise_levels
        /// </summary>
        public double Level { get; set; }

        /// <summary>
        /// 阈值 低 gradient_noise_low
        /// </summary>
        public double ThresholdLow { get; set; }

        /// <summary>
        /// 阈值 高 gradient_noise_high
        /// </summary>
        public double ThresholdHigh { get; set; }

        /// <summary>
        /// 阈值 平滑 gradient_noise_smooth
        /// </summary>
        public double ThresholdSmooth { get; set; }

        public GradientImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            ImageType = ImageType.UnifiedBitmapSchema;
            LinkTextureTransform = dict.ContainsKey("texture_LinkTextureTransforms") ? bool.Parse(dict["texture_LinkTextureTransforms"]) : false;
            OffsetX = dict.ContainsKey("texture_RealWorldOffsetX") ? Math.Round(double.Parse(dict["texture_RealWorldOffsetX"]) * 25.4d, 2) : 0d;
            OffsetY = dict.ContainsKey("texture_RealWorldOffsetY") ? Math.Round(double.Parse(dict["texture_RealWorldOffsetY"]) * 25.4d, 2) : 0d;
            LimitOffset = dict.ContainsKey("texture_OffsetLock") ? bool.Parse(dict["texture_OffsetLock"]) : false;
            RotateAngle = dict.ContainsKey("texture_WAngle") ? Math.Round(double.Parse(dict["texture_WAngle"]), 2) : 0d;
            SampleSizeWidth = dict.ContainsKey("texture_RealWorldScaleX") ? Math.Round(double.Parse(dict["texture_RealWorldScaleX"]) * 25.4d, 2) : 0d;
            SampleSizeHeight = dict.ContainsKey("texture_RealWorldScaleY") ? Math.Round(double.Parse(dict["texture_RealWorldScaleY"]) * 25.4d, 2) : 0d;
            LockAspectRatio = dict.ContainsKey("texture_ScaleLock") ? bool.Parse(dict["texture_ScaleLock"]) : true;
            HorizontalRepetition = dict.ContainsKey("texture_URepeat") ? (RepetitionType)Convert.ToInt32(bool.Parse(dict["texture_URepeat"])) : RepetitionType.Non;
            VerticalRepetition = dict.ContainsKey("texture_VRepeat") ? (RepetitionType)Convert.ToInt32(bool.Parse(dict["texture_VRepeat"])) : RepetitionType.Non;

            GradientType = dict.ContainsKey("gradient_type") ? (GradientType)int.Parse(dict["gradient_type"]) : GradientType.OppositeAngles;
            var colors = dict.Where(o => o.Key.StartsWith("gradient_Color")).ToDictionary(o => o.Key, v => v.Value);
            var interpolations = dict.Where(o => o.Key.StartsWith("gradient_interpolation")).ToDictionary(o => o.Key, v => v.Value);
            var positions = dict.Where(o => o.Key.StartsWith("gradient_Position")).ToDictionary(o => o.Key, v => v.Value);
            if (positions.Count == 1)
            {
                var array = positions.First().Value.Split(' ');
                positions = new Dictionary<string, string>();
                for (int i = 0; i < array.Length; i++)
                {
                    positions.Add("gradient_Position" + i, array[i]);
                }
            }
            Groups = new List<Group>();
            for (int i = 0; i < colors.Count; i++)
            {
                Groups.Add(new Group(new Color(colors.ElementAt(i).Value), (InterpolationType)int.Parse(interpolations.ElementAt(i).Value), double.Parse(positions.ElementAt(i).Value)));
            }
            UseNoise = dict.ContainsKey("gradient_noise_amount") ? double.Parse(dict["gradient_noise_amount"]) != 0 : false;
            NoiseType = dict.ContainsKey("gradient_noise") ? (GradientNoiseType)int.Parse(dict["gradient_noise"]) : GradientNoiseType.Rule;
            Count = dict.ContainsKey("gradient_noise_amount") ? double.Parse(dict["gradient_noise_amount"]) : 0;
            Size = dict.ContainsKey("gradient_noise_size") ? double.Parse(dict["gradient_noise_size"]) : 0;
            Phase = dict.ContainsKey("gradient_noise_phase") ? double.Parse(dict["gradient_noise_phase"]) : 0;
            Level = dict.ContainsKey("gradient_noise_levels") ? double.Parse(dict["gradient_noise_levels"]) : 0;
            ThresholdLow = dict.ContainsKey("gradient_noise_low") ? double.Parse(dict["gradient_noise_low"]) : 0;
            ThresholdHigh = dict.ContainsKey("gradient_noise_high") ? double.Parse(dict["gradient_noise_high"]) : 0;
            ThresholdSmooth = dict.ContainsKey("gradient_noise_smooth") ? double.Parse(dict["gradient_noise_smooth"]) : 0;
        }

        public GradientImage()
        {

        }
    }
}
