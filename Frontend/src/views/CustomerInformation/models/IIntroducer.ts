export default interface IIntroducer {
  CUSTOMER_ID?: string;
  INTRODUCER_ID?: string;

  IntroducerType?: string;
  IntroducerAccBranch?: string;
  IntroducerAccNo?: string;
  IntroducerDetails?: string;

  CloneObj?: {};

  isAdd?: boolean;
  isOld?: boolean;
  isDelete?: boolean;
}
