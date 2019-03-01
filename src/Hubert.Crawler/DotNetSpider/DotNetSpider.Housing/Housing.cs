using System;

namespace DotNetSpider.Housing
{
    public class Housing
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Village { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 几室几厅
        /// </summary>
        public string  House_Type { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public string Total_Price { get; set; }
        /// <summary>
        /// 住房面积
        /// </summary>
        public string House_Area { get; set; }
        /// <summary>
        /// 每平米金额
        /// </summary>
        public string Per_Price { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string  Contact { get; set; }
        /// <summary>
        /// 所属层类型（中层、高层）
        /// </summary>
        public string Floor { get; set; }
        /// <summary>
        /// 房子方位
        /// </summary>
        public string Direcation { get; set; }
        /// <summary>
        /// 建筑时间
        /// </summary>
        public string Build_Time { get; set; }
        /// <summary>
        /// 装饰 （毛坯、精装、简装）
        /// </summary>
        public string  Decoration { get; set; }
        /// <summary>
        /// 具体位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 抵押物（个人产权）
        /// </summary>
        public string Propety { get; set; }
        /// <summary>
        /// 普通住宅
        /// </summary>
        public string  Indivdual_House { get; set; }
        /// <summary>
        /// 释放时间
        /// </summary>
        public string Release_Time { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 爬虫类型  新房(newhouse)   二手房(esf)  等等
        /// </summary>
        public string House_SpiderType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string  Remark { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

    }
}
