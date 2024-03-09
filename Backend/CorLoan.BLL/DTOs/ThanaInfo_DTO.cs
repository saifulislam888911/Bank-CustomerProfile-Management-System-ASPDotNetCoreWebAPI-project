using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorLoan.BLL.DTOs
{
    public class ThanaInfo_DTO : ModelBase<ThanaInfo_DTO>
    {
        public string? DISTRICT_ID { get; set; }
        public string? DISTRICT_NM { get; set; }


        public string? THANA_ID { get; set; }
        public string? THANA_NM { get; set; }
    }
}
