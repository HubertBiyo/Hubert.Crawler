using DotnetSpider.Core;
using DotnetSpider.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DotNetSpider.Housing
{
    public class HousingPipeline : BasePipeline
    {
        public override void Process(IList<ResultItems> resultItems, dynamic sender = null)
        {
            foreach (var resultItem in resultItems)
            {
                Console.WriteLine();
                Console.WriteLine("=================================================");
                StringBuilder builder = new StringBuilder();
               
                foreach (Housing entry in (List<Housing>)resultItem["LinesResult"])
                {
                    Console.WriteLine("标题: \t" + entry.Title);
                    Console.WriteLine("小区名称: \t" + entry.Village);
                    Console.WriteLine("装饰: \t" + entry.Decoration);
                    Console.WriteLine("总金额: \t" + entry.Total_Price);
                    Console.WriteLine("每平方米金额: \t" + entry.Per_Price);
                    Console.WriteLine("房间类型: \t" + entry.House_Type);
                    Console.WriteLine("面积: \t" + entry.House_Area);
                    Console.WriteLine("楼层: \t" + entry.Floor);
                    Console.WriteLine("方位: \t" + entry.Direcation);
                    Console.WriteLine("具体位置: \t" + entry.Location);
                }
               
                Console.WriteLine(builder);
                Console.WriteLine();
                Console.WriteLine("=================================================");
            }
        }
    }
}
