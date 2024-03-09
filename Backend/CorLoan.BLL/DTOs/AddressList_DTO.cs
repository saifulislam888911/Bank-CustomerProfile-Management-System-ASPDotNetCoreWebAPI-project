using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorLoan.BLL.DTOs
{
    public class AddressList_DTO : ModelBase<AddressList_DTO>
    {
        public string? ADDRESS_ID { get; set; }
        public string? CUSTOMER_ID { get; set; }

        public string? COUNTRY_ID { get; set; }
        public string? DIVISION_ID { get; set; }
        public string? DISTRICT_ID { get; set; }
        public string? THANA_ID { get; set; }

        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }
        public string? ZipCode { get; set; }
        public string? CountryName { get; set; } 
        //public string? COUNTRY_NM { get; set; }
        public string? DivisionName { get; set; } 
        //public string? DIVISION_NM { get; set; } 
        public string? DistrictName { get; set; } 
        public string? ThanaName { get; set; }
        public string? PhoneNo { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }

    }
}
