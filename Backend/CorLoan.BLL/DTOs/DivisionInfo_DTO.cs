using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorLoan.BLL.DTOs
{
    public class DivisionInfo_DTO : ModelBase<DivisionInfo_DTO>
    {
        public string? COUNTRY_ID { get; set; }
        public string? COUNTRY_NM { get; set; }


        public string? DIVISION_ID { get; set; }
        public string? DIVISION_NM { get; set; }
    }
}
