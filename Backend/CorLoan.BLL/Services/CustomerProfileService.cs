using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CorLoan.BLL.DTOs;
using CorLoan.BLL.ServiceContracts;
using CorLoan.DAL.Entities;
using CorLoan.DAL.Repositories;
using CorLoan.DAL.RepositoryContracts;

namespace CorLoan.BLL.Services
{
    public class CustomerProfileService : ICustomerProfileService
    {
        private readonly ICustomerProfileRepository _customerProfileRepository;
        private readonly IMapper _mapper;

        public CustomerProfileService(ICustomerProfileRepository customerProfileRepository, IMapper mapper)
        {
            _customerProfileRepository = customerProfileRepository;
            _mapper = mapper;
        }


        //<!----- CustomerProfile, IntroducerInfo, AddressList (POST) ----->
        public CustomerProfile_DTO CustomerProfilePost(CustomerProfile_DTO obj_CustomerProfile_DTO, AuthParam authParam)
        {
            return _mapper.Map<CustomerProfile, CustomerProfile_DTO>(_customerProfileRepository.CustomerProfilePost(_mapper.Map<CustomerProfile_DTO, CustomerProfile>(obj_CustomerProfile_DTO), authParam));
        }

        //<!----- CustomerProfile, IntroducerInfo, AddressList (GET) ----->
        public CustomerProfile_DTO CustomerProfileGet(string CUSTOMER_ID)
        {
            return _mapper.Map<CustomerProfile, CustomerProfile_DTO>(_customerProfileRepository.CustomerProfileGet(CUSTOMER_ID));
        }

        //<!----- Customer (GET-ALL) ----->
        public List<CustomerProfile> CustomerGetAll()
        {
            return _customerProfileRepository.CustomerGetAll();

            //List<CustomerProfile_DTO> mappedCustomerProfile = _mapper.Map<List<CustomerProfile_DTO>>(_customerProfileRepository.CustomerGetAll()).ToList();

           //return mappedCustomerProfile;
        }



        //<!----- AddressList -> CountryInfo (GET-ALL) ----->
        public List<CountryInfo> CountryGetAll()
        {
            return _customerProfileRepository.CountryGetAll();
        }

        //<!----- AddressList -> DivisionInfo (GET-ALL) ----->       
        public List<DivisionInfo_DTO> DivisionGetAll(string pb_CountryId)
        {
            List<DivisionInfo_DTO> mappedDivisionInfo = _mapper.Map<List<DivisionInfo_DTO>>(_customerProfileRepository.DivisionGetAll(pb_CountryId)).ToList();

            return mappedDivisionInfo;
        }

        //<!----- AddressList -> DistrictInfo (GET-ALL) ----->       
        public List<DistrictInfo_DTO> DistrictGetAll(string pb_DivisionId)
        {
            List<DistrictInfo_DTO> mappedDistrictInfo = _mapper.Map<List<DistrictInfo_DTO>>(_customerProfileRepository.DistrictGetAll(pb_DivisionId)).ToList();

            return mappedDistrictInfo;
        }

        //<!----- AddressList -> ThanaInfo (GET-ALL) ----->       
        public List<ThanaInfo_DTO> ThanaGetAll(string pb_DistrictId)
        {
            List<ThanaInfo_DTO> mappedThanaInfo = _mapper.Map<List<ThanaInfo_DTO>>(_customerProfileRepository.ThanaGetAll(pb_DistrictId)).ToList();

            return mappedThanaInfo;
        }

    }
}
