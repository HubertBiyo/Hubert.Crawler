using DotnetSpider.Core;
using DotnetSpider.Core.Scheduler;
using DotNetSpider.Housing;
using System;

namespace DotNetSpider.Run
{
    public class Program
    {
        static void Main(string[] args)
        {
            Spider spider = Spider.Create(
                  new QueueDuplicateRemovedScheduler(),
                  new Housing.NewHouse.Fang.HousingPageProcessor())
                  .AddPipeline(new HousingPipeline());
            // Start crawler 启动爬虫
            spider.EncodingName = "GBK";
            spider.AddRequests($"https://hd.newhouse.fang.com/house/s/");
            for (int i = 3; i < 12; ++i)
            {
                // Add start/feed urls. 添加初始采集链接
                spider.AddRequests($"https://hd.newhouse.fang.com/house/s/b92/?ctm=1.hd.xf_search.page.{i}");
            }
            spider.Run();
            Console.Read();
        }

        //// 房天下 邯郸 二手房 爬虫
        //static void Main(string[] args)
        //{
        //    Spider spider = Spider.Create(
        //          new QueueDuplicateRemovedScheduler(),
        //          new HousingPageProcessor())
        //          .AddPipeline(new HousingPipeline());
        //    // Start crawler 启动爬虫
        //    spider.EncodingName = "GBK";
        //    spider.AddRequests($"https://hd.esf.fang.com/house-a0848/");
        //    for (int i = 2; i < 15; ++i)
        //    {
        //        // Add start/feed urls. 添加初始采集链接
        //        spider.AddRequests($"https://hd.esf.fang.com/house-a0848/i3{i}/");
        //    }
        //    spider.Run();
        //    Console.Read();
        //}
    }
}
