using Common.Format;
using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Extraction;
using System;
using System.Collections.Generic;

namespace DotNetSpider.Housing.NewHouse.Fang
{
    public class sjzHousingPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var totalPageElement = page.Selectable().SelectList(Selectors.XPath(".//div[@class='nlc_details']")).Nodes();

            List<Housing> results = new List<Housing>();
            foreach (var housingElement in totalPageElement)
            {
                var housingModel = new Housing();
                {
                    housingModel.Village = RemoveHtml.RemoveHTMLTags(housingElement.Select(Selectors.XPath("./div[@class='house_value clearfix']/div[@class='nlcd_name']/a")).GetValue());
                    //小区名称
                    housingModel.Village = RemoveHtml.RemoveHTMLTags(housingElement.Select(Selectors.XPath("./div[@class='house_value clearfix']/div[@class='nlcd_name']/a")).GetValue());
                    //备注
                    housingModel.Remark = RemoveHtml.RemoveHTMLTags(housingElement.Select(Selectors.XPath("./div[@class='house_type clearfix']")).GetValue()).Replace("\n", "");

                    // 联系方式
                    housingModel.Contact = RemoveHtml.RemoveHTMLTags(housingElement.Select(Selectors.XPath("./div[@class='relative_message clearfix']/div[@class='tel']/p")).GetValue());
                    //每平方米价格
                    //housingModel.Per_Price = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./div[@class='nhouse_price']")).GetValue());
                    housingModel.Per_Price = RemoveHtml.RemoveHTMLTags(housingElement.Select(Selectors.XPath("./div[5]")).GetValue());
                    //具体位置
                    housingModel.Location = RemoveHtml.RemoveHTMLTags(housingElement.Select(Selectors.XPath("./div[@class='relative_message clearfix']/div[@class='address']/a")).GetValue());
                    //爬虫房源类型 
                    housingModel.House_SpiderType = "newhouse";
                    housingModel.City = "石家庄";
                    //小区名称
                    housingModel.Title = null;
                    //装饰
                    housingModel.Decoration = null;
                    //总金额
                    housingModel.Total_Price = null;
                    // 住房类型
                    housingModel.House_Type = null;
                    //面积
                    housingModel.House_Area = null;

                    //楼层
                    housingModel.Floor = null;
                    //方位
                    housingModel.Direcation = null;
                };
                var result = DataInput.Service.HousingService.Instance.AddHousingPrice(housingModel);
                results.Add(housingModel);
            }
            page.AddResultItem("LinesResult", results);
        }
    }
}
