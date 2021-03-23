using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 金属漆外观
    /// </summary>
    public class MetallicPaintAppearance : AppearanceBase
    {
        /// <summary>
        /// 金属漆
        /// </summary>
        public MetallicPaint MetallicPaint { get; set; }

        /// <summary>
        /// 斑点
        /// </summary>
        public Spot Spot { get; set; }

        /// <summary>
        /// 珍珠白
        /// </summary>
        public PearlWhite PearlWhite { get; set; }

        /// <summary>
        /// 面漆
        /// </summary>
        public FinishingCoat FinishingCoat { get; set; }

        public MetallicPaintAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            MetallicPaint = new MetallicPaint(keyValuesList);
            Spot = new Spot(keyValuesList);
            PearlWhite = new PearlWhite(keyValuesList);
            FinishingCoat = new FinishingCoat(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public MetallicPaintAppearance()
        {

        }
    }

    /// <summary>
    /// 金属漆
    /// </summary>
    public class MetallicPaint
    {
        /// <summary>
        /// 颜色 metallicpaint_base_color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 高光扩散 metallicpaint_base_highlightspread * 100
        /// </summary>
        public int HighlightDiffusion { get; set; }

        public MetallicPaint(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            Color = new Color(mainDict.ContainsKey("metallicpaint_base_color") ? mainDict["metallicpaint_base_color"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "metallicpaint_base_color");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            HighlightDiffusion = mainDict.ContainsKey("metallicpaint_base_highlightspread") ? (int)Math.Round(double.Parse(mainDict["metallicpaint_base_highlightspread"]) * 100) : 60;
        }

        public MetallicPaint()
        {

        }
    }

    /// <summary>
    /// 斑点
    /// </summary>
    public class Spot
    {
        /// <summary>
        /// 使用斑点 metallicpaint_flecks
        /// </summary>
        public bool UseSpot { get; set; }

        /// <summary>
        /// 颜色 metallicpaint_flecks_color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 大小 metallicpaint_flecks_size
        /// </summary>
        public double Size { get; set; }

        public Spot(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseSpot = mainDict.ContainsKey("metallicpaint_flecks") ? int.Parse(mainDict["metallicpaint_flecks"]) != 0 : false;
            if (UseSpot)
            {
                Color = new Color(mainDict.ContainsKey("metallicpaint_flecks_color") ? mainDict["metallicpaint_flecks_color"] : string.Empty);
                Size = mainDict.ContainsKey("metallicpaint_flecks_size") ? double.Parse(mainDict["metallicpaint_flecks_size"]) * 100 : 10d;
            }
        }

        public Spot()
        {

        }
    }

    /// <summary>
    /// 珍珠白类型
    /// </summary>
    public enum PearlWhiteType
    {
        Non = 0,
        /// <summary>
        /// 彩色
        /// </summary>
        Colourful = 1,
        /// <summary>
        /// 第二种颜色
        /// </summary>
        SecondColor,
    }

    /// <summary>
    /// 珍珠白
    /// </summary>
    public class PearlWhite
    {
        /// <summary>
        /// 使用珍珠白 metallicpaint_pearl == 0 false
        /// </summary>
        public bool UsePearlWhite { get; set; }

        /// <summary>
        /// 类型 metallicpaint_pearl
        /// </summary>
        public PearlWhiteType PearlWhiteType { get; set; }

        /// <summary> 
        /// 第二种颜色 metallicpaint_pearl_color
        /// </summary>
        public Color SecondColor { get; set; }

        /// <summary>
        /// 混合 metallicpaint_pearl_ior
        /// </summary>
        public int Mixedness { get; set; }

        /// <summary>
        /// 数量 metallicpaint_pearl_amount
        /// </summary>
        public int Count { get; set; }

        public PearlWhite(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UsePearlWhite = mainDict.ContainsKey("metallicpaint_pearl") ? int.Parse(mainDict["metallicpaint_pearl"]) != 0 : false;
            if (UsePearlWhite)
            {
                PearlWhiteType = mainDict.ContainsKey("metallicpaint_pearl") ? (PearlWhiteType)int.Parse(mainDict["metallicpaint_pearl"]) : PearlWhiteType.Colourful;
                SecondColor = new Color(mainDict.ContainsKey("metallicpaint_pearl_color") ? mainDict["metallicpaint_pearl_color"] : string.Empty);
                Mixedness = mainDict.ContainsKey("metallicpaint_pearl_ior") ? (int)Math.Round(double.Parse(mainDict["metallicpaint_pearl_ior"]) * 100, 2) : 50;
                Count = mainDict.ContainsKey("metallicpaint_pearl_amount") ? (int)Math.Round(double.Parse(mainDict["metallicpaint_pearl_amount"]) * 100, 2) : 50;
            }
        }

        public PearlWhite()
        {

        }
    }

    /// <summary>
    /// 面漆类型
    /// </summary>
    public enum FinishingCoatType
    {
        /// <summary>
        /// 汽车面漆
        /// </summary>
        CarFinishingCoat,
        /// <summary>
        /// 铬
        /// </summary>
        Chromium,
        /// <summary>
        /// 粗面
        /// </summary>
        Asperities,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 面漆饰面
    /// </summary>
    public enum FinishingCoatFacing
    {
        /// <summary>
        /// 平滑
        /// </summary>
        Smoothness,
        /// <summary>
        /// 斑纹漆
        /// </summary>
        MarkingPaint,
    }

    /// <summary>
    /// 面漆
    /// </summary>
    public class FinishingCoat
    {
        /// <summary>
        /// 类型 metallicpaint_topcoat
        /// </summary>
        public FinishingCoatType FinishingCoatType { get; set; }

        /// <summary>
        /// 光泽度 metallicpaint_topcoat_glossy * 100
        /// </summary>
        public int Glossiness { get; set; }

        /// <summary>
        /// 角度衰减 metallicpaint_topcoat_falloff * 100
        /// </summary>
        public int AngleAttenuation { get; set; }

        /// <summary>
        /// 饰面 metallicpaint_finish
        /// </summary>
        public FinishingCoatFacing FinishingCoatFacing { get; set; }

        /// <summary>
        /// 数量 metallicpaint_finish_peelamount * 100
        /// </summary>
        public int Count { get; set; }

        public FinishingCoat(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            FinishingCoatType = mainDict.ContainsKey("metallicpaint_topcoat") ? (FinishingCoatType)int.Parse(mainDict["metallicpaint_topcoat"]) : FinishingCoatType.CarFinishingCoat;
            Glossiness = mainDict.ContainsKey("metallicpaint_topcoat_glossy") ? (int)Math.Round(double.Parse(mainDict["metallicpaint_topcoat_glossy"]) * 100, 2) : 0;
            AngleAttenuation = mainDict.ContainsKey("metallicpaint_topcoat_falloff") ? (int)Math.Round(double.Parse(mainDict["metallicpaint_topcoat_falloff"]) * 100, 2) : 0;
            FinishingCoatFacing = mainDict.ContainsKey("metallicpaint_finish") ? (FinishingCoatFacing)int.Parse(mainDict["metallicpaint_finish"]) : FinishingCoatFacing.MarkingPaint;
            Count = mainDict.ContainsKey("metallicpaint_finish_peelamount") ? (int)Math.Round(double.Parse(mainDict["metallicpaint_finish_peelamount"]) * 100, 2) : 0;
        }

        public FinishingCoat()
        {

        }
    }
}
