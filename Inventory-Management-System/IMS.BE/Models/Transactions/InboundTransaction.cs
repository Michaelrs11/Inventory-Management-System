namespace IMS.BE.Models.Transactions
{
    public class InboundTransaction
    {
        public string SkuCode { get; set; } = string.Empty;
        public string GudangCode { get; set; } = string.Empty;
        public int StockBefore { get; set; }
        public int StockIn { get; set; }
        public int StockAfter { get; set; }
    }
}
