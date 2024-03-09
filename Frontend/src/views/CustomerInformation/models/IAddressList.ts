export default interface IAddressList {
  CUSTOMER_ID?: string;
  ADDRESS_ID?: number;

  COUNTRY_ID?: string;
  DIVISION_ID?: string;
  DISTRICT_ID?: string;
  THANA_ID?: string;

  AddressType?: string;
  Address?: string;
  CityName?: string;
  ZipCode?: string;
  CountryName?: string;
  //COUNTRY_NM?: string;
  DivisionName?: string;
  //DIVISION_NM?: string;
  DistrictName?: string;
  // DISTRICT_NM?: string;
  ThanaName?: string;
  //THANA_NM?: string;
  PhoneNo?: string;
  MobileNo?: string;
  Email?: string;

  CloneObj?: {};

  isAdd?: boolean;
  isOld?: boolean;
  isDelete?: boolean;
}
