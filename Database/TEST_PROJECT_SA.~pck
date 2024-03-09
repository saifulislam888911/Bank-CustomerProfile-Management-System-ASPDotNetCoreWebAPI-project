create or replace package TEST_PROJECT_SA is

  -- Author  : SAIFUL_ISLAM
  -- Created : 7/3/2023 4:46:23 PM
  -- Purpose : 
  
  
  
  --============== CUSTOMER_PROFILE_SA  (START) =======================

  -- CUSTOMER_PROFILE_SA (insert)
  
  PROCEDURE CUSTOMER_PROFILE_SA_insert(
    p_Customer_Name            IN CUSTOMER_PROFILE_SA.CUSTOMER_NAME%TYPE,
    p_Customer_Father_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_FATHER_NAME%TYPE,
    p_Customer_Mother_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_MOTHER_NAME%TYPE,
    p_Customer_Gender          IN CUSTOMER_PROFILE_SA.CUSTOMER_GENDER%TYPE,
    p_Customer_Date_Of_Birth   IN CUSTOMER_PROFILE_SA.CUSTOMER_DATE_OF_BIRTH%TYPE,
    p_Customer_Marital_Status  IN CUSTOMER_PROFILE_SA.CUSTOMER_MARITAL_STATUS%TYPE,
    p_Customer_Spouse_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_SPOUSE_NAME%TYPE,
    p_Customer_NID             IN CUSTOMER_PROFILE_SA.CUSTOMER_NID%TYPE,
    p_Make_By                  IN CUSTOMER_PROFILE_SA.MAKE_BY%TYPE,
    p_Customer_ID              OUT CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code               OUT NVARCHAR2,
    p_Error_Message            OUT NVARCHAR2
    );



  -- CUSTOMER_PROFILE_SA (getByKey)
    
  PROCEDURE CUSTOMER_PROFILE_SA_getByKey(
        p_Customer_ID   IN CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
        p_Error_Code    OUT NVARCHAR2,
        p_Error_Message OUT NVARCHAR2,
        p_Result_Cur    OUT SYS_REFCURSOR                      --(what is this?, what's its works?...)
        );
  
  
  
  -- CUSTOMER_PROFILE_SA (getAll)    

  PROCEDURE CUSTOMER_PROFILE_SA_getAll(p_Result_Cur OUT SYS_REFCURSOR);



  -- CUSTOMER_PROFILE_SA (update)

  PROCEDURE CUSTOMER_PROFILE_SA_update(   
    p_Customer_ID              IN CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Customer_Name            IN CUSTOMER_PROFILE_SA.CUSTOMER_NAME%TYPE,
    p_Customer_Father_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_FATHER_NAME%TYPE,
    p_Customer_Mother_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_MOTHER_NAME%TYPE,
    p_Customer_Gender          IN CUSTOMER_PROFILE_SA.CUSTOMER_GENDER%TYPE,
    p_Customer_Date_Of_Birth   IN CUSTOMER_PROFILE_SA.CUSTOMER_DATE_OF_BIRTH%TYPE,
    p_Customer_Marital_Status  IN CUSTOMER_PROFILE_SA.CUSTOMER_MARITAL_STATUS%TYPE,
    p_Customer_Spouse_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_SPOUSE_NAME%TYPE,
    p_Customer_NID             IN CUSTOMER_PROFILE_SA.CUSTOMER_NID%TYPE,
    --p_Make_Date                IN CUSTOMER_PROFILE_SA.MAKE_DATE%TYPE,
    --p_Make_By                  IN CUSTOMER_PROFILE_SA.MAKE_BY%TYPE, 
    --p_Customer_ID              OUT CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code               OUT NVARCHAR2,
    p_Error_Message            OUT NVARCHAR2
    );
    
    
    
  -- CUSTOMER_PROFILE_SA (delete)
  
  PROCEDURE CUSTOMER_PROFILE_SA_delete(
    p_Customer_ID   IN CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2
    );    
    
  --============== CUSTOMER_PROFILE_SA  (END) =======================  
    
  
  
  --============== INTRODUCER_INFO_SA (START) =======================
  
  -- INTRODUCER_INFO_SA (insert)
  
  PROCEDURE INTRODUCER_INFO_SA_insert(
    p_Introducer_Type       IN INTRODUCER_INFO_SA.INTRODUCER_TYPE%TYPE,
    p_Introducer_Accbranch  IN INTRODUCER_INFO_SA.INTRODUCER_ACCBRANCH %TYPE,
    p_Introducer_Accno      IN INTRODUCER_INFO_SA.INTRODUCER_ACCNO%TYPE,
    p_Introducer_Details    IN INTRODUCER_INFO_SA.INTRODUCER_DETAILS%TYPE,
    p_Customer_ID           IN INTRODUCER_INFO_SA.CUSTOMER_ID%TYPE,
    p_Make_By               IN INTRODUCER_INFO_SA.MAKE_BY%TYPE,

    p_Introducer_Id         OUT INTRODUCER_INFO_SA.INTRODUCER_ID%TYPE,
    p_Error_Code            OUT NVARCHAR2,
    p_Error_Message         OUT NVARCHAR2
  );
  
  
  
  -- INTRODUCER_INFO_SA (getByKey)
    
  PROCEDURE INTRODUCER_INFO_SA_getByKey(
    p_Customer_ID   IN INTRODUCER_INFO_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2,
    p_Result_Cur    OUT SYS_REFCURSOR                      
  );

  --============== INTRODUCER_INFO_SA (END) =======================
  
  
  
  
  
  --============== ADDRESS_LIST_SA (START) =======================
  
  -- ADDRESS_LIST_SA (insert)
  
  PROCEDURE ADDRESS_LIST_SA_insert(
    p_Address_Type    IN ADDRESS_LIST_SA.ADDRESS_TYPE%TYPE,
    p_Address         IN ADDRESS_LIST_SA.ADDRESS%TYPE,
    p_City_Name       IN ADDRESS_LIST_SA.CITY_NAME%TYPE,
    p_Zip_Code        IN ADDRESS_LIST_SA.ZIP_CODE%TYPE,

    p_Country_Id      IN ADDRESS_LIST_SA.COUNTRY_ID%TYPE,
    p_Country_Name    IN ADDRESS_LIST_SA.COUNTRY_NAME%TYPE,
    p_Division_Id     IN ADDRESS_LIST_SA.DIVISION_ID%TYPE,
    p_Division_Name   IN ADDRESS_LIST_SA.DIVISION_NAME%TYPE,
    p_District_Id     IN ADDRESS_LIST_SA.DISTRICT_ID%TYPE,
    p_District_Name   IN ADDRESS_LIST_SA.DISTRICT_NAME%TYPE,
    p_Thana_Id        IN ADDRESS_LIST_SA.THANA_ID%TYPE,
    p_Thana_Name      IN ADDRESS_LIST_SA.THANA_NAME%TYPE,

    p_Phone_No        IN ADDRESS_LIST_SA.PHONE_NO%TYPE,
    p_Mobile_No       IN ADDRESS_LIST_SA.MOBILE_NO%TYPE,
    p_Email           IN ADDRESS_LIST_SA.EMAIL%TYPE,

    p_Customer_ID     IN ADDRESS_LIST_SA.CUSTOMER_ID%TYPE,
    p_Make_By         IN ADDRESS_LIST_SA.MAKE_BY%TYPE,

    p_Address_Id      OUT ADDRESS_LIST_SA.ADDRESS_ID%TYPE,
    p_Error_Code      OUT NVARCHAR2,
    p_Error_Message   OUT NVARCHAR2
  );
  
  
  
  -- ADDRESS_LIST_SA (getByKey)
    
  PROCEDURE ADDRESS_LIST_SA_getByKey(
    p_Customer_ID   IN ADDRESS_LIST_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2,
    p_Result_Cur    OUT SYS_REFCURSOR                      
  ); 
  
  
  
  --(country)

  PROCEDURE COUNTRY_getAll(
    presult_set_cur OUT SYS_REFCURSOR
  );



  --(division)

  PROCEDURE DIVISION_getAll(
    p_Country_Id     IN NVARCHAR2,
    presult_set_cur  OUT SYS_REFCURSOR
  );



  --(district)

  PROCEDURE DISTRICT_getAll( 
    p_Division_Id   IN NVARCHAR2,
    presult_set_cur OUT SYS_REFCURSOR
  );



  --(thana)

  PROCEDURE THANA_getAll(
    p_District_Id    IN NVARCHAR2,
    presult_set_cur  OUT SYS_REFCURSOR
  );
  
  --============== ADDRESS_LIST_SA (END) =======================  

end TEST_PROJECT_SA;
/
create or replace package body TEST_PROJECT_SA is



 --== Table : CUSTOMER_PROFILE_SA -- (start) ==--

  --==============CUSTOMER_PROFILE_SA --(insert)--(START)=======================

  --CUSTOMER_PROFILE_SA_insert

  PROCEDURE CUSTOMER_PROFILE_SA_insert(
    p_Customer_Name            IN CUSTOMER_PROFILE_SA.CUSTOMER_NAME%TYPE,
    p_Customer_Father_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_FATHER_NAME%TYPE,
    p_Customer_Mother_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_MOTHER_NAME%TYPE,
    p_Customer_Gender          IN CUSTOMER_PROFILE_SA.CUSTOMER_GENDER%TYPE,
    p_Customer_Date_Of_Birth   IN CUSTOMER_PROFILE_SA.CUSTOMER_DATE_OF_BIRTH%TYPE,
    p_Customer_Marital_Status  IN CUSTOMER_PROFILE_SA.CUSTOMER_MARITAL_STATUS%TYPE,
    p_Customer_Spouse_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_SPOUSE_NAME%TYPE,
    p_Customer_NID             IN CUSTOMER_PROFILE_SA.CUSTOMER_NID%TYPE,
    p_Make_By                  IN CUSTOMER_PROFILE_SA.MAKE_BY%TYPE,
    p_Customer_ID              OUT CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code               OUT NVARCHAR2,
    p_Error_Message            OUT NVARCHAR2
    )IS

 -- v_Customer_ID NVARCHAR2(10);        
    
 -- BEGIN
  --  SELECT lpad(nvl(max(to_number(Cust.CUSTOMER_ID)), 0) + 1, 10, '0')
   -- INTO v_Customer_ID
   -- FROM CUSTOMER_PROFILE_SA Cust;
    
  BEGIN    
    SELECT lpad(nvl(max(to_number(Cust.CUSTOMER_ID)), 0) + 1, 10, '0')
    INTO p_Customer_ID
    FROM CUSTOMER_PROFILE_SA Cust;

  INSERT INTO CUSTOMER_PROFILE_SA
    ( CUSTOMER_ID,
      CUSTOMER_NAME,
      CUSTOMER_FATHER_NAME,
      CUSTOMER_MOTHER_NAME,
      CUSTOMER_GENDER,
      CUSTOMER_DATE_OF_BIRTH,
      CUSTOMER_MARITAL_STATUS,
      CUSTOMER_SPOUSE_NAME,
      CUSTOMER_NID,
      MAKE_DATE,
      MAKE_BY,
      AUTH_STATUS_ID,
      LAST_ACTION
    )
    VALUES
    ( --v_Customer_ID,
      p_Customer_ID,
      p_Customer_Name,
      p_Customer_Father_Name,
      p_Customer_Mother_Name,
      p_Customer_Gender,
      p_Customer_Date_Of_Birth,
      p_Customer_Marital_Status,
      p_Customer_Spouse_Name,
      p_Customer_NID,
      SYSDATE,
      p_Make_By,               
      'U',                   
      'ADD'                 
    );

  /* Assign Values for Output Parameters */
    --p_Customer_ID := v_Customer_ID;
  
     -- SELECT a.rowid
    --  INTO prow_id
    --  FROM cor_lon_proposal_reg a
    --  WHERE a.proposal_id = pproposal_id;
   
   --select t.Customer_ID
   --into v_Customer_ID                                         
   --from CUSTOMER_PROFILE_SA t
   --where t.Customer_ID = p_Customer_ID;
   

  EXCEPTION
    WHEN OTHERS THEN
    p_Error_Code    := SQLCODE;
    p_Error_Message := SQLERRM;

  END CUSTOMER_PROFILE_SA_insert;

  --==============CUSTOMER_PROFILE_SA --(insert)--(END)=======================
  
  
  
  --==============CUSTOMER_PROFILE_SA --(getByKey)--(START)=======================

  --CUSTOMER_PROFILE_SA_getByKey
  
  PROCEDURE CUSTOMER_PROFILE_SA_getByKey(
    p_Customer_ID   IN CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2,
    p_Result_Cur    OUT SYS_REFCURSOR                     
    ) IS

  BEGIN
    OPEN p_Result_Cur FOR                                 
      select t.CUSTOMER_ID,
             t.CUSTOMER_NAME,
             t.CUSTOMER_FATHER_NAME,
             t.CUSTOMER_MOTHER_NAME,
             t.CUSTOMER_GENDER,
             case
               when t.CUSTOMER_GENDER = '1' then
                'Male'
               when t.CUSTOMER_GENDER = '2' then
                'Female'
               when t.CUSTOMER_GENDER = '3' then
                'Others'
             end CUSTOMER_GENDER,                         
             t.CUSTOMER_DATE_OF_BIRTH,
             t.CUSTOMER_MARITAL_STATUS,
             case
               when t.CUSTOMER_MARITAL_STATUS = '1' then
                'Married'
               when t.CUSTOMER_MARITAL_STATUS = '2' then
                'Unmarried'
               when t.CUSTOMER_MARITAL_STATUS = '3' then
                'Others'
             end CUSTOMER_MARITAL_STATUS,                 
             t.CUSTOMER_SPOUSE_NAME,
             t.CUSTOMER_NID
            /* t.MAKE_DATE,
             t.MAKE_BY,
             t.AUTH_STATUS_ID,
             t.LAST_ACTION,
              */
        from CUSTOMER_PROFILE_SA t
       where t.CUSTOMER_ID = p_Customer_ID;

    EXCEPTION
      WHEN OTHERS THEN
        p_Error_Code    := SQLCODE;
        p_Error_Message := SQLERRM;
        
  END CUSTOMER_PROFILE_SA_getByKey;
  
  --==============CUSTOMER_PROFILE_SA --(getByKey)--(END)=======================
  
  
  
  --==============CUSTOMER_PROFILE_SA --(getAll)--(START)=======================

  --CUSTOMER_PROFILE_SA_getAll
  
  PROCEDURE CUSTOMER_PROFILE_SA_getAll(p_Result_Cur OUT SYS_REFCURSOR) IS

    BEGIN
      OPEN p_Result_Cur FOR
        select t.CUSTOMER_ID,
               t.CUSTOMER_NAME,
               t.CUSTOMER_FATHER_NAME,
               t.CUSTOMER_MOTHER_NAME,
               t.CUSTOMER_GENDER,
               case
                 when t.CUSTOMER_GENDER = '1' then
                  'Male'
                 when t.CUSTOMER_GENDER = '2' then
                  'Female'
                 when t.CUSTOMER_GENDER = '3' then
                  'Others'
               end CUSTOMER_GENDER,                           
               t.CUSTOMER_DATE_OF_BIRTH,
               t.CUSTOMER_MARITAL_STATUS,
               case
                 when t.CUSTOMER_MARITAL_STATUS = '1' then
                  'Married'
                 when t.CUSTOMER_MARITAL_STATUS = '2' then
                  'Unmarried'
                 when t.CUSTOMER_MARITAL_STATUS = '2' then
                  'Others'
               end CUSTOMER_MARITAL_STATUS,                    
               t.CUSTOMER_SPOUSE_NAME,
               t.CUSTOMER_NID
               /*t.MAKE_DATE,
               t.MAKE_BY,
               t.AUTH_STATUS_ID,
               t.LAST_ACTION
               */
          from CUSTOMER_PROFILE_SA t;
          
    --EXCEPTION
      --WHEN OTHERS THEN
        --p_Error_Code    := SQLCODE;
        --p_Error_Message := SQLERRM;  
            
    END CUSTOMER_PROFILE_SA_getAll;
    
  --==============CUSTOMER_PROFILE_SA --(getAll)--(END)=======================  
  
  
    
  --==============CUSTOMER_PROFILE_SA --(update)--(START)=======================

  --CUSTOMER_PROFILE_SA_update
  
  PROCEDURE CUSTOMER_PROFILE_SA_update(   
    p_Customer_ID              IN CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Customer_Name            IN CUSTOMER_PROFILE_SA.CUSTOMER_NAME%TYPE,
    p_Customer_Father_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_FATHER_NAME%TYPE,
    p_Customer_Mother_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_MOTHER_NAME%TYPE,
    p_Customer_Gender          IN CUSTOMER_PROFILE_SA.CUSTOMER_GENDER%TYPE,
    p_Customer_Date_Of_Birth   IN CUSTOMER_PROFILE_SA.CUSTOMER_DATE_OF_BIRTH%TYPE,
    p_Customer_Marital_Status  IN CUSTOMER_PROFILE_SA.CUSTOMER_MARITAL_STATUS%TYPE,
    p_Customer_Spouse_Name     IN CUSTOMER_PROFILE_SA.CUSTOMER_SPOUSE_NAME%TYPE,
    p_Customer_NID             IN CUSTOMER_PROFILE_SA.CUSTOMER_NID%TYPE,
    --p_Make_Date                IN CUSTOMER_PROFILE_SA.MAKE_DATE%TYPE,
    --p_Make_By                  IN CUSTOMER_PROFILE_SA.MAKE_BY%TYPE, 
    --p_Customer_ID              OUT CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code               OUT NVARCHAR2,
    p_Error_Message            OUT NVARCHAR2
    ) IS


    BEGIN
      UPDATE CUSTOMER_PROFILE_SA
         SET CUSTOMER_NAME           = p_CUSTOMER_NAME,
             CUSTOMER_FATHER_NAME    = p_CUSTOMER_FATHER_NAME,
             CUSTOMER_MOTHER_NAME    = p_CUSTOMER_MOTHER_NAME,
             CUSTOMER_GENDER         = p_CUSTOMER_GENDER,
             CUSTOMER_DATE_OF_BIRTH  = p_CUSTOMER_DATE_OF_BIRTH,
             CUSTOMER_MARITAL_STATUS = p_CUSTOMER_MARITAL_STATUS,
             CUSTOMER_SPOUSE_NAME    = p_CUSTOMER_SPOUSE_NAME,
             CUSTOMER_NID            = p_CUSTOMER_NID,
             MAKE_DATE               = SYSDATE
       WHERE CUSTOMER_ID             = p_Customer_ID;

    EXCEPTION
      WHEN OTHERS THEN
        p_Error_Code    := SQLCODE;
        p_Error_Message := SQLERRM;

    END CUSTOMER_PROFILE_SA_update;

  --==============CUSTOMER_PROFILE_SA --(update)--(END)=======================



  --==============CUSTOMER_PROFILE_SA --(delete)--(START)=======================

  --CUSTOMER_PROFILE_SA_delete

  PROCEDURE CUSTOMER_PROFILE_SA_delete(
    p_Customer_ID   IN CUSTOMER_PROFILE_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2
    ) IS
    
     
    d_Customer_ID NVARCHAR2(10) := NULL;                           --(what is this?, what's its works?...)
    
    
    BEGIN
      select t.Customer_ID
        into d_Customer_ID                                         --(what is this?, what's its works?...)
        from CUSTOMER_PROFILE_SA t
       where t.Customer_ID = p_Customer_ID;

      if (d_Customer_ID is not null) then
        delete from CUSTOMER_PROFILE_SA t where t.Customer_ID = d_Customer_ID;
      end if;

    EXCEPTION
      WHEN no_data_found THEN
        p_Error_Code    := SQLCODE;
        p_Error_Message := SQLERRM;

      WHEN OTHERS THEN
        p_Error_Code    := SQLCODE;
        p_Error_Message := SQLERRM;
    END CUSTOMER_PROFILE_SA_delete;
  
  --==============CUSTOMER_PROFILE_SA --(delete)--(END)=======================
    
 --== Table : CUSTOMER_PROFILE_SA -- (end) ==--
 
 
 
 
 
--== Table : INTRODUCER_INFO_SA -- (start) ==--
 
  --==============INTRODUCER_INFO_SA --(insert)--(START)=======================

  --INTRODUCER_INFO_SA_insert 
  
  PROCEDURE INTRODUCER_INFO_SA_insert(
    p_Introducer_Type       IN INTRODUCER_INFO_SA.INTRODUCER_TYPE%TYPE,
    p_Introducer_Accbranch  IN INTRODUCER_INFO_SA.INTRODUCER_ACCBRANCH %TYPE,
    p_Introducer_Accno      IN INTRODUCER_INFO_SA.INTRODUCER_ACCNO%TYPE,
    p_Introducer_Details    IN INTRODUCER_INFO_SA.INTRODUCER_DETAILS%TYPE,
    p_Customer_ID           IN INTRODUCER_INFO_SA.CUSTOMER_ID%TYPE,
    p_Make_By               IN INTRODUCER_INFO_SA.MAKE_BY%TYPE,

    p_Introducer_Id         OUT INTRODUCER_INFO_SA.INTRODUCER_ID%TYPE,
    p_Error_Code            OUT NVARCHAR2,
    p_Error_Message         OUT NVARCHAR2
    )IS
  
  BEGIN
    SELECT lpad(nvl(max(to_number(Introd.INTRODUCER_ID)), 0) + 1, 10, '0')
    INTO p_Introducer_Id
    FROM INTRODUCER_INFO_SA Introd;
    
    --SELECT lpad(nvl(max(to_number(Introd.CUSTOMER_ID)), 0) + 1, 10, '0')
    --INTO p_Customer_ID
    --FROM INTRODUCER_INFO_SA Introd;

  INSERT INTO INTRODUCER_INFO_SA(
    INTRODUCER_ID,
    INTRODUCER_TYPE,
    INTRODUCER_ACCBRANCH,
    INTRODUCER_ACCNO,
    INTRODUCER_DETAILS,
    CUSTOMER_ID,

    AUTH_STATUS_ID,
    MAKE_BY,                  
    MAKE_DATE ,  
    LAST_ACTION 
    )
  VALUES(
    p_Introducer_Id, 
    p_Introducer_Type,
    p_Introducer_Accbranch,
    p_Introducer_Accno,
    p_Introducer_Details,
    p_Customer_ID,
    
    'U',
    p_Make_By,
    SYSDATE,
    'ADD'
    );

  EXCEPTION
    WHEN OTHERS THEN
      p_Error_Code    := SQLCODE;
      p_Error_Message := SQLERRM;

  END INTRODUCER_INFO_SA_insert;
  
  --==============INTRODUCER_INFO_SA --(insert)--(END)=======================
  
  
  
  --==============INTRODUCER_INFO_SA --(getByKey)--(START)=======================
  
  --INTRODUCER_INFO_SA_getByKey
  
  PROCEDURE INTRODUCER_INFO_SA_getByKey(
    p_Customer_ID   IN INTRODUCER_INFO_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2,
    p_Result_Cur    OUT SYS_REFCURSOR                      
  )IS


  BEGIN
    OPEN p_Result_Cur FOR
      select t.INTRODUCER_ID,
             t.INTRODUCER_TYPE,
               case
                  when t.INTRODUCER_TYPE = '1' then 
                  'Account Holder'
                  when t.INTRODUCER_TYPE = '2' then
                  'Officer'                    
               end INTRODUCER_TYPE,
             
             t.INTRODUCER_ACCBRANCH,
             t.INTRODUCER_ACCNO,
             t.INTRODUCER_DETAILS

            /* t.AUTH_STATUS_ID,
               t.MAKE_BY,                  
               t.MAKE_DATE ,  
               t.LAST_ACTION
            */
      from INTRODUCER_INFO_SA t
      where t.CUSTOMER_ID = p_Customer_ID;

    EXCEPTION
      WHEN OTHERS THEN
        p_Error_Code    := SQLCODE;
        p_Error_Message := SQLERRM;

  END INTRODUCER_INFO_SA_getByKey;

  
  --==============INTRODUCER_INFO_SA --(getByKey)--(END)=======================
  
--== Table : INTRODUCER_INFO_SA -- (end) ==--





--== Table : ADDRESS_LIST_SA -- (start) ==--
 
  --==============ADDRESS_LIST_SA --(insert)--(START)=======================

  --ADDRESS_LIST_SA_insert
  
  PROCEDURE ADDRESS_LIST_SA_insert(
    p_Address_Type    IN ADDRESS_LIST_SA.ADDRESS_TYPE%TYPE,
    p_Address         IN ADDRESS_LIST_SA.ADDRESS%TYPE,
    p_City_Name       IN ADDRESS_LIST_SA.CITY_NAME%TYPE,
    p_Zip_Code        IN ADDRESS_LIST_SA.ZIP_CODE%TYPE,

    p_Country_Id      IN ADDRESS_LIST_SA.COUNTRY_ID%TYPE,
    p_Country_Name    IN ADDRESS_LIST_SA.COUNTRY_NAME%TYPE,
    p_Division_Id     IN ADDRESS_LIST_SA.DIVISION_ID%TYPE,
    p_Division_Name   IN ADDRESS_LIST_SA.DIVISION_NAME%TYPE,
    p_District_Id     IN ADDRESS_LIST_SA.DISTRICT_ID%TYPE,
    p_District_Name   IN ADDRESS_LIST_SA.DISTRICT_NAME%TYPE,
    p_Thana_Id        IN ADDRESS_LIST_SA.THANA_ID%TYPE,
    p_Thana_Name      IN ADDRESS_LIST_SA.THANA_NAME%TYPE,

    p_Phone_No        IN ADDRESS_LIST_SA.PHONE_NO%TYPE,
    p_Mobile_No       IN ADDRESS_LIST_SA.MOBILE_NO%TYPE,
    p_Email           IN ADDRESS_LIST_SA.EMAIL%TYPE,

    p_Customer_ID     IN ADDRESS_LIST_SA.CUSTOMER_ID%TYPE,
    p_Make_By         IN ADDRESS_LIST_SA.MAKE_BY%TYPE,

    p_Address_Id      OUT ADDRESS_LIST_SA.ADDRESS_ID%TYPE,
    p_Error_Code      OUT NVARCHAR2,
    p_Error_Message   OUT NVARCHAR2
  )IS
  
  BEGIN
    SELECT lpad(nvl(max(to_number(adrs.ADDRESS_ID)), 0) + 1, 10, '0')
    INTO p_Address_Id
    FROM ADDRESS_LIST_SA adrs;

  INSERT INTO ADDRESS_LIST_SA (
    ADDRESS_ID,
    ADDRESS_TYPE, 
    ADDRESS,
    CITY_NAME,
    ZIP_CODE,

    COUNTRY_ID,
    COUNTRY_NAME,
    DIVISION_ID,
    DIVISION_NAME,
    DISTRICT_ID,
    DISTRICT_NAME,
    THANA_ID,
    THANA_NAME,

    PHONE_NO,
    MOBILE_NO, 
    EMAIL,
    CUSTOMER_ID,

    AUTH_STATUS_ID,
    MAKE_BY,                  
    MAKE_DATE,  
    LAST_ACTION 
  )
  VALUES(
    p_Address_Id,
    p_Address_Type, 
    p_Address,
    p_City_Name,
    p_Zip_Code,

    p_Country_Id,
    p_Country_Name,
    p_Division_Id,
    p_Division_Name,
    p_District_Id,
    p_District_Name,
    p_Thana_Id,
    p_Thana_Name,

    p_Phone_No,
    p_Mobile_No, 
    p_Email,
    p_Customer_ID,

    'U',
    p_Make_By,
    SYSDATE,
    'ADD'
  );

  EXCEPTION
    WHEN OTHERS THEN
      p_Error_Code    := SQLCODE;
      p_Error_Message := SQLERRM;

  END ADDRESS_LIST_SA_insert;

  --==============ADDRESS_LIST_SA --(insert)--(END)=======================
  
  
  
  --==============ADDRESS_LIST_SA --(getByKey)--(START)=======================

  --ADDRESS_LIST_SA_getByKey  
    
  PROCEDURE ADDRESS_LIST_SA_getByKey(
    p_Customer_ID   IN ADDRESS_LIST_SA.CUSTOMER_ID%TYPE,
    p_Error_Code    OUT NVARCHAR2,
    p_Error_Message OUT NVARCHAR2,
    p_Result_Cur    OUT SYS_REFCURSOR                      
  )IS
  
  BEGIN
    OPEN p_Result_Cur FOR
      select t.ADDRESS_ID,            
            t.ADDRESS_TYPE, 
              case
                when t.ADDRESS_TYPE = '1' then 
                 'Present'
                when t.ADDRESS_TYPE = '2' then
                 'Permanent'
            end ADDRESS_TYPE,

            t.ADDRESS,
            t.CITY_NAME,
            t.ZIP_CODE,

            t.COUNTRY_ID,
            t.COUNTRY_NAME,
            t.DIVISION_ID,
            t.DIVISION_NAME,
            t.DISTRICT_ID,
            t.DISTRICT_NAME,
            t.THANA_ID,
            t.THANA_NAME,

            t.PHONE_NO,
            t.MOBILE_NO, 
            t.EMAIL,
            t.CUSTOMER_ID
            /*
            t.AUTH_STATUS_ID,
            t.MAKE_BY,                  
            t.MAKE_DATE,  
            t.LAST_ACTION 
            */
      from ADDRESS_LIST_SA t
      where t.CUSTOMER_ID = p_Customer_ID;

  EXCEPTION
    WHEN OTHERS THEN
     p_Error_Code    := SQLCODE;
     p_Error_Message := SQLERRM;

  END ADDRESS_LIST_SA_getByKey;
     
  
  --==============ADDRESS_LIST_SA --(getByKey)--(END)=======================

  --(country)

  PROCEDURE COUNTRY_getAll(
    presult_set_cur OUT SYS_REFCURSOR
  )IS

    BEGIN
      OPEN presult_set_cur FOR
        SELECT a.country_id, a.country_nm
          FROM country a
         WHERE a.auth_status_id = 'A'
           AND a.nationality_nm IS NOT NULL
         ORDER BY a.nationality_nm;

    END COUNTRY_getAll;



  --(division)

  PROCEDURE DIVISION_getAll(
    p_Country_Id     IN NVARCHAR2,
    presult_set_cur  OUT SYS_REFCURSOR
  )IS

    BEGIN
      OPEN presult_set_cur FOR
        SELECT a.division_id, a.division_nm, a.country_id, b.country_nm
          FROM division a, country b
         WHERE a.auth_status_id = 'A'
           AND a.country_id = b.country_id
           AND a.country_id = p_Country_Id
         ORDER BY a.division_nm;

    END DIVISION_getAll;



  --(district)

  PROCEDURE DISTRICT_getAll( 
    p_Division_Id   IN NVARCHAR2,
    presult_set_cur OUT SYS_REFCURSOR
  )IS

    BEGIN
      --(For Specific Division)
      OPEN presult_set_cur FOR
        SELECT a.district_id, a.district_nm
          FROM district a
         WHERE a.auth_status_id = 'A'
           AND a.division_id = p_Division_Id
         ORDER BY a.district_nm;

    END DISTRICT_getAll;



  --(thana)

  PROCEDURE THANA_getAll(
    p_District_Id   IN NVARCHAR2,
    presult_set_cur OUT SYS_REFCURSOR
  )IS

    BEGIN
      OPEN presult_set_cur FOR
        SELECT a.thana_id, a.thana_nm
          FROM thana a
         WHERE a.auth_status_id = 'A'
           AND a.district_id = p_District_Id
         ORDER BY a.thana_nm;

    END THANA_getAll;

    
--== Table : ADDRESS_LIST_SA -- (end) ==--   
    
end TEST_PROJECT_SA;
/
