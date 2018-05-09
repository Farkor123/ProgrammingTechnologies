using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProduct
    {
        public MyProduct(Product P)
        {
            ProductID = P.ProductID;
            Name = P.Name;
            ProductNumber = P.ProductNumber;
            MakeFlag = P.MakeFlag;
            FinishedGoodsFlag = P.FinishedGoodsFlag;
            Color = P.Color;
            SafetyStockLevel = P.SafetyStockLevel;
            ReorderPoint = P.ReorderPoint;
            StandardCost = P.StandardCost;
            ListPrice = P.ListPrice;
            Size = P.Size;
            SizeUnitMeasureCode = P.SizeUnitMeasureCode;
            WeightUnitMeasureCode = P.WeightUnitMeasureCode;
            Weight = P.Weight;
            DaysToManufacture = P.DaysToManufacture;
            ProductLine = P.ProductLine;
            Class = P.Class;
            Style = P.Style;
            ProductSubcategoryID = P.ProductSubcategoryID;
            ProductModelID = P.ProductModelID;
            SellStartDate = P.SellStartDate;
            SellEndDate = P.SellEndDate;
            DiscontinuedDate = P.DiscontinuedDate;
            rowguid = P.rowguid;
            ModifiedDate = P.ModifiedDate;
        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public System.Nullable<decimal> Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public System.Nullable<int> ProductSubcategoryID { get; set; }
        public System.Nullable<int> ProductModelID { get; set; }
        public System.DateTime SellStartDate { get; set; }
        public System.Nullable<System.DateTime> SellEndDate { get; set; }
        public System.Nullable<System.DateTime> DiscontinuedDate { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}