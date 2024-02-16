using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DatabaseLib.Data;
using System.Configuration;

namespace DatabaseLib
{
    public interface IMS
    {
        Task<List<InventoryData>> GetData();
        Task InsertValue(InventoryData inventory);
    }
}
