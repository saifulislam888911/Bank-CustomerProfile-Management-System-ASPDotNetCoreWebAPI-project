using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorLoan.BLL.DTOs;
using CorLoan.DAL.Entities;

namespace CorLoan.BLL.ServiceContracts
{
    public interface ICustomerProfileService
    {     
        //<!----- CustomerProfile, IntroducerInfo, AddressList (POST) ----->
        CustomerProfile_DTO CustomerProfilePost(CustomerProfile_DTO obj_CustomerProfile_DTO, AuthParam authParam);

        //<!----- CustomerProfile, IntroducerInfo, AddressList (GET) ----->
        CustomerProfile_DTO CustomerProfileGet(string CUSTOMER_ID);

        //<!----- Customer (GET-ALL) ----->
        public List<CustomerProfile> CustomerGetAll();



        //<!----- AddressList -> CountryInfo (GET-ALL) ----->
        public List<CountryInfo> CountryGetAll();

        //<!----- AddressList -> DivisionInfo (GET-ALL) ----->
        public List<DivisionInfo_DTO> DivisionGetAll(string pb_CountryId);

        //<!----- AddressList -> DistrictInfo (GET-ALL) ----->
        public List<DistrictInfo_DTO> DistrictGetAll(string pb_DivisionId);

        //<!----- AddressList -> ThanaInfo (GET-ALL) ----->
        public List<ThanaInfo_DTO> ThanaGetAll(string pb_DistrictId);
    }
}
