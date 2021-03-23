using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 墙漆外观
    /// </summary>
    public class WallPaintAppearance : AppearanceBase
    {
        /// <summary>
        /// 墙漆
        /// </summary>
        public WallPaint WallPaint { get; set; }

        public WallPaintAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            WallPaint = new WallPaint(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public WallPaintAppearance()
        {

        }
    }

    /// <summary>
    /// 饰面类型
    /// </summary>
    public enum FacingType
    {
        /// <summary>
        /// 平面/粗面
        /// </summary>
        FlatOrAsperities,
        /// <summary>
        /// 黄白色
        /// </summary>
        YellowishWhite,
        /// <summary>
        /// 铂
        /// </summary>
        Platinum,
        /// <summary>
        /// 珍珠白
        /// </summary>
        PearlWhite,
        /// <summary>
        /// 半光泽
        /// </summary>
        SemiGloss,
        /// <summary>
        /// 光泽
        /// </summary>
        Gloss,
    }

    /// <summary>
    /// 应用类型
    /// </summary>
    public enum ApplyType
    {
        /// <summary>
        /// 涂漆
        /// </summary>
        Paint,
        /// <summary>
        /// 刷涂
        /// </summary>
        BrushCoating,
        /// <summary>
        /// 喷涂
        /// </summary>
        Spray,
    }

    /// <summary>
    /// 墙漆
    /// </summary>
    public class WallPaint
    {
        /// <summary>
        /// 颜色 wallpaint_color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 饰面类型 wallpaint_finish
        /// </summary>
        public FacingType FacingType { get; set; }

        /// <summary>
        /// 应用 wallpaint_application
        /// </summary>
        public ApplyType ApplyType { get; set; }

        public WallPaint(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            Color = new Color(mainDict.ContainsKey("wallpaint_color") ? mainDict["wallpaint_color"] : string.Empty);
            FacingType = mainDict.ContainsKey("wallpaint_finish") ? (FacingType)int.Parse(mainDict["wallpaint_finish"]) : FacingType.PearlWhite;
            ApplyType = mainDict.ContainsKey("wallpaint_application") ? (ApplyType)int.Parse(mainDict["wallpaint_application"]) : ApplyType.Paint;
        }

        public WallPaint()
        {

        }
    }
}
