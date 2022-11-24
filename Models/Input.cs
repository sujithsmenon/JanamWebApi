using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JanamApi.Models
{
    [Keyless]
    public class Input
    {
        [Display(Name = "Financial Year : ")]
        public int FinYear { get; set; }

        //[DataType(DataType.Date)]
        [Display(Name = "From Date : ")]
        public string FromDate { get; set; }

        // [DataType(DataType.Date)]
        [Display(Name = "To Date : ")]
        public string ToDate { get; set; }
    }
}
