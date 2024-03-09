using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorLoan.DAL.Entities
{
    [Table("CUSTOMER_PROFILE_SA")]
    public class CustomerProfile : ModelBase<CustomerProfile>
    {
        //[Required]
        [Key]
        [Column("CUSTOMER_ID")]
        [Display(Name = "Customer ID")]
        public string? CUSTOMER_ID { get; set; }

        [Column("CUSTOMER_NAME")]
        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }

        [Column("CUSTOMER_FATHER_NAME")]
        [Display(Name = "CUSTOMER FATHER NAME")]
        public string? CustomerFatherName { get; set; }

        [Column("CUSTOMER_MOTHER_NAME")]
        [Display(Name = "CUSTOMER MOTHER NAME")]
        public string? CustomerMotherName { get; set; }

        [Column("CUSTOMER_GENDER")]
        [Display(Name = "CUSTOMER GENDER")]
        public string? CustomerGender { get; set; }

        [Column("CUSTOMER_DATE_OF_BIRTH")]
        [Display(Name = "CUSTOMER DATE OF BIRTH")]
        public string? CustomerDateOfBirth { get; set; }

        [Column("CUSTOMER_MARITAL_STATUS")]
        [Display(Name = "CUSTOMER MARITAL STATUS")]
        public string? CustomerMaritalStatus { get; set; }

        [Column("CUSTOMER_SPOUSE_NAME")]
        [Display(Name = "CUSTOMER SPOUSE NAME")]
        public string? CustomerSpouseName { get; set; }

        [Column("CUSTOMER_NID")]
        [Display(Name = "CUSTOMER NID")]
        public string? CustomerNID { get; set; }



        [NotMapped]
        public IntroducerInfo IntroducerInformation { get; set; } = new IntroducerInfo();

        [NotMapped]
        public List<AddressList> AddressListInformation { get; set; } = new List<AddressList>();

    }
}
