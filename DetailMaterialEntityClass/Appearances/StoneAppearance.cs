using DetailMaterialEntityClass.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Appearances
{
    public class StoneAppearance : AppearanceBase
    {
        /// <summary>
        /// 石料
        /// </summary>
        public Stone Stone { get; set; }

        /// <summary>
        /// 饰面凹凸
        /// </summary>
        public StoneFinishConcaveConvex StoneFinishConcaveConvex { get; set; }

        /// <summary>
        /// 浮雕图案
        /// </summary>
        public StonePlasticReliefPattern StonePlasticReliefPattern { get; set; }

        public StoneAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Stone = new Stone(keyValuesList);
            StoneFinishConcaveConvex = new StoneFinishConcaveConvex(keyValuesList);
            StonePlasticReliefPattern = new StonePlasticReliefPattern(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public StoneAppearance()
        {

        }
    }

    /// <summary>
    /// 饰面类型
    /// </summary>
    public enum StoneFinishType
    {
        /// <summary>
        /// 抛光
        /// </summary>
        Polishing,
        /// <summary>
        /// 有光泽
        /// </summary>
        Gloss,
        /// <summary>
        /// 粗面
        /// </summary>
        Asperities,
        /// <summary>
        /// 未装饰
        /// </summary>
        Unadorned,
    }

    /// <summary>
    /// 石料
    /// </summary>
    public class Stone
    {
        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 饰面 stone_application
        /// </summary>
        public StoneFinishType StoneFinishType { get; set; }

        public Stone(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            var imageDict = keyValuesList.LastOrDefault(o => o.First().Key == "stone_bump_amount");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            StoneFinishType = mainDict.ContainsKey("stone_application") ? (StoneFinishType)int.Parse(mainDict["stone_application"]) : StoneFinishType.Polishing;
        }

        public Stone()
        {

        }
    }

    public enum StoneFinishConcaveConvexType
    {
        Non = 0,
        /// <summary>
        /// 抛光花岗岩
        /// </summary>
        PolishingGranite = 1,
        /// <summary>
        /// 墙石料
        /// </summary>
        StoneWall,
        /// <summary>
        /// 有光泽的大理石
        /// </summary>
        GlossMarble,
        /// <summary>
        /// 自定义
        /// </summary>
        UserDefined,
    }

    /// <summary>
    /// 饰面凹凸
    /// </summary>
    public class StoneFinishConcaveConvex
    {
        /// <summary>
        /// 使用饰面凹凸 stone_bump == 0 false
        /// </summary>
        public bool UseStoneFinishConcaveConvex { get; set; }
        /// <summary>
        /// 类型 stone_bump
        /// </summary>
        public StoneFinishConcaveConvexType StoneFinishConcaveConvexType { get; set; }

        /// <summary>
        /// 自定义图像
        /// </summary>
        public ImageBase DefinedImage { get; set; }

        /// <summary>
        /// 数量 stone_bump_amount
        /// </summary>
        public double Count { get; set; }

        public StoneFinishConcaveConvex(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseStoneFinishConcaveConvex = mainDict.ContainsKey("stone_bump") ? int.Parse(mainDict["stone_bump"]) != 0 : false;
            if (UseStoneFinishConcaveConvex)
            {
                StoneFinishConcaveConvexType = mainDict.ContainsKey("stone_bump") ? (StoneFinishConcaveConvexType)int.Parse(mainDict["stone_bump"]) : StoneFinishConcaveConvexType.PolishingGranite;
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "stone_bump_amount");
                if (imageDict != null)
                {
                    DefinedImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Count = mainDict.ContainsKey("stone_bump_amount") ? double.Parse(mainDict["stone_bump_amount"]) : 0d;
            }
        }

        public StoneFinishConcaveConvex()
        {

        }
    }

    /// <summary>
    /// 浮雕图案
    /// </summary>
    public class StonePlasticReliefPattern
    {
        /// <summary>
        /// 使用浮雕图案 stone_pattern
        /// </summary>
        public bool UseStonePlasticReliefPattern { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 数量 stone_pattern_amount
        /// </summary>
        public double Count { get; set; }

        public StonePlasticReliefPattern(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseStonePlasticReliefPattern = mainDict.ContainsKey("stone_pattern") ? int.Parse(mainDict["stone_pattern"]) != 0 : false;
            if (UseStonePlasticReliefPattern)
            {
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "stone_pattern_amount");
                if (imageDict != null)
                {
                    Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                Count = mainDict.ContainsKey("stone_pattern_amount") ? double.Parse(mainDict["stone_pattern_amount"]) : 0d;
            }
        }

        public StonePlasticReliefPattern()
        {

        }
    }
}
