using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using DatabaseLib.Data;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseLib
{
    public class IMSData : IMS
    {
        private readonly SqlData _DB;

        public IMSData(SqlData DB)
        {
            _DB = DB;
        }

        public Task<List<InventoryData>> GetData()
        {
            string sql = "select * from dbo.Inventory";
            return _DB.UploadData<InventoryData, dynamic>(sql, new { });
        }
        public Task InsertValue(InventoryData inventory)
        {
            string sql = @"insert into dbo.Inventory(Date_Added, Name, Manufacture, Model_Name, Quantity, Cost_Price, Sell_Price,
                                                      Location, Condition, Availabel, Allocated, Suppliers, Notes, Category, Serial_Number)
                            values(@Date_Added, @Name, @Manufacture, @Model_Name, @Quantity, @Cost_Price, @Sell_Price,
                                                      @Location, @Condition, @Availabel, @Allocated, @Suppliers, @Notes, @Category, @Serial_Number);";
            return _DB.InsertData(sql, inventory);
        }
    }
}
