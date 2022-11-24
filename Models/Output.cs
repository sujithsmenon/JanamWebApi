using Microsoft.EntityFrameworkCore;

namespace JanamApi.Models
{
    [Keyless]
    public class Output
    {
        /*[Key]
        public int id { get; set; }*/
        public string Client_Category_Name { get; set; }
        public string CurrencyName { get; set; }
        public string amount_dr { get; set; }
        public string YTD_Amount_dr { get; set; }
        public string Bill_Amount { get; set; }
        public string YTD_Bill_amount { get; set; }
        public string Unbilled_Amount { get; set; }
        public string YTD_Unbilled_Amount { get; set; }
        public string Exchange_Rate { get; set; }
    }
}
