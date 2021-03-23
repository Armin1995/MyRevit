
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailMaterialEntityClass.Identifications
{
    /// <summary>
    /// 标识
    /// </summary>
    public class Identification
    {
        /// <summary>
        /// 材质ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string MaterialClass { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 模型
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 注释记号
        /// </summary>
        public double Param { get; set; }

        /// <summary>
        /// 标记
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="material"></param>
        public Identification(int id, string name, string description, string materialClass, string comments, string keyword, string manufacturer, string model, double cost, string url, double param, string number)
        {
            Id = id;
            Name = name;
            Description = description;
            MaterialClass = materialClass;
            Comments = comments;
            Keyword = keyword;
            Manufacturer = manufacturer;
            Model = model;
            Cost = cost;
            Url = url;
            Param = param;
            Number = number;
        }

        public Identification()
        {

        }
    }
}
