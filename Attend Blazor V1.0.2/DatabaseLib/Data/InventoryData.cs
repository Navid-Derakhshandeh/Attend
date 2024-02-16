using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLib.Data
{
    public class InventoryData
    {
        public int DateAdded { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public string Model_Name { get; set; }
        public int Quantity { get; set; }
        public int Cost_Price { get; set; }
        public int Sell_Price { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
        public string Availabel { get; set; }
        public string Allocated { get; set; }
        public string Suppliers { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public string Serial_Number { get; set; }                                                    
    }
}
