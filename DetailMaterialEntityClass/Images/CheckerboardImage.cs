using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 棋盘格
    /// </summary>
    public class CheckerboardImage : ImageBase
    {
        /// <summary>
        /// 颜色1 checker_color1
        /// </summary>
        public Color Color1 { get; set; }

        /// <summary>
        /// 图像1
        /// </summary>
        public ImageBase Image1 { get; set; }

        /// <summary>
        /// 颜色2 checker_color2
        /// </summary>
        public Color Color2 { get; set; }

        /// <summary>
        /// 图像2
        /// </summary>
        public ImageBase Image2 { get; set; }

        /// <summary>
        /// 柔和 checker_soften
        /// </summary>
        public double Soften { get; set; }

        public CheckerboardImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
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

            Color1 = new Color(dict.ContainsKey("checker_color1") ? dict["checker_color1"] : string.Empty);
            var image1Dict = dictList.FirstOrDefault(o => o.First().Key == "");
            if (image1Dict != null)
            {
                Image1 = ImageBase.Init(image1Dict, dictList.Except(new List<Dictionary<string, string>>() { image1Dict }).ToList());
            }
            Color2 = new Color(dict.ContainsKey("checker_color2") ? dict["checker_color2"] : string.Empty);
            var image2Dict = dictList.FirstOrDefault(o => o.First().Key == "");
            if (image2Dict != null)
            {
                Image2 = ImageBase.Init(image2Dict, dictList.Except(new List<Dictionary<string, string>>() { image2Dict }).ToList());
            }
            Soften = dict.ContainsKey("checker_soften") ? double.Parse(dict["checker_soften"]) : 0d;
        }

        public CheckerboardImage()
        {

        }
    }
}
