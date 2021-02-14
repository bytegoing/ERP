using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进销存管理系统.Models
{
    public class Stock
    {
        private int no;
        private int goodNo;
        private string goodName;
        private string goodTypeName;
        private int warehouseNo;
        private string warehouseName;
        private string type;
        private string reason;
        private int inCount;
        private int inSinglePrice;
        private string inSinglePriceYuan;
        private int outCount;
        private int outSinglePrice;
        private string outSinglePriceYuan;
        private int remainingCount;
        private int remainingPrice;
        private string remainingPriceYuan;
        private int businessUnitNo;
        private string businessUnitType;
        private string businessUnitName;
        private string operatorNo;
        private string operatorName;
        private DateTime date;

        public int No { get => no; set => no = value; }
        public int GoodNo { get => goodNo; set => goodNo = value; }
        public string GoodName { get => goodName; set => goodName = value; }
        public string GoodTypeName { get => goodTypeName; set => goodTypeName = value; }
        public int WarehouseNo { get => warehouseNo; set => warehouseNo = value; }
        public string WarehouseName { get => warehouseName; set => warehouseName = value; }
        public string Type { get => type; set => type = value; }
        public string Reason { get => reason; set => reason = value; }
        public int InCount { get => inCount; set => inCount = value; }
        public int InSinglePrice { get => inSinglePrice; set => inSinglePrice = value; }
        public string InSinglePriceYuan { get => inSinglePriceYuan; set => inSinglePriceYuan = value; }
        public int OutCount { get => outCount; set => outCount = value; }
        public int OutSinglePrice { get => outSinglePrice; set => outSinglePrice = value; }
        public string OutSinglePriceYuan { get => outSinglePriceYuan; set => outSinglePriceYuan = value; }
        public int RemainingCount { get => remainingCount; set => remainingCount = value; }
        public int RemainingPrice { get => remainingPrice; set => remainingPrice = value; }
        public string RemainingPriceYuan { get => remainingPriceYuan; set => remainingPriceYuan = value; }
        public int BusinessUnitNo { get => businessUnitNo; set => businessUnitNo = value; }
        public string BusinessUnitType { get => businessUnitType; set => businessUnitType = value; }
        public string BusinessUnitName { get => businessUnitName; set => businessUnitName = value; }
        public string OperatorNo { get => operatorNo; set => operatorNo = value; }
        public string OperatorName { get => operatorName; set => operatorName = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
