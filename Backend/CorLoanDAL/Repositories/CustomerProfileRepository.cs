using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorLoan.DAL.Entities;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using CorLoan.DAL.RepositoryContracts;
using Dapper;



namespace CorLoan.DAL.Repositories
{
    public class CustomerProfileRepository : ICustomerProfileRepository
    {
        private readonly DatabaseContextReadOnly _dbConnection;
        private readonly AppSettings _appSettings;
        private readonly ICoreAuthorizeSaveLogService _coreAuthorizeSaveLogService;

        public CustomerProfileRepository(DatabaseContextReadOnly dbConnection, IOptions<AppSettings> appSettings, ICoreAuthorizeSaveLogService coreAuthorizeSaveLogService)
        {
            _dbConnection = dbConnection;
            _appSettings = appSettings.Value;
            _coreAuthorizeSaveLogService = coreAuthorizeSaveLogService;
        }


        //<!----- CustomerProfile (Post) ----->

        public CustomerProfile CustomerProfilePost(CustomerProfile obj_CustomerProfile, AuthParam authParam)
        {
            using (IDbTransaction transaction = _dbConnection.Db.BeginTransaction())
            {
                try
                {
                    var param = new OracleDynamicParameters();

                    if (obj_CustomerProfile.isAdd)
                    {
                        param.Add("p_Customer_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerName);
                        param.Add("p_Customer_Father_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerFatherName);
                        param.Add("p_Customer_Mother_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerMotherName);
                        param.Add("p_Customer_Gender", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerGender);
                        param.Add("p_Customer_Date_Of_Birth", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerDateOfBirth);
                        param.Add("p_Customer_Marital_Status", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerMaritalStatus);
                        param.Add("p_Customer_Spouse_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerSpouseName);
                        param.Add("p_Customer_NID", OracleDbType.NVarchar2, ParameterDirection.Input, obj_CustomerProfile.CustomerNID);
                        param.Add("p_Make_By", OracleDbType.NVarchar2, ParameterDirection.Input, authParam.UserId);
                        param.Add("p_Customer_ID", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);                       
                        param.Add("p_Error_Code ", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                        param.Add("p_Error_Message", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);

                        string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.CUSTOMER_PROFILE_SA_insert";                             
                        _dbConnection.Db.Query(query, param, commandType: CommandType.StoredProcedure);//.FirstOrDefault();              

                        obj_CustomerProfile.CUSTOMER_ID = param.Get<string>("p_Customer_ID");
                        //to pass obj_CustomerProfile.CUSTOMER_ID to IntroducerInformation and AddressListInformation
                        obj_CustomerProfile.IntroducerInformation.CUSTOMER_ID = obj_CustomerProfile.CUSTOMER_ID;

                        foreach (AddressList obj in obj_CustomerProfile.AddressListInformation)
                        {
                            obj.CUSTOMER_ID = obj_CustomerProfile.CUSTOMER_ID;
                        }

                        obj_CustomerProfile.ERROR_MSG = param.Get<string>("p_Error_Message");

                        if (!string.IsNullOrEmpty(obj_CustomerProfile.ERROR_MSG) && obj_CustomerProfile.ERROR_MSG != "null")
                        {
                            throw new Exception(obj_CustomerProfile.ERROR_MSG);
                        }
                        if (string.IsNullOrEmpty(obj_CustomerProfile.ERROR_MSG) || obj_CustomerProfile.ERROR_MSG == "null")
                        {
                            authParam.Action_Status = Leadsoft_Constants.AddAuthStatus;
                            authParam.Remarks = "CUSTOMER ID : " + obj_CustomerProfile.CUSTOMER_ID;
                            obj_CustomerProfile.IsRequestSuccess = true;

                            
                            //to call the post functions of IntroducerInfo and AddressList
                            IntroducerInfoPost(obj_CustomerProfile.IntroducerInformation, authParam, transaction);
                            AddressListPost(obj_CustomerProfile.AddressListInformation, authParam, transaction);
                        }
                        else
                        {
                            transaction.Rollback();
                            return obj_CustomerProfile;
                        }
                    }
                    else if (obj_CustomerProfile.isOld && obj_CustomerProfile.isDelete)                              
                    {
                        authParam.Action_Status = Leadsoft_Constants.DeleteAuthStatus;
                        authParam.Remarks = "CUSTOMER ID : " + obj_CustomerProfile.CUSTOMER_ID;
                        obj_CustomerProfile.IsRequestSuccess = true;
                    }
                    else
                    {
                        authParam.Action_Status = Leadsoft_Constants.EditAuthStatus;                                
                        authParam.Remarks = "CUSTOMER ID : " + obj_CustomerProfile.CUSTOMER_ID;
                        obj_CustomerProfile.IsRequestSuccess = true;

                        //to call the post functions of IntroducerInfo and AddressList
                        IntroducerInfoPost(obj_CustomerProfile.IntroducerInformation, authParam, transaction);
                        AddressListPost(obj_CustomerProfile.AddressListInformation, authParam, transaction);
                    }

                    var result = _coreAuthorizeSaveLogService.CreateNftAuthLogUsingSP(obj_CustomerProfile, authParam, ((int)ORMType.Dapper).ToString());

                    if (result != null)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }

                    return obj_CustomerProfile;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }


        //<!----- CustomerProfile (GET) ----->

        public CustomerProfile CustomerProfileGet(string CUSTOMER_ID)
        {
            try 
            {
                var param = new OracleDynamicParameters();

                param.Add("p_Customer_ID", OracleDbType.NVarchar2, ParameterDirection.Input, CUSTOMER_ID);
                param.Add("p_Error_Code ", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                param.Add("p_Error_Message", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                param.Add("p_Result_Cur", OracleDbType.RefCursor, ParameterDirection.Output, size: 3200);

                string query1 = _appSettings.SpPrefix + "TEST_PROJECT_SA.CUSTOMER_PROFILE_SA_getByKey";
                var obj_CustomerProfile = _dbConnection.Db.Query<CustomerProfile>(query1, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                string query2 = _appSettings.SpPrefix + "TEST_PROJECT_SA.INTRODUCER_INFO_SA_getByKey";
                obj_CustomerProfile.IntroducerInformation = _dbConnection.Db.Query<IntroducerInfo>(query2, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    
                string query3 = _appSettings.SpPrefix + "TEST_PROJECT_SA.ADDRESS_LIST_SA_getByKey";
                obj_CustomerProfile.AddressListInformation = _dbConnection.Db.Query<AddressList>(query3, param, commandType: CommandType.StoredProcedure).ToList(); 

                if (obj_CustomerProfile != null)
                {                    
                    obj_CustomerProfile.ERROR_MSG = param.Get<string>("p_Result_Cur");
                }

                return obj_CustomerProfile;
            }
            catch (Exception ex) 
            {
                throw ex;
            }      
        }


        //<!----- Customer (GET-ALL) ----->

        public List<CustomerProfile> CustomerGetAll()
        {
            try
            {
                var param = new OracleDynamicParameters();

                param.Add("p_Result_Cur", OracleDbType.RefCursor, ParameterDirection.Output, size: 3200);

                string query1 = _appSettings.SpPrefix + "TEST_PROJECT_SA.CUSTOMER_PROFILE_SA_getAll";
                var obj_CustomerProfile = _dbConnection.Db.Query<CustomerProfile>(query1, param, commandType: CommandType.StoredProcedure).ToList();
                              
                return obj_CustomerProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //<!----- IntroducerInfo (Post) ----->

        public IntroducerInfo IntroducerInfoPost(IntroducerInfo obj_IntroducerInfo, AuthParam authParam, IDbTransaction transaction)
        {
             try
                {
                    var param = new OracleDynamicParameters();

                    if (obj_IntroducerInfo.isAdd)
                    {
                        param.Add("p_Introducer_Type", OracleDbType.NVarchar2, ParameterDirection.Input, obj_IntroducerInfo.IntroducerType); //obj_CustomerProfile.IntroducerInformation
                        param.Add("p_Introducer_Accbranch", OracleDbType.NVarchar2, ParameterDirection.Input, obj_IntroducerInfo.IntroducerAccBranch);
                        param.Add("p_Introducer_Accno", OracleDbType.NVarchar2, ParameterDirection.Input, obj_IntroducerInfo.IntroducerAccNo);
                        param.Add("p_Introducer_Details", OracleDbType.NVarchar2, ParameterDirection.Input, obj_IntroducerInfo.IntroducerDetails);
                        param.Add("p_Customer_ID", OracleDbType.NVarchar2, ParameterDirection.Input, obj_IntroducerInfo.CUSTOMER_ID);                        
                        param.Add("p_Make_By", OracleDbType.NVarchar2, ParameterDirection.Input, authParam.UserId);
                        param.Add("p_Introducer_Id", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                        param.Add("p_Error_Code ", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                        param.Add("p_Error_Message", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);

                        string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.INTRODUCER_INFO_SA_insert";
                        _dbConnection.Db.Query(query, param, commandType: CommandType.StoredProcedure);//.FirstOrDefault();            

                        obj_IntroducerInfo.INTRODUCER_ID = param.Get<string>("p_Introducer_Id");
                        obj_IntroducerInfo.ERROR_MSG = param.Get<string>("p_Error_Message");

                        if (!string.IsNullOrEmpty(obj_IntroducerInfo.ERROR_MSG) && obj_IntroducerInfo.ERROR_MSG != "null")
                        {
                            throw new Exception(obj_IntroducerInfo.ERROR_MSG);
                        }
                        if (string.IsNullOrEmpty(obj_IntroducerInfo.ERROR_MSG) || obj_IntroducerInfo.ERROR_MSG == "null")
                        {
                            authParam.Action_Status = Leadsoft_Constants.AddAuthStatus;
                            authParam.Remarks = "INTRODUCER ID : " + obj_IntroducerInfo.INTRODUCER_ID;
                            obj_IntroducerInfo.IsRequestSuccess = true;
                        }
                        else
                        {
                            transaction.Rollback();
                            return obj_IntroducerInfo;
                        }
                    }
                    else if (obj_IntroducerInfo.isOld && obj_IntroducerInfo.isDelete)
                    {
                        authParam.Action_Status = Leadsoft_Constants.DeleteAuthStatus;
                        authParam.Remarks = "INTRODUCER ID : " + obj_IntroducerInfo.INTRODUCER_ID;
                        obj_IntroducerInfo.IsRequestSuccess = true;
                    }
                    else
                    {
                        authParam.Action_Status = Leadsoft_Constants.EditAuthStatus;                               
                        authParam.Remarks = "INTRODUCER ID : " + obj_IntroducerInfo.INTRODUCER_ID;
                        obj_IntroducerInfo.IsRequestSuccess = true;
                    }

                    var result = _coreAuthorizeSaveLogService.CreateNftAuthLogUsingSP(obj_IntroducerInfo, authParam, ((int)ORMType.Dapper).ToString());

                    return obj_IntroducerInfo;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }           
        }


        //<!----- AddressList (Post) ----->

        public List<AddressList> AddressListPost(List<AddressList> objListAddress, AuthParam authParam, IDbTransaction transaction)
        {
            try
            {
               // var param = new OracleDynamicParameters();

                foreach (AddressList obj_AddressList in objListAddress)
                {
                    var param = new OracleDynamicParameters();

                    if (obj_AddressList.isAdd)
                    {
                        param.Add("p_Address_Type", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.AddressType);
                        param.Add("p_Address", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.Address);
                        param.Add("p_City_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.CityName);
                        param.Add("p_Zip_Code", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.ZipCode);
                        param.Add("p_Country_Id", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.COUNTRY_ID);
                        param.Add("p_Country_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.CountryName);
                        param.Add("p_Division_Id", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.DIVISION_ID);
                        param.Add("p_Division_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.DivisionName);
                        param.Add("p_District_Id", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.DISTRICT_ID);
                        param.Add("p_District_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.DistrictName);
                        param.Add("p_Thana_Id", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.THANA_ID);
                        param.Add("p_Thana_Name", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.ThanaName);
                        param.Add("p_Phone_No", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.PhoneNo);
                        param.Add("p_Mobile_No", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.MobileNo);
                        param.Add("p_Email", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.Email);
                        param.Add("p_Customer_ID", OracleDbType.NVarchar2, ParameterDirection.Input, obj_AddressList.CUSTOMER_ID);

                        param.Add("p_Make_By", OracleDbType.NVarchar2, ParameterDirection.Input, authParam.UserId);
                        param.Add("p_Address_Id", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                        param.Add("p_Error_Code", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);
                        param.Add("p_Error_Message", OracleDbType.NVarchar2, ParameterDirection.Output, size: 32000);


                        string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.ADDRESS_LIST_SA_insert";
                        _dbConnection.Db.Query(query, param, commandType: CommandType.StoredProcedure);//.FirstOrDefault(); 

                        obj_AddressList.ADDRESS_ID = param.Get<string>("p_Address_Id");
                        if(param.Get("p_Error_Message")!=null)
                        {
                            obj_AddressList.ERROR_MSG = param.Get<string>("p_Error_Message").ToString();
                        }
                      
                        if (!string.IsNullOrEmpty(obj_AddressList.ERROR_MSG) && obj_AddressList.ERROR_MSG != "null")
                        {
                            throw new Exception(obj_AddressList.ERROR_MSG);
                        }
                        if (string.IsNullOrEmpty(obj_AddressList.ERROR_MSG) || obj_AddressList.ERROR_MSG == "null")
                        {
                            authParam.Action_Status = Leadsoft_Constants.AddAuthStatus;
                            authParam.Remarks = "ADDRESS ID : " + obj_AddressList.ADDRESS_ID;
                            obj_AddressList.IsRequestSuccess = true;
                        }
                        else
                        {
                            transaction.Rollback();
                           throw new Exception("Db Error: "+ obj_AddressList.ERROR_MSG);
                        }
                    }
                    else if (obj_AddressList.isOld && obj_AddressList.isDelete)
                    {
                        authParam.Action_Status = Leadsoft_Constants.DeleteAuthStatus;
                        authParam.Remarks = "ADDRESS ID : " + obj_AddressList.ADDRESS_ID;
                        obj_AddressList.IsRequestSuccess = true;
                    }
                    else
                    {
                        authParam.Action_Status = Leadsoft_Constants.EditAuthStatus;
                        authParam.Remarks = "ADDRESS ID : " + obj_AddressList.ADDRESS_ID;
                        obj_AddressList.IsRequestSuccess = true;
                    }
                }
                
                var result = _coreAuthorizeSaveLogService.CreateNftAuthLogForListUsingSP(objListAddress, authParam.BranchId, authParam.FunctionId, authParam.Remarks, authParam.Action_Status, authParam.UserId, ((int)ORMType.Dapper).ToString());

                return objListAddress;
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                throw ex;
            }
        }


        //<!----- AddressList -> CountryInfo (GET-ALL) ----->

        public List<CountryInfo> CountryGetAll()
        {
            try
            {
                var param = new OracleDynamicParameters();

                param.Add("presult_set_cur", OracleDbType.RefCursor, ParameterDirection.Output, size: 3200);


                string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.COUNTRY_getAll";
                var obj_CountryInfo = _dbConnection.Db.Query<CountryInfo>(query, param, commandType: CommandType.StoredProcedure).ToList();
               

                return obj_CountryInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //<!----- AddressList -> DivisionInfo (GET-ALL) ----->

        public List <DivisionInfo> DivisionGetAll(string pb_CountryId)
        {
            try
            {
                var param = new OracleDynamicParameters();

                param.Add("p_Country_Id", OracleDbType.NVarchar2, ParameterDirection.Input, pb_CountryId);
                param.Add("presult_set_cur", OracleDbType.RefCursor, ParameterDirection.Output, size: 3200);


                string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.DIVISION_getAll";
                var objList_DivisionInfo = _dbConnection.Db.Query<DivisionInfo>(query, param, commandType: CommandType.StoredProcedure).ToList();


                return objList_DivisionInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //<!----- AddressList -> DistrictInfo (GET-ALL) ----->

        public List<DistrictInfo> DistrictGetAll(string pb_DivisionId)
        {
            try
            {
                var param = new OracleDynamicParameters();

                param.Add("p_Division_Id", OracleDbType.NVarchar2, ParameterDirection.Input, pb_DivisionId);
                param.Add("presult_set_cur", OracleDbType.RefCursor, ParameterDirection.Output, size: 3200);


                string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.DISTRICT_getAll";
                var objList_DistrictInfo = _dbConnection.Db.Query<DistrictInfo>(query, param, commandType: CommandType.StoredProcedure).ToList();


                return objList_DistrictInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //<!----- AddressList -> ThanaInfo (GET-ALL) ----->

        public List<ThanaInfo> ThanaGetAll(string pb_DistrictId)
        {
            try
            {
                var param = new OracleDynamicParameters();

                param.Add("p_District_Id", OracleDbType.NVarchar2, ParameterDirection.Input, pb_DistrictId);
                param.Add("presult_set_cur", OracleDbType.RefCursor, ParameterDirection.Output, size: 3200);


                string query = _appSettings.SpPrefix + "TEST_PROJECT_SA.THANA_getAll";
                var objList_ThanaInfo = _dbConnection.Db.Query<ThanaInfo>(query, param, commandType: CommandType.StoredProcedure).ToList();


                return objList_ThanaInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
    