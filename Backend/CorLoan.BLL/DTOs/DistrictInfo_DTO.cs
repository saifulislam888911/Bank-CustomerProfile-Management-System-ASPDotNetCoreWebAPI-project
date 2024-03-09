using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorLoan.BLL.DTOs
{   
    public class DistrictInfo_DTO : ModelBase<DistrictInfo_DTO>
    {
        public string? DIVISION_ID { get; set; }
        public string? DIVISION_NM { get; set; }


        public string? DISTRICT_ID { get; set; }
        public string? DISTRICT_NM { get; set; }
    }
}
