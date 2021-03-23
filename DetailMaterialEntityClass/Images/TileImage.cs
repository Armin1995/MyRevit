using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Images
{
    /// <summary>
    /// 平铺类型
    /// </summary>
    public enum TileType
    {
        /// <summary>
        /// 顺序砌法
        /// </summary>
        SequenceBricklaying,
        /// <summary>
        /// 普通砖佛兰芒砌法
        /// </summary>
        FlemishBricklaying,
        /// <summary>
        /// 英式砌法
        /// </summary>
        BritishBricklaying,
        /// <summary>
        /// 1/2顺序砌法
        /// </summary>
        HalfSequenceBricklaying,
        /// <summary>
        /// 叠层式砌法
        /// </summary>
        LaminateBricklaying,
        /// <summary>
        /// 精细顺序砌法
        /// </summary>
        FineSequenceBricklaying,
        /// <summary>
        /// 精细叠层式砌法
        /// </summary>
        FineLaminateBricklaying,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 平铺
    /// </summary>
    public class TileImage : ImageBase
    {
        /// <summary>
        /// 填充图案类型
        /// </summary>
        public TileType TileType { get; set; }

        /// <summary>
        /// 瓷砖计数每行 tile_HorizontalCount
        /// </summary>
        public double TileCountPerRow { get; set; }

        /// <summary>
        /// 瓷砖计数每列 tile_VerticalCount
        /// </summary>
        public double TileCountPerColumn { get; set; }

        /// <summary>
        /// 瓷砖颜色 tile_BrickColor
        /// </summary>
        public Color TileColor { get; set; }

        /// <summary>
        /// 瓷砖图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 颜色变化 tile_ColorVariance
        /// </summary>
        public double ColorChange { get; set; }

        /// <summary>
        /// 褪色变化 tile_FadeVariance
        /// </summary>
        public double FadingChange { get; set; }

        /// <summary>
        /// 随机种子值 tile_RandomSeed
        /// </summary>
        public int RandomSeed { get; set; }

        /// <summary>
        /// 砖缝颜色 tile_MortarColor
        /// </summary>
        public Color JointColor { get; set; }

        /// <summary>
        /// 砖缝图像
        /// </summary>
        public ImageBase JointImage { get; set; }

        /// <summary>
        /// 间隙宽度水平 tile_HorizontalGap
        /// </summary>
        public double JointWidthHorizontal { get; set; }

        /// <summary>
        /// 间隙宽度垂直 tile_VerticalGap
        /// </summary>
        public double JointWidthVertical { get; set; }

        /// <summary>
        /// 锁定间隙宽度 texture_ScaleLock
        /// </summary>
        public bool LockJointWidth { get; set; }

        /// <summary> 
        /// 粗糙度 tile_EdgeRoughness
        /// </summary>
        public double Rough { get; set; }

        /// <summary>
        /// 线性移动 tile_LineShift
        /// </summary>
        public double LinearMove { get; set; }

        /// <summary>
        /// 随机 tile_RandomShift
        /// </summary>
        public double Random { get; set; }

        /// <summary>
        /// 使用行修改 tile_UseRowEdit
        /// </summary>
        public bool UseRowModify { get; set; }

        /// <summary>
        /// 每X行 tile_PerRow
        /// </summary>
        public int PerRow { get; set; }

        /// <summary>
        /// 行修改数量 tile_HorizontalGap
        /// </summary>
        public double PerRowCount { get; set; }

        /// <summary>
        /// 使用列修改 tile_UseColumnEdit
        /// </summary>
        public bool UseColumnModify { get; set; }

        /// <summary>
        /// 每X列 tile_PerColumn
        /// </summary>
        public int PerColumn { get; set; }

        /// <summary>
        /// 列修改数量 tile_VerticalGap
        /// </summary>
        public double PerColumnCount { get; set; }

        public TileImage(Dictionary<string, string> dict, List<Dictionary<string, string>> dictList)
        {
            TileCountPerRow = dict.ContainsKey("tile_HorizontalCount") ? double.Parse(dict["tile_HorizontalCount"]) : 0;
            TileCountPerColumn = dict.ContainsKey("tile_VerticalCount") ? double.Parse(dict["tile_VerticalCount"]) : 0;
            TileColor = new Color(dict.ContainsKey("tile_BrickColor") ? dict["tile_BrickColor"] : string.Empty);
            var titleImage = dictList.FirstOrDefault(o => o.First().Key == "");
            if (titleImage != null)
            {
                Image = ImageBase.Init(titleImage, dictList.Except(new List<Dictionary<string, string>>() { titleImage }).ToList());
            }
            ColorChange = dict.ContainsKey("tile_ColorVariance") ? double.Parse(dict["tile_ColorVariance"]) : 0;
            FadingChange = dict.ContainsKey("tile_FadeVariance") ? double.Parse(dict["tile_FadeVariance"]) : 0;
            RandomSeed = dict.ContainsKey("tile_RandomSeed") ? int.Parse(dict["tile_RandomSeed"]) : 0;
            JointColor = new Color(dict.ContainsKey("tile_MortarColor") ? dict["tile_MortarColor"] : string.Empty);
            var jointImage = dictList.FirstOrDefault(o => o.First().Key == "");
            if (jointImage != null)
            {
                JointImage = ImageBase.Init(jointImage, dictList.Except(new List<Dictionary<string, string>>() { jointImage }).ToList());
            }
            JointWidthHorizontal = dict.ContainsKey("tile_HorizontalGap") ? double.Parse(dict["tile_HorizontalGap"]) : 0;
            JointWidthVertical = dict.ContainsKey("tile_VerticalGap") ? double.Parse(dict["tile_VerticalGap"]) : 0;
            LockJointWidth = dict.ContainsKey("texture_ScaleLock") ? bool.Parse(dict["texture_ScaleLock"]) : false;
            Rough = dict.ContainsKey("tile_EdgeRoughness") ? double.Parse(dict["tile_EdgeRoughness"]) : 0;
            LinearMove = dict.ContainsKey("tile_LineShift") ? double.Parse(dict["tile_LineShift"]) : 0;
            Random = dict.ContainsKey("tile_RandomShift") ? double.Parse(dict["tile_RandomShift"]) : 0;
            UseRowModify = dict.ContainsKey("tile_UseRowEdit") ? bool.Parse(dict["tile_UseRowEdit"]) : false;
            PerRow = dict.ContainsKey("tile_PerRow") ? int.Parse(dict["tile_PerRow"]) : 0;
            PerRowCount = dict.ContainsKey("tile_HorizontalGap") ? double.Parse(dict["tile_HorizontalGap"]) : 0;
            UseColumnModify = dict.ContainsKey("tile_UseColumnEdit") ? bool.Parse(dict["tile_UseColumnEdit"]) : false;
            PerColumn = dict.ContainsKey("tile_PerColumn") ? int.Parse(dict["tile_PerColumn"]) : 0;
            PerColumnCount = dict.ContainsKey("tile_VerticalGap") ? double.Parse(dict["tile_VerticalGap"]) : 0;
        }

        public TileImage()
        {

        }
    }
}
