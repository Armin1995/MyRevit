using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 图像类型
    /// </summary>
    public enum ImageType
    {
        /// <summary>
        /// 自定义图像
        /// </summary>
        UnifiedBitmapSchema = 0,
        /// <summary>
        /// 棋盘格
        /// </summary>
        CheckerSchema = 1,
        /// <summary>
        /// 渐变
        /// </summary>
        GradientSchema = 2,
        /// <summary>
        /// 大理石
        /// </summary>
        MarbleSchema = 3,
        /// <summary>
        /// 噪波
        /// </summary>
        NoiseSchema = 4,
        /// <summary>
        /// 斑点
        /// </summary>
        SpotSchema = 5,
        /// <summary>
        /// 平铺
        /// </summary>
        TileSchema = 6,
        /// <summary>
        /// 波浪
        /// </summary>
        WaveSchema = 7,
        /// <summary>
        /// 木材
        /// </summary>
        WoodSchema = 8,
    }

    /// <summary>
    /// 重复类型
    /// </summary>
    public enum RepetitionType
    {
        /// <summary>
        /// 无
        /// </summary>
        Non,
        /// <summary>
        /// 平铺
        /// </summary>
        Tile,
    }

    [XmlInclude(typeof(UserDefined))]
    [XmlInclude(typeof(CheckerboardImage))]
    [XmlInclude(typeof(GradientImage))]
    [XmlInclude(typeof(MarbleImage))]
    [XmlInclude(typeof(NoiseImage))]
    [XmlInclude(typeof(SpotImage))]
    [XmlInclude(typeof(TileImage))]
    [XmlInclude(typeof(WaveImage))]
    [XmlInclude(typeof(WoodImage))]
    [KnownType(typeof(UserDefined))]
    [KnownType(typeof(CheckerboardImage))]
    [KnownType(typeof(GradientImage))]
    [KnownType(typeof(MarbleImage))]
    [KnownType(typeof(NoiseImage))]
    [KnownType(typeof(SpotImage))]
    [KnownType(typeof(TileImage))]
    [KnownType(typeof(WaveImage))]
    [KnownType(typeof(WoodImage))]
    /// <summary>
    /// 图像基类
    /// </summary>
    public class ImageBase
    {
        /// <summary>
        /// 图像类型 BaseSchema
        /// </summary>
        public ImageType ImageType { get; set; }

        /// <summary>
        /// 链接纹理变换 texture_LinkTextureTransforms
        /// </summary>
        public bool LinkTextureTransform { get; set; }

        /// <summary>
        /// 偏移X texture_RealWorldOffsetX
        /// </summary>
        public double OffsetX { get; set; }

        /// <summary>
        /// 偏移Y texture_RealWorldOffsetY
        /// </summary>
        public double OffsetY { get; set; }

        /// <summary>
        /// 限制偏移 texture_OffsetLock
        /// </summary>
        public bool LimitOffset { get; set; }

        /// <summary>
        /// 旋转 texture_WAngle
        /// </summary>
        public double RotateAngle { get; set; }

        /// <summary>
        /// 样例尺寸宽度 texture_RealWorldScaleX 1.33333337306976(thisValue) * 304.8 = 406.40 mm(revit value)
        /// </summary>
        public double SampleSizeWidth { get; set; }

        /// <summary>
        /// 样例尺寸高度 texture_RealWorldScaleY
        /// </summary>
        public double SampleSizeHeight { get; set; }

        /// <summary>
        /// 锁定贴图的纵横比 texture_ScaleLock
        /// </summary>
        public bool LockAspectRatio { get; set; }

        /// <summary>
        /// 水平重复 texture_URepeat
        /// </summary>
        public RepetitionType HorizontalRepetition { get; set; }

        /// <summary>
        /// 垂直重复 texture_VRepeat
        /// </summary>
        public RepetitionType VerticalRepetition { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ImageBase Init(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            var type = dict.ContainsKey("BaseSchema") ? dict["BaseSchema"] : "";
            if (string.IsNullOrEmpty(type) && dict.Keys.Any(o => o.Contains("unifiedbitmap_Bitmap")))
            {
                type = "UnifiedBitmapSchema";
            }
            if (Enum.TryParse(type, out ImageType imageType))
            {
                switch (imageType)
                {
                    case ImageType.UnifiedBitmapSchema:
                        return new UserDefined(dict, dictList);
                    case ImageType.CheckerSchema:
                        return new CheckerboardImage(dict, dictList);
                    case ImageType.GradientSchema:
                        return new GradientImage(dict, dictList);
                    case ImageType.MarbleSchema:
                        return new MarbleImage(dict, dictList);
                    case ImageType.NoiseSchema:
                        return new NoiseImage(dict, dictList);
                    case ImageType.SpotSchema:
                        return new SpotImage(dict, dictList);
                    case ImageType.TileSchema:
                        return new TileImage(dict, dictList);
                    case ImageType.WaveSchema:
                        return new WaveImage(dict, dictList);
                    case ImageType.WoodSchema:
                        return new WoodImage(dict, dictList);
                    default:
                        return null;
                }
            }
            return null;
        }

        public ImageBase()
        {

        }
    }
}
