using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorLoan.BLL.DTOs
{
    public class CustomerProfile_DTO : ModelBase<CustomerProfile_DTO>
    {          
        public string? CUSTOMER_ID { get; set; } 
        public string? CustomerName { get; set; }
        public string? CustomerFatherName { get; set; }
        public string? CustomerMotherName { get; set; }
        public string? CustomerGender { get; set; }
        public string? CustomerDateOfBirth { get; set; }
        public string? CustomerMaritalStatus { get; set; }
        public string? CustomerSpouseName { get; set; }
        public string? CustomerNID { get; set; }
    

        public IntroducerInfo_DTO IntroducerInformation { get; set; }
        public List<AddressList_DTO> AddressListInformation { get; set; } = new List<AddressList_DTO>();

    }
}
