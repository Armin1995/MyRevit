using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailMaterialEntityClass.Images;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 砖石外观
    /// </summary>
    public class MasonryAppearance : AppearanceBase
    {
        /// <summary>
        /// 砖石
        /// </summary>
        public Masonry Masonry { get; set; }

        /// <summary>
        /// 砖石浮雕图案
        /// </summary>
        public MasonryReliefPattern MasonryReliefPattern { get; set; }

        public MasonryAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Masonry = new Masonry(keyValuesList);
            MasonryReliefPattern = new MasonryReliefPattern(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public MasonryAppearance()
        {

        }
    }

    /// <summary>
    /// 砖石类型
    /// </summary>
    public enum MasonryType
    {
        /// <summary>
        /// CMU
        /// </summary>
        CMU = 0,
        /// <summary>
        /// 砖石
        /// </summary>
        Masonry = 1,
    }

    /// <summary>
    /// 砖石饰面
    /// </summary>
    public enum MasonryFinish
    {
        /// <summary>
        /// 有光泽
        /// </summary>
        Glossy = 0,
        /// <summary>
        /// 粗面
        /// </summary>
        Asperities = 1,
        /// <summary>
        /// 未装饰
        /// </summary>
        Unadorned = 2,
    }

    /// <summary>
    /// 砖石
    /// </summary>
    public class Masonry
    {
        /// <summary>
        /// 砖石类型 masonrycmu_type
        /// </summary>
        public MasonryType MasonryType { get; set; }

        /// <summary>
        /// 砖石颜色(多选一) masonrycmu_color (120,120,120) / 255 = (0.471,0.471,0.471)
        /// </summary>
        public Color MasonryColor { get; set; }

        /// <summary>
        /// 砖石图像(多选一)
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 砖石饰面 masonrycmu_application
        /// </summary>
        public MasonryFinish MasonryFinish { get; set; }

        public Masonry(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            MasonryType = mainDict.ContainsKey("masonrycmu_type") ? (MasonryType)int.Parse(mainDict["masonrycmu_type"]) : MasonryType.CMU;
            MasonryColor = new Color(mainDict.ContainsKey("masonrycmu_color") ? mainDict["masonrycmu_color"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "masonrycmu_color");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            MasonryFinish = mainDict.ContainsKey("masonrycmu_application") ? (MasonryFinish)int.Parse(mainDict["masonrycmu_application"]) : MasonryFinish.Glossy;
        }

        public Masonry()
        {

        }
    }

    /// <summary>
    /// 砖石浮雕图案
    /// </summary>
    public class MasonryReliefPattern
    {
        /// <summary>
        /// 使用浮雕图案 masonrycmu_pattern
        /// </summary>
        public bool UseReliefPattern { get; set; }

        /// <summary>
        /// 浮雕图案图像
        /// </summary>
        public ImageBase ReliefPatternImage { get; set; }

        /// <summary>
        /// 浮雕图案数量 masonrycmu_pattern_height
        /// </summary>
        public double ReliefPatternNumber { get; set; }

        public MasonryReliefPattern(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            UseReliefPattern = mainDict.ContainsKey("masonrycmu_pattern") ? int.Parse(mainDict["masonrycmu_pattern"]) != 0 : false;
            if (UseReliefPattern)
            {
                var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "masonrycmu_pattern_height" || o.First().Key == "masonrycmu_pattern");
                if (imageDict != null)
                {
                    ReliefPatternImage = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
                }
                ReliefPatternNumber = mainDict.ContainsKey("masonrycmu_pattern_height") ? double.Parse(mainDict["masonrycmu_pattern_height"]) : 0.15d;
            }
        }

        public MasonryReliefPattern()
        {

        }
    }
}
