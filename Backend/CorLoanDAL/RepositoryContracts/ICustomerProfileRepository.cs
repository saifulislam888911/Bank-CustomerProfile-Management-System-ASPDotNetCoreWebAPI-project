using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorLoan.DAL.Entities;

namespace CorLoan.DAL.RepositoryContracts
{
    public interface ICustomerProfileRepository
    {
        //<!----- CustomerProfile, IntroducerInfo, AddressList (POST) ----->
        CustomerProfile CustomerProfilePost(CustomerProfile obj_CustomerProfile, AuthParam authParam);

        //<!----- CustomerProfile, IntroducerInfo, AddressList (GET) ----->
        CustomerProfile CustomerProfileGet(string CUSTOMER_ID);

        //<!----- Customer (GET-ALL) ----->
        List<CustomerProfile> CustomerGetAll();


        //<!----- AddressList -> CountryInfo (GET-ALL) ----->
        List<CountryInfo> CountryGetAll();

        //<!----- AddressList -> DivisionInfo (GET-ALL) ----->
        List<DivisionInfo> DivisionGetAll(string pb_CountryId);

        //<!----- AddressList -> DistrictInfo (GET-ALL) ----->
        List<DistrictInfo> DistrictGetAll(string pb_DivisionId);

        //<!----- AddressList -> ThanaInfo (GET-ALL) ----->
        List<ThanaInfo> ThanaGetAll(string pb_DistrictId);
    }
}



