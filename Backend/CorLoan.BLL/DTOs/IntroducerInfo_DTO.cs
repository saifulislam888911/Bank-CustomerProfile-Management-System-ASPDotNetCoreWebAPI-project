using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorLoan.BLL.DTOs
{
    public class IntroducerInfo_DTO : ModelBase<IntroducerInfo_DTO>
    {
        public string? INTRODUCER_ID { get; set; }
        public string? CUSTOMER_ID { get; set; }                

        public string? IntroducerType { get; set; }
        public string? IntroducerAccBranch { get; set; }
        public string? IntroducerAccNo { get; set; }
        public string? IntroducerDetails { get; set; }

    }
}
