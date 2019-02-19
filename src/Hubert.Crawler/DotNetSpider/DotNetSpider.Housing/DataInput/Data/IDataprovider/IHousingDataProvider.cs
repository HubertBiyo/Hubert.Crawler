using Common.Data;

namespace DotNetSpider.Housing.DataInput.Data
{
    public interface IHousingDataProvider:IDataProvider
    {
        bool AddHousingPrice(Housing model);
    }
}
