using DetailMaterialEntityClass.Materials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 图像类
    /// </summary>
    public class UserDefined : ImageBase
    {
        /// <summary>
        /// 源 unifiedbitmap_Bitmap
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 亮度 unifiedbitmap_RGBAmount
        /// </summary>
        //public int Luminance { get; set; }

        /// <summary>
        /// 反转图像 unifiedbitmap_Invert
        /// </summary>
        //public bool ReversalImage { get; set; }

        public UserDefined(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
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

            Source = dict.ContainsKey("unifiedbitmap_Bitmap") ? dict["unifiedbitmap_Bitmap"].Split('|').First() : string.Empty;
            if (!string.IsNullOrEmpty(Source))
            {
                if (!File.Exists(Source))//说明是不是自定义的图像，是系统内部的图像
                {
                    if (Source.Contains("/"))
                    {
                        Source = Source.Replace('/', '\\');
                    }

                    if (Source.StartsWith(@"1\Mats"))
                    {
                        Source = @"C:\Program Files (x86)\Common Files\Autodesk Shared\Materials\Textures\" + Source;
                    }
                    else if (Source.StartsWith(@"2\Mats"))
                    {
                        Source = @"C:\Program Files (x86)\Common Files\Autodesk Shared\Materials\Textures\" + Source;
                    }
                    else if (Source.StartsWith(@"3\Mats"))
                    {
                        Source = @"C:\Program Files (x86)\Common Files\Autodesk Shared\Materials\Textures\" + Source;
                    }
                    else
                    {
                        var path1 = @"C:\Program Files (x86)\Common Files\Autodesk Shared\Materials\Textures\1\Mats\" + Source;
                        var path2 = @"C:\Program Files (x86)\Common Files\Autodesk Shared\Materials\Textures\1\Mats\" + Source;
                        var path3 = @"C:\Program Files (x86)\Common Files\Autodesk Shared\Materials\Textures\1\Mats\" + Source;
                        if (File.Exists(path1))
                        {
                            Source = path1;
                        }
                        else if (File.Exists(path2))
                        {
                            Source = path2;
                        }
                        else if (File.Exists(path3))
                        {
                            Source = path3;
                        }
                    }

                    if (!File.Exists(Source))
                    {
                        Source = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(Source))
                {
                    if (!MaterialInfo.TexturePathList.Contains(Source))
                    {
                        MaterialInfo.TexturePathList.Add(Source);
                    }
                    Source = Path.GetFileName(Source.Replace("&", "And"));
                }
            }
            //Luminance = dict.ContainsKey("unifiedbitmap_RGBAmount") ? (int)Math.Round(double.Parse(dict["unifiedbitmap_RGBAmount"]) * 100) : 1;
            //ReversalImage = dict.ContainsKey("unifiedbitmap_Invert") ? bool.Parse(dict["unifiedbitmap_Invert"]) : false;
        }

        public UserDefined()
        {

        }
    }
}
