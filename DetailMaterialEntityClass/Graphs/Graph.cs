
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = DetailMaterialEntityClass.Images.Color;

namespace DetailMaterialEntityClass.Graphs
{
    /// <summary>
    /// 图形
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// 使用渲染外观
        /// </summary>
        public bool UseRenderAppearanceForShading { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 透明度
        /// </summary>
        public int Transparency { get; set; }

        /// <summary>
        /// 表面填充图案
        /// </summary>
        //public FillPatternElement SurfacePattern { get; set; }

        /// <summary>
        /// 表面填充图案颜色
        /// </summary>
        public Color SurfacePatternColor { get; set; }

        /// <summary>
        /// 表面填充图案对齐
        /// </summary>
        public object Alignment { get; set; }

        /// <summary>
        /// 截面填充图案
        /// </summary>
        //public FillPatternElement CutPattern { get; set; }

        /// <summary>
        /// 截面填充图案颜色
        /// </summary>
        public Color CutPatternColor { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="material"></param>
        public Graph(bool useRenderAppearanceForShading, string color, int transparency, string surfacePatternColor, string sutPatternColor)
        {
            UseRenderAppearanceForShading = useRenderAppearanceForShading;
            Color = new Color(color);
            Transparency = transparency;
            //SurfacePattern = material.Document.GetElement(material.SurfacePatternId) as FillPatternElement;
            SurfacePatternColor = new Color(surfacePatternColor);
            //CutPattern = material.Document.GetElement(material.CutPatternId) as FillPatternElement;
            CutPatternColor = new Color(sutPatternColor);
        }

        public Graph()
        {

        }
    }

}
