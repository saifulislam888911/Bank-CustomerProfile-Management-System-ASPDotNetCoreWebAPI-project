using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorLoan.DAL.Entities
{    
    [Table("ADDRESS_LIST_SA")]
    public class AddressList : ModelBase<AddressList>
    {
        [Key]
        [Column("ADDRESS_ID")]
        [Display(Name = "ADDRESS ID")]
        public string? ADDRESS_ID { get; set; }

        [Key]
        [Column("CUSTOMER_ID")]
        [Display(Name = "Customer ID")]
        public string? CUSTOMER_ID { get; set; }


        [Key]
        [Column("COUNTRY_ID")]
        [Display(Name = "COUNTRY ID")]
        public string? COUNTRY_ID { get; set; }

        [Key]
        [Column("DIVISION_ID")]
        [Display(Name = "DIVISION ID")]
        public string? DIVISION_ID { get; set; }

        [Key]
        [Column("DISTRICT_ID")]
        [Display(Name = "DISTRICT ID")]
        public string? DISTRICT_ID { get; set; }

        [Key]
        [Column("THANA_ID")]
        [Display(Name = "THANA ID")]
        public string? THANA_ID { get; set; }


        [Column("ADDRESS_TYPE")]
        [Display(Name = "ADDRESS TYPE")]
        public string? AddressType { get; set; }

        [Column("ADDRESS")]
        [Display(Name = "ADDRESS")]
        public string? Address { get; set; }

        [Column("CITY_NAME")]
        [Display(Name = "CITY NAME")]
        public string? CityName { get; set; }

        [Column("ZIP_CODE")]
        [Display(Name = "ZIP CODE")]
        public string? ZipCode { get; set; }


        [Column("COUNTRY_NAME")]
        [Display(Name = "COUNTRY NAME")]
        public string? CountryName { get; set; }

        [Column("DIVISION_NAME")]
        [Display(Name = "DIVISION NAME")]
        public string? DivisionName { get; set; } 

        [Column("DISTRICT_NAME")]
        [Display(Name = "DISTRICT NAME")]
        public string? DistrictName { get; set; }

        [Column("THANA_NAME")]
        [Display(Name = "THANA NAME")]
        public string? ThanaName { get; set; }

        [Column("PHONE_NO")]
        [Display(Name = "PHONE NO")]
        public string? PhoneNo { get; set; }

        [Column("MOBILE_NO")]
        [Display(Name = "MOBILE NO")]
        public string? MobileNo { get; set; }

        [Column("EMAIL")]
        [Display(Name = "EMAIL")]
        public string? Email { get; set; }

    }
}
