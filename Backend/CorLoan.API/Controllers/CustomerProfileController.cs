using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CorLoan.BLL.DTOs;
using CorLoan.BLL.ServiceContracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CorLoan.BLL.Services;


namespace CorLoan.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerProfileController : ControllerBase
    {
        private readonly ICustomerProfileService _customerProfileService;

        public CustomerProfileController(ICustomerProfileService customerProfileService)
        {   
            _customerProfileService = customerProfileService;
        }



        //<!----- CustomerProfile, IntroducerInfo, AddressList (Post) ----->

        [HttpPost]
        public IActionResult CustomerProfilePost(APIServiceRequest objRequest)
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            try
            {
                AuthParam authParam = new AuthParam                                                      
                {
                    UserId = objRequest.UserId,
                    FunctionId = objRequest.FunctionId,
                    BranchId = objRequest.BranchId,
                };

                CustomerProfile_DTO obj_CustomerProfile_DTO = JsonConvert.DeserializeObject<CustomerProfile_DTO>(objRequest.BusinessData.ToString());           
                CustomerProfile_DTO result = _customerProfileService.CustomerProfilePost(obj_CustomerProfile_DTO, authParam);                                   

                if (result.IsRequestSuccess)
                {
                    objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result);
                    return Ok(objResponse);
                }

                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, "");
                return BadRequest(objResponse);
            }
            catch (Exception ex)
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, ex.Message);
                return BadRequest(objResponse);
            }
        }



        //<!----- CustomerProfile, IntroducerInfo, AddressList (GET) ----->

        [HttpGet]
        public IActionResult CustomerProfileGet(string requestString)     
        {
            APIServiceResponse objResponse = new APIServiceResponse();
        
            if(requestString == null) 
            {
                objResponse.ResponseStatus = false;
                objResponse.ResponseMessage = "Request is Null";
                return BadRequest(objResponse);
            }

            APIServiceRequest objRequest = CommonAPIFormat.GetDeserializedRequest(requestString);

            var reqBusinessData = JObject.Parse(objRequest.BusinessData.ToString());
            var result = _customerProfileService.CustomerProfileGet(reqBusinessData.p_Customer_ID.ToString());       

            if (result != null)
                {
                    objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result);
                    return Ok(objResponse);
                }
                else
                {
                    objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest,"");
                    return BadRequest(objResponse); 
                }
        }



        //<!----- Customer (GET - ALL) -----> 

        [HttpPost]
        public IActionResult CustomerGetAll(APIServiceRequest objRequest)
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            var result = _customerProfileService.CustomerGetAll();

            if (result != null)
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result);
                return Ok(objResponse);
            }
            else
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, "");
                return BadRequest(objResponse);
            }
        }



        //<!----- AddressList -> CountryInfo (GET - ALL) ----->      

        [HttpPost]
        public IActionResult CountryGetAll(APIServiceRequest objRequest)
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            var result = _customerProfileService.CountryGetAll();        

            if (result != null)
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result);
                return Ok(objResponse);
            }
            else
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, "");
                return BadRequest(objResponse);
            }
        }



        //<!----- AddressList -> DivisionInfo (GET-ALL) ----->      

        [HttpGet]
        public IActionResult DivisionGetAll(string requestString)
        {
            APIServiceResponse objResponse = new APIServiceResponse();       
            
            APIServiceRequest objRequest = CommonAPIFormat.GetDeserializedRequest(requestString);
            
            var objList = JsonConvert.DeserializeObject(objRequest.BusinessData.ToString());
            var result = _customerProfileService.DivisionGetAll(objList.pb_CountryId.ToString());

            if (result  != null)
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result, "");
                return Ok(objResponse);
            }
            else
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, "");
                return BadRequest(objResponse);
            }
        }



        //<!----- AddressList -> DistrictInfo (GET-ALL)----->

        [HttpGet]
        public IActionResult DistrictGetAll(string requestString)
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            APIServiceRequest objRequest = CommonAPIFormat.GetDeserializedRequest(requestString);


            var objList = JsonConvert.DeserializeObject(objRequest.BusinessData.ToString());
            var result = _customerProfileService.DistrictGetAll(objList.pb_DivisionId.ToString());


            if (result != null)
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result, "");
                return Ok(objResponse);
            }
            else
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, "");
                return BadRequest(objResponse);
            }
        }



        //<!----- AddressList -> ThanaInfo (GET-ALL)----->

        [HttpGet]
        public IActionResult ThanaGetAll(string requestString)
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            APIServiceRequest objRequest = CommonAPIFormat.GetDeserializedRequest(requestString);


            var objList = JsonConvert.DeserializeObject(objRequest.BusinessData.ToString());
            var result = _customerProfileService.ThanaGetAll(objList.pb_DistrictId.ToString());


            if (result != null)
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithBizData(objRequest, result, "");
                return Ok(objResponse);
            }
            else
            {
                objResponse = CommonAPIFormat.CreateAPIResponseWithErrorMsg(objRequest, "");
                return BadRequest(objResponse);
            }
        }

    }
}
