//import type BindComboInfo from '../../../../src/commonModels/BindComboInfo';
import mixin from '@/mixins/APIHandlingMixin';
import { ref } from 'vue';
import CommonService from '@/mixins/CommonService';
import store from '@/store';
import { toast } from 'vue3-toastify';

//const apiUrl=store.state.apiUrlPath;
const apiUrl = JSON.parse(sessionStorage.getItem('apiUrlPath') as any);
const currFunctionNm = 'BEFT Update Inward Account';

//<!----- sa w (start)----->

//<!----- CustomerProfile(Post)----->
//for Saving CustomerProfile , IntroducerInfo , AddressList
const SaveCustomerInformation = async (customerData) => {
  const resData = await mixin.$postApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/CustomerProfilePost', customerData);

  if (resData) {
    return resData;
  }
};

//<!----- CustomerProfile(Get)----->
const GetCustomerInformation = async (CUSTOMER_ID) => {
  const businessData = {
    p_Customer_ID: CUSTOMER_ID
  };

  const resData = await mixin.$getApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/CustomerProfileGet', businessData);

  if (resData) {
    return resData;
  }
};

//<!----- All Customer Info(Get-All)----->
const GetAllCustomer = async () => {
  const businessData = {};

  const resData = await mixin.$postApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/CustomerGetAll', businessData);

  if (resData) {
    return resData;
  }
};

//<!----- Country(GetAll)----->
const GetAllCountryInfo = async () => {
  const businessData = {};

  const resData = await mixin.$postApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/CountryGetAll', businessData);

  if (resData) {
    return resData;
  }
};

//<!----- Division(GetAll)----->
const GetAllDivisionInfo = async (pf_CountryId) => {
  const businessData = {
    pb_CountryId: pf_CountryId //(1stOne is going to backend : 2ndOne is come from FrontEnd )
  };

  const resData = await mixin.$getApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/DivisionGetAll', businessData);

  if (resData) {
    return resData;
  }
};

//<!----- District(GetAll)----->
const GetAllDistrictInfo = async (pf_DivisionId) => {
  const businessData = {
    pb_DivisionId: pf_DivisionId
  };

  const resData = await mixin.$getApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/DistrictGetAll', businessData);

  if (resData) {
    return resData;
  }
};

//<!----- Thana(GetAll)----->
const GetAllThanaInfo = async (pf_DistrictId) => {
  const businessData = {
    pb_DistrictId: pf_DistrictId
  };

  const resData = await mixin.$getApiCall(currFunctionNm, apiUrl.CoreLoanApiPath, 'CustomerProfile/ThanaGetAll', businessData);

  if (resData) {
    return resData;
  }
};

//<!----- sa w (end)----->

export default {
  SaveCustomerInformation,
  GetCustomerInformation,
  GetAllCustomer,
  GetAllCountryInfo,
  GetAllDivisionInfo,
  GetAllDistrictInfo,
  GetAllThanaInfo
};
