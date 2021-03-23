using DetailMaterialEntityClass.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Appearances
{
    /// <summary>
    /// 陶瓷外观
    /// </summary>
    public class CeramicAppearance : AppearanceBase
    {
        public Ceramic Ceramic { get; set; }

        public CeramicAppearance(AppearanceType assetType, List<Dictionary<string, string>> keyValuesList)
        {
            Ceramic = new Ceramic(keyValuesList);

            Information = new Information(keyValuesList);
            Dye = new Dye(keyValuesList);
            Type = assetType;
        }

        public CeramicAppearance()
        {

        }
    }

    /// <summary>
    /// 陶瓷类型
    /// </summary>
    public enum CeramicType
    {
        /// <summary>
        /// 陶瓷
        /// </summary>
        Ceramic,
        /// <summary>
        /// 瓷器
        /// </summary>
        Porcelain,
    }

    public enum CeramicFacing
    {
        /// <summary>
        /// 强光泽/玻璃
        /// </summary>
        GlazedOrGlass,
        /// <summary>
        /// 缎光
        /// </summary>
        Schreiner,
        /// <summary>
        /// 粗面
        /// </summary>
        Asperities,
    }

    /// <summary>
    /// 陶瓷
    /// </summary>
    public class Ceramic
    {
        /// <summary>
        /// 类型 ceramic_type
        /// </summary>
        public CeramicType CeramicType { get; set; }

        /// <summary>
        /// 颜色 ceramic_color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 图像
        /// </summary>
        public ImageBase Image { get; set; }

        /// <summary>
        /// 饰面 ceramic_application
        /// </summary>
        public CeramicFacing CeramicFacing { get; set; }

        public Ceramic(List<Dictionary<string, string>> keyValuesList)
        {
            var mainDict = keyValuesList.First();
            CeramicType = mainDict.ContainsKey("ceramic_type") ? (CeramicType)int.Parse(mainDict["ceramic_type"]) : CeramicType.Ceramic;
            Color = new Color(mainDict.ContainsKey("ceramic_color") ? mainDict["ceramic_color"] : string.Empty);
            var imageDict = keyValuesList.FirstOrDefault(o => o.First().Key == "ceramic_color");
            if (imageDict != null)
            {
                Image = ImageBase.Init(imageDict, keyValuesList.Except(new List<Dictionary<string, string>>() { imageDict }).ToList());
            }
            CeramicFacing = mainDict.ContainsKey("ceramic_application") ? (CeramicFacing)int.Parse(mainDict["ceramic_application"]) : CeramicFacing.Asperities;
        }

        public Ceramic()
        {

        }
    }
}
