using Common.Format;
using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Extraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSpider.Housing.NewHouse.Fang
{
    public class HousingPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var totalPageElements = page.Selectable().SelectList(Selectors.XPath(".//div[@class='nlc_details']")).Nodes();
            List<Housing> results = new List<Housing>();

            foreach (var housingElements in totalPageElements)
            {
                var HousingModel = new Housing();
                //小区名称
                HousingModel.Village = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./div[@class='house_value clearfix']/div[@class='nlcd_name']/a")).GetValue());
                //备注
                HousingModel.Remark = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./div[@class='house_type clearfix']")).GetValue()).Replace("\n","");
                //小区名称
                HousingModel.Title = null;
                //装饰
                HousingModel.Decoration = null;
                //总金额
                HousingModel.Total_Price = null;
                // 联系方式
                HousingModel.Contact= RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./div[@class='relative_message clearfix']/div[@class='tel']/p")).GetValue());
                //每平方米价格
                HousingModel.Per_Price = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./div[@class='nhouse_price']")).GetValue());
                // 住房类型
                HousingModel.House_Type = null;
                //面积
                HousingModel.House_Area = null;
                //爬虫房源类型 
                HousingModel.House_SpiderType = "新房";
                //楼层
                HousingModel.Floor = null;
                //方位
                HousingModel.Direcation = null;
                //具体位置
                HousingModel.Location = RemoveHtml.RemoveHTMLTags( housingElements.Select(Selectors.XPath("./div[@class='relative_message clearfix']/div[@class='address']/a")).GetValue());
                var result = DataInput.Service.HousingService.Instance.AddHousingPrice(HousingModel);

                results.Add(HousingModel);
            }
            page.AddResultItem("LinesResult", results);
        }
    }
}
