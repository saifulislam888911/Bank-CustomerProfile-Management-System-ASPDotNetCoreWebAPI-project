CREATE TABLE CUSTOMER_PROFILE_SA(
    CUSTOMER_ID              NVARCHAR2(10),
    CUSTOMER_NAME            NVARCHAR2(20),
    CUSTOMER_FATHER_NAME     NVARCHAR2(20),
    CUSTOMER_MOTHER_NAME     NVARCHAR2(20),
    CUSTOMER_GENDER          NVARCHAR2(10),
    CUSTOMER_DATE_OF_BIRTH   DATE,
    CUSTOMER_MARITAL_STATUS  NVARCHAR2(10),
    CUSTOMER_SPOUSE_NAME     NVARCHAR2(20),
    CUSTOMER_NID             NVARCHAR2(20),
    MAKE_DATE                DATE,
    AUTH_STATUS_ID           NVARCHAR2(20),
    LAST_ACTION              NVARCHAR2(7),
    MAKE_BY                  NVARCHAR2(20),
    CONSTRAINT PK_CUSTOMER_PROFILE_SA PRIMARY KEY (CUSTOMER_ID)
);


SELECT * FROM CUSTOMER_PROFILE_SA;

