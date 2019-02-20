using Common.MysqlHelper;
using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace DotNetSpider.Housing.DataInput.Data
{
    public class HousingDataProvider : IHousingDataProvider
    {
        public bool AddHousingPrice(Housing model)
        {
            StringBuilder sql = new StringBuilder(@"
INSERT INTO Housing (Id, Title, Village, Region, House_Type
	, Total_Price, House_Area, Per_Price, Floor, Direcation
	, Build_Time, Decoration, Location, Propety, Indivdual_House
	, Release_Time, CreateTime, Contact, House_SpiderType, Remark)
VALUES (@Id, @Title, @Village, @Region, @House_Type
	, @Total_Price, @House_Area, @Per_Price, @Floor, @Direcation
	, @Build_Time, @Decoration, @Location, @Propety, @Indivdual_House
	, @Release_Time, @CreateTime, @Contact, @House_SpiderType, @Remark)
");
            using (var command = new MySqlCommand(sql.ToString()))
            {
                command.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString("N"));
                command.Parameters.AddWithNullableValue("@Title", model.Title);
                command.Parameters.AddWithNullableValue("@Village", model.Village);
                command.Parameters.AddWithNullableValue("@Region", model.Region);
                command.Parameters.AddWithNullableValue("@House_Type", model.House_Type);
                command.Parameters.AddWithNullableValue("@Total_Price", model.Total_Price);
                command.Parameters.AddWithNullableValue("@House_Area", model.House_Area);
                command.Parameters.AddWithNullableValue("@Per_Price", model.Per_Price);
                command.Parameters.AddWithNullableValue("@Floor", model.Floor);
                command.Parameters.AddWithNullableValue("@Direcation", model.Direcation);
                command.Parameters.AddWithNullableValue("@Build_Time", model.Build_Time);
                command.Parameters.AddWithNullableValue("@Decoration", model.Decoration);
                command.Parameters.AddWithNullableValue("@Location", model.Location);
                command.Parameters.AddWithNullableValue("@Propety", model.Propety);
                command.Parameters.AddWithNullableValue("@Indivdual_House", model.Indivdual_House);
                command.Parameters.AddWithNullableValue("@Release_Time", model.Release_Time);
                command.Parameters.AddWithNullableValue("@CreateTime",DateTime.Now);
                command.Parameters.AddWithNullableValue("@Contact", model.Contact);
                command.Parameters.AddWithNullableValue("@House_SpiderType", model.House_SpiderType);
                command.Parameters.AddWithNullableValue("@Remark", model.Remark);
                using (var executor = new MysqlExecutor())
                {
                    return executor.ExecuteNonQuery(command, DataProviders.MainConnectionString_ReadWrite) > 0;
                }
            }
        }
    }
}
