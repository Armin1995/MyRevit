using DetailMaterialEntityClass.Appearances;
using DetailMaterialEntityClass.Graphs;
using DetailMaterialEntityClass.Identifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Materials
{
    public class MaterialInfo
    {
        //[NonSerialized]
        //private Material material;
        ///// <summary>
        ///// 材质
        ///// </summary>
        //public Material Material
        //{
        //    get { return material; }
        //    set { material = value; }
        //}

        /// <summary>
        /// 标识
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// 图形
        /// </summary>
        public Graph Graph { get; set; }

        /// <summary>
        /// 外观
        /// </summary>
        public AppearanceBase AppearanceBase { get; set; }

        /// <summary>
        /// 贴图路径列表
        /// </summary>
        public static List<string> TexturePathList { get; set; } = new List<string>();

        public MaterialInfo()
        {

        }
    }
}
