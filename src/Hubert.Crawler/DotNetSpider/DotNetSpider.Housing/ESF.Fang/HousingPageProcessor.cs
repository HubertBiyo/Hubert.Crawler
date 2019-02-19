using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Extraction;
using System.Collections.Generic;
using Common.Format;

namespace DotNetSpider.Housing
{
    public class HousingPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var totalPageElements = page.Selectable().SelectList(Selectors.XPath(".//dl[@class='clearfix']")).Nodes();
            List<Housing> results = new List<Housing>();

            foreach (var housingElements in totalPageElements)
            {
                var HousingModel = new Housing();
                // 标题
                HousingModel.Title = housingElements.Select(Selectors.XPath("./dd[1]/h4/a/span")).GetValue().Replace(" ", "");
                //小区名称
                HousingModel.Village = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./dd[1]/p[2]/a/text()")).GetValue());
                //装饰
                HousingModel.Decoration = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./dd[1]/p[3]")).GetValue());
                //总金额
                HousingModel.Total_Price = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./dd[2]/span[1]")).GetValue());
                //每平方米价格
                HousingModel.Per_Price = housingElements.Select(Selectors.XPath("./dd[2]/span[2]")).GetValue().Replace(" ", "");

                // 住房类型
                HousingModel.House_Type = RemoveHtml.RemoveHTMLTags(housingElements.Select(Selectors.XPath("./dd[1]/p[1]/text()[1]")).GetValue());
                //面积
                HousingModel.House_Area = housingElements.Select(Selectors.XPath("./dd[1]/p[1]/text()[2]")).GetValue().Replace(" ", "");
                //楼层
                HousingModel.Floor = housingElements.Select(Selectors.XPath("./dd[1]/p[1]/text()[3]")).GetValue().Replace(" ", "");
                //方位
                HousingModel.Direcation = housingElements.Select(Selectors.XPath("./dd[1]/p[1]/text()[4]")).GetValue().Replace(" ", "");
                //具体位置
                HousingModel.Location = housingElements.Select(Selectors.XPath("./dd[1]/p[2]/span")).GetValue().Replace(" ", "");
                var result = DataInput.Service.HousingService.Instance.AddHousingPrice(HousingModel);

                results.Add(HousingModel);
            }
            page.AddResultItem("LinesResult", results);
        }
    }
}
