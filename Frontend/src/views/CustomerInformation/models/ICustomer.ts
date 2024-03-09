import type IAddressList from './IAddressList';
import type IIntroducer from './IIntroducer';

export default interface ICustomer {
  CUSTOMER_ID?: string;

  CustomerName?: string;
  CustomerFatherName?: string;
  CustomerMotherName?: string;
  CustomerGender?: string;
  CustomerDateOfBirth?: string;
  CustomerMaritalStatus?: string;
  CustomerSpouseName?: string;
  CustomerNID?: string;

  CloneObj?: {};

  isAdd?: boolean;
  isOld?: boolean;
  isDelete?: boolean;

  IntroducerInformation?: IIntroducer; //Create this obj to inherite IIntroducer
  AddressListInformation?: Array<IAddressList>;
}
