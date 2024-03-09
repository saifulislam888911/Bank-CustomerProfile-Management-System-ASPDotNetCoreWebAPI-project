<template>
  <v-card outlined>
    <BaseHeader
      :title="'CUSTOMER'"
      :is-four-button="true"
      :button1="'OK'"
      :button2="'View'"
      :button3="'Refresh'"
      :button4="'Exit'"
      @onSubmitFromChildren="saveCustomerInfo()"
      @onViewFromChildren="onView"
      @onRefreshFromChildren="OnRefresh"
      @onExitFromChildren="onExit"
    />

    <!-- Body : Cards Section (START)  -->

    <!-- Card No. 1 (START)  -->
    <v-card outlined>
      <v-card-text>
        <v-form v-model="isFormValid" ref="validform" lazy-validation @onSubmitFromChildren.prevent>
          <v-card-title class="sa-card-title">Customer Profile Details</v-card-title>

          <v-row class="border solid">
            <v-col cols="12" md="4">
              <v-text-field
                label="Customer ID"
                placeholder="[Auto]"
                v-model="dataCustomer.CUSTOMER_ID"
                @blur="getCustomerById()"
                v-on:keypress="[rules.isDigit($event)]"
                :rules="[rules.LengthRulesLessEq('Customer ID', 10)]"
                :readonly="(customerIdReadOnly = false)"
              >
                <v-tooltip class="tooltipStyle" activator="parent" location="right">[Auto]</v-tooltip>
              </v-text-field>
            </v-col>
          </v-row>

          <v-row class="border solid">
            <v-col cols="12" md="6">
              <v-text-field
                label="Customer Name"
                v-model="dataCustomer.CustomerName"
                v-on:keypress="[rules.isLetter($event)]"
                :rules="[rules.required, rules.LengthRulesLessEq('Customer Name', 20)]"
                v-on:click="customerIdReadOnly"
              >
              </v-text-field>
            </v-col>

            <v-col cols="12" md="6">
              <v-text-field
                label="Father Name"
                v-model="dataCustomer.CustomerFatherName"
                v-on:keypress="[rules.isLetter($event)]"
                :rules="[rules.required, rules.LengthRulesLessEq('Father Name', 20)]"
              >
              </v-text-field>
            </v-col>
          </v-row>

          <v-row class="border solid">
            <v-col cols="12" md="6">
              <v-text-field
                label="Mother Name"
                v-model="dataCustomer.CustomerMotherName"
                v-on:keypress="[rules.isLetter($event)]"
                :rules="[rules.required, rules.LengthRulesLessEq('Mother Name', 20)]"
              >
              </v-text-field>
            </v-col>

            <v-col cols="12" md="2">
              <v-select label="Gender" v-model="dataCustomer.CustomerGender" :items="sGender" :rules="[rules.required]"> </v-select>
            </v-col>

            <v-col cols="12" md="2">
              <v-text-field label="Date Of Birth" v-model="dataCustomer.CustomerDateOfBirth" type="date" :rules="[rules.required]">
              </v-text-field>
            </v-col>

            <v-col cols="12" md="2">
              <v-select
                label="Marital Status"
                v-model="dataCustomer.CustomerMaritalStatus"
                :items="sMaritalStatus"
                :rules="[rules.required]"
              >
              </v-select>
            </v-col>
          </v-row>

          <v-row class="border solid">
            <v-col cols="12" md="6">
              <v-text-field
                label="Spouse Name"
                v-model="dataCustomer.CustomerSpouseName"
                :disabled="spouseNmDisable"
                :rules="[rules.LengthRulesLessEq('Spouse Name', 20)]"
              >
              </v-text-field>
            </v-col>

            <v-col cols="12" md="6">
              <v-text-field
                label="Customer NID"
                v-model="dataCustomer.CustomerNID"
                v-on:keypress="[rules.isDigit($event)]"
                :rules="[rules.required, rules.LengthRulesLessEq('Customer NID', 17)]"
              >
              </v-text-field>
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
    </v-card>
    <!-- Card No. 1 (END)  -->

    <!-- Tab-Window No. 1 (START)  -->
    <v-card outlined>
      <v-tabs v-model="tab" class="sa-card-tabs-titlebar">
        <v-tab value="Tab1">Introducer Information</v-tab>
        <v-tab value="Tab2">Address List</v-tab>
      </v-tabs>

      <v-card-text>
        <v-window v-model="tab">
          <!-- Window-item No. 1 (START)  -->
          <v-window-item value="Tab1">
            <!-- Card No. 2 (START)  -->
            <v-card outlined>
              <v-card-text>
                <v-form v-model="isFormValid" ref="validform" lazy-validation>
                  <v-card-title>Introducer Information</v-card-title>
                  <v-row class="border solid">
                    <v-col cols="12" md="4">
                      <v-select
                        label="Introducer Type"
                        v-model="dataIntroducer.IntroducerType"
                        :items="sIntroducerType"
                        :rules="[rules.required]"
                      >
                      </v-select>
                    </v-col>

                    <v-col cols="12" md="4">
                      <v-text-field
                        label="Introducer Acc Branch"
                        v-model="dataIntroducer.IntroducerAccBranch"
                        :rules="[rules.required, rules.LengthRulesLessEq('Introducer Acc Branch', 15)]"
                      >
                      </v-text-field>
                    </v-col>

                    <v-col cols="12" md="4">
                      <v-text-field
                        label="Introducer Acc No"
                        v-model="dataIntroducer.IntroducerAccNo"
                        v-on:keypress="[rules.isDigit($event)]"
                        :rules="[rules.required, rules.LengthRulesLessEq('Introducer Acc No', 10)]"
                      >
                      </v-text-field>
                    </v-col>
                  </v-row>

                  <v-row class="border solid">
                    <v-col cols="12" md="8">
                      <v-text-field
                        label="Introducer Details"
                        v-model="dataIntroducer.IntroducerDetails"
                        :rules="[rules.required, rules.LengthRulesLessEq('Introducer Details', 20)]"
                      >
                      </v-text-field>
                    </v-col>
                  </v-row>
                </v-form>
              </v-card-text>
            </v-card>
            <!-- Card No. 2 (END)  -->
          </v-window-item>
          <!-- Window-item No. 1 (END)  -->

          <!-- Window-item No. 2 (START)  -->
          <v-window-item value="Tab2">
            <!-- Card No. 3 (START)  -->
            <v-card outlined>
              <v-card-text>
                <v-form v-model="isFormValid" ref="validform" lazy-validation>
                  <v-card-title>Address List</v-card-title>

                  <v-row class="border solid">
                    <v-col cols="12" md="3">
                      <v-select
                        label="Address Type"
                        v-model="dataAddressList.AddressType"
                        :items="sAddressType"
                        item-text="title"
                        item-value="value"
                        :rules="[rules.required]"
                      >
                      </v-select>
                    </v-col>

                    <v-col cols="12" md="6">
                      <v-text-field
                        label="Address"
                        v-model="dataAddressList.Address"
                        :rules="[rules.required, rules.LengthRulesLessEq('Address', 50)]"
                      >
                      </v-text-field>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-text-field
                        label="City/Town/Area"
                        v-model="dataAddressList.CityName"
                        :rules="[rules.required, rules.LengthRulesLessEq('City/Town/Area', 20)]"
                      >
                      </v-text-field>
                    </v-col>
                  </v-row>

                  <v-row class="border solid">
                    <v-col cols="12" md="3">
                      <v-text-field
                        label="Zip/Postal/Code"
                        v-model="dataAddressList.ZipCode"
                        v-on:keypress="[rules.isDigit($event)]"
                        :rules="[rules.required, rules.LengthRulesLessEq('Zip/Postal/Code', 5)]"
                      >
                      </v-text-field>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-autocomplete
                        label="Country"
                        v-model="dataAddressList.COUNTRY_ID"
                        :items="sCountryName.data"
                        @update:model-value="getAllDivision(dataAddressList.COUNTRY_ID), clearDivision()"
                        item-value="COUNTRY_ID"
                        item-title="COUNTRY_NM"
                        :rules="[rules.required]"
                      >
                      </v-autocomplete>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-autocomplete
                        label="Division/State"
                        v-model="dataAddressList.DIVISION_ID"
                        :items="sDivisionName.data"
                        @update:model-value="getAllDistrict(dataAddressList.DIVISION_ID), clearDistrict()"
                        item-value="DIVISION_ID"
                        item-title="DIVISION_NM"
                        :rules="[rules.required]"
                      >
                      </v-autocomplete>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-autocomplete
                        label="District"
                        v-model="dataAddressList.DISTRICT_ID"
                        :items="sDistrictName.data"
                        @update:model-value="getAllThana(dataAddressList.DISTRICT_ID), clearThana()"
                        item-value="DISTRICT_ID"
                        item-title="DISTRICT_NM"
                        :rules="[rules.required]"
                      >
                      </v-autocomplete>
                    </v-col>
                  </v-row>

                  <v-row class="border solid">
                    <v-col cols="12" md="3">
                      <v-autocomplete
                        label="Thana"
                        v-model="dataAddressList.THANA_ID"
                        :items="sThanaName.data"
                        item-value="THANA_ID"
                        item-title="THANA_NM"
                        :rules="[rules.required]"
                      >
                      </v-autocomplete>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-text-field
                        label="Phone No."
                        v-model="dataAddressList.PhoneNo"
                        v-on:keypress="[rules.isDigit($event)]"
                        :rules="[rules.required, rules.LengthRulesLessEq('Phone No.', 11)]"
                      >
                      </v-text-field>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-text-field
                        label="Mobile No."
                        v-model="dataAddressList.MobileNo"
                        v-on:keypress="[rules.isDigit($event)]"
                        :rules="[rules.required, rules.LengthRulesLessEq('Mobile No.', 11)]"
                      >
                      </v-text-field>
                    </v-col>

                    <v-col cols="12" md="3">
                      <v-text-field
                        label="Email"
                        v-model="dataAddressList.Email"
                        v-on:keypress="[rules.EmailRules($event)]"
                        :rules="[rules.required, rules.LengthRulesLessEq('Email', 30), rules.EmailRules('Email')]"
                      >
                      </v-text-field>
                    </v-col>
                  </v-row>
                  <v-row>
                    <v-col cols="12" md="3">
                      <v-text-field v-if="false" label="address Id" v-model="dataAddressList.ADDRESS_ID"> </v-text-field>
                    </v-col>
                  </v-row>

                  <v-container justify="center" align="right">
                    <v-btn
                      v-if="addfBtn"
                      class="btnAlign"
                      variant="tonal"
                      density="default"
                      color="secondary"
                      @click="addAddressListBtn(dataAddressList)"
                      >ADD</v-btn
                    >
                    <v-btn
                      v-if="updatefBtn"
                      variant="tonal"
                      density="default"
                      color="primary"
                      @click="updateAddressBtn(dataAddressList), disableUpdateBtn"
                      >Update</v-btn
                    >
                  </v-container>
                </v-form>

                <VSheet>
                  <!--TABLE : AddressList -->
                  <EasyDataTable :headers="addressList_headers" :items="addressList_items" buttons-pagination class="elevation-1">
                    <template #item-operation="item">
                      <div class="operation-wrapper">
                        <v-btn small v-if="editBtn" variant="tonal" density="default" color="primary" @click="editaddressBtn(item)"
                          >Edit</v-btn
                        >
                      </div>
                    </template>
                  </EasyDataTable>
                </VSheet>
              </v-card-text>
            </v-card>
            <!-- Card No. 3 (END)  -->
          </v-window-item>
          <!-- Window-item No. 2 (END)  -->
        </v-window>

        <!--Modal : TABLE : CustomerTable -->
      </v-card-text>
    </v-card>
  </v-card>

  <CustomerTableModal
    ref="showCustomerTable"
    :customerTable_items="customerTableItems"
    @selected_Customer="scustomerDisplay"
  ></CustomerTableModal>
</template>

<script lang="ts">
import { defineComponent, ref, toRef, toRefs, watch, reactive, onMounted, computed } from 'vue';
import BaseHeader from '../../components/shared/BaseHeader.vue';
import BlockUI from '../../components/shared/BlockUI.vue';
import router from '@/router/app_router';
import rules from '@/mixins/rules';
import { toast } from 'vue3-toastify';
import { useField, useForm } from 'vee-validate';
import store from '@/store';
import { commonMixin } from '@/mixins/CommonMixin';
import type { LSListItem } from '@/commonModels/LSListItem';
import { dateMixin } from '@/mixins/DateMixin';
import commonMethods from '@/apputility/commonMethods';
import Vue3EasyDataTable from 'vue3-easy-data-table';
import 'vue3-easy-data-table/dist/style.css';

//<!----- sa w (start)----->
//Models
import type ICustomer from '@/views/CustomerInformation/models/ICustomer';
import type IIntroducer from '@/views/CustomerInformation/models/IIntroducer';
import type IAddressList from '@/views/CustomerInformation/models/IAddressList';
//Modals
import CustomerTableModal from './modals/CustomerTableModal.vue';
//Services
import CustomerService from '@/views/CustomerInformation/services/CustomerService';
import { values } from 'lodash';
import { toRaw } from 'vue';

//<!----- sa w (end)----->

export default defineComponent({
  name: 'CustomerInformationUI',
  components: { BaseHeader, BlockUI, CustomerTableModal },

  /* data: () => ({
    EmailRules: [
      (value) => {
        if (value?.length > 3) return true;

        return 'First name must be at least 3 characters.';
      }
    ]
  }),*/

  setup() {
    let openModal = ref(false);
    let isoverlay = ref(false);
    let isFormValid = ref(false);
    let validform = ref();
    const tab = ref(null);

    //#region  <!----- select items (START) ----->

    //(s for select options variable)
    const sGender = ref<LSListItem[]>([
      { value: 'Male', title: 'Male' },
      { value: 'Female', title: 'Female' },
      { value: 'Others', title: 'Others' }
    ]);

    const sMaritalStatus = ref<LSListItem[]>([
      { value: 'Married', title: 'Married' },
      { value: 'Unmarried', title: 'Unmarried' },
      { value: 'Others', title: 'Others' }
    ]);

    const sIntroducerType = ref<LSListItem[]>([
      { value: 'Account Holder', title: 'Account Holder' },
      { value: 'Officer', title: 'Officer' }
    ]);

    const sAddressType = ref<LSListItem[]>([
      { value: 'Present Address', title: 'Present Address' },
      { value: 'Permanent Address', title: 'Permanent Address' }
    ]);

    //Getting Data From Database Table
    let sCountryName = reactive({
      data: [] as any
    });
    let sDivisionName = reactive({
      data: [] as any
    });
    let sDistrictName = reactive({
      data: [] as any
    });
    let sThanaName = reactive({
      data: [] as any
    });
    //#endregion <!----- select items (END) ----->

    onMounted(async () => {
      await getAllCountry();
      await getAllCustomer();
    });

    async function onView() {
      // alert('alert viewing..');
      // openModal.value = true;
      //console.log('openModal', openModal.value);
      await showCustomerTable.value.displayCustomerTable();
    }

    function close() {
      openModal.value = false;
      isoverlay.value = false;
    }

    const OnRefresh = () => {
      //isoverlay.value = true;
      objCustomerModel.dataCustomer = {};
      objIntroducerModel.dataIntroducer = {};
      objAddressListModel.dataAddressList = {};

      addressList_items.value = [];
      sDivisionName.data = [];
      sDistrictName.data = [];
      sThanaName.data = [];
      presentAddressAdded = false;
      permanentAddressAdded = false;
      flag = 0;
      flag1 = 0;

      addfBtn.value = true;
      updatefBtn.value = false;
      editBtn.value = false;

      getAllCustomer();
    };
    const OnRefresh2 = () => {
      objAddressListModel.dataAddressList = {};
    };
    const clearAdrsInputField = () => {
      objAddressListModel.dataAddressList = {};
      sDivisionName.data = [];
      sDistrictName.data = [];
      sThanaName.data = [];
      // objAddressListModel.dataAddressList.DIVISION_ID = '';
      // objAddressListModel.dataAddressList.DISTRICT_ID = '';
      // objAddressListModel.dataAddressList.THANA_ID = '';
    };
    const emptyAdrsTbl = () => {
      addressList_items.value = [];
      sDivisionName.data = [];
      sDistrictName.data = [];
      sThanaName.data = [];
      objAddressListModel.dataAddressList.DIVISION_ID = '';
      objAddressListModel.dataAddressList.DISTRICT_ID = '';
      objAddressListModel.dataAddressList.THANA_ID = '';
      presentAddressAdded = false;
      permanentAddressAdded = false;
    };

    const onExit = () => {
      router.push('home');
    };

    //<!----- sa w (start)----->

    //<--! obj Model -->
    let objCustomerModel = ref<{ dataCustomer: ICustomer }>({ dataCustomer: {} }).value;
    let objIntroducerModel = ref<{ dataIntroducer: IIntroducer }>({ dataIntroducer: {} }).value;
    let objAddressListModel = ref<{ dataAddressList: IAddressList }>({ dataAddressList: {} }).value;

    //<!----- CustomerProfile(Post)----->
    async function saveCustomerInfo() {
      // if (!isFormValid && validform.value == true) {} else {
      //   toast.error('form is not valid');
      // }

      objCustomerModel.dataCustomer.CustomerDateOfBirth = dateMixin().$convertToDDMMMYYFormat(
        objCustomerModel.dataCustomer.CustomerDateOfBirth
      );

      objCustomerModel.dataCustomer.IntroducerInformation = objIntroducerModel.dataIntroducer;
      objCustomerModel.dataCustomer.AddressListInformation = addressList_items.value;
      console.log('Before Save: ', objCustomerModel.dataCustomer);

      //for Saving CustomerProfile , IntroducerInfo , AddressList
      await CustomerService.SaveCustomerInformation(objCustomerModel.dataCustomer)
        .then((res) => {
          toast.success('Data Added');
          console.log('Customer Information Save Response', res);
        })
        .catch((error) => {
          console.log('Error on Save', error);
        });

      //for empty the input fields
      OnRefresh();
    }

    //<!----- CustomerProfile(GET)----->
    async function getCustomerById() {
      objCustomerModel.dataCustomer.CUSTOMER_ID = commonMethods.Get_Padded_Customer_Id(objCustomerModel.dataCustomer.CUSTOMER_ID);

      if (!isFormValid) {
        await CustomerService.GetCustomerInformation(objCustomerModel.dataCustomer.CUSTOMER_ID)
          .then((res) => {
            console.log('GetCustomerInformation', res);
            //<!-- creating clone object -->
            objCustomerModel.dataCustomer.CloneObj = { ...res };
            objIntroducerModel.dataIntroducer.CloneObj = { ...res.IntroducerInformation };
            /*
            addressList_items.value = res.AddressListInformation;
            console.log('addreslist aftr resAdd :', addressList_items.value);
            for (let i of addressList_items.value) {
              i.isAdd = false;
              i.isOld = true;
              i.CloneObj = { ...i };
            }
            console.log('after loop addressList_items.value :', addressList_items.value);
            */

            console.log('objCustomerModel clone :', objCustomerModel);
            console.log('objIntroducerModel clone :', objIntroducerModel);

            objCustomerModel.dataCustomer.isAdd = res.isAdd = false;
            objCustomerModel.dataCustomer.isOld = res.isOld = true;
            objIntroducerModel.dataIntroducer.isAdd = res.isAdd = false;
            objIntroducerModel.dataIntroducer.isOld = res.isOld = true;

            //<!-- Update the CustomerName,CustomerFatherName,... field with the retrieved value -->
            //CustomerProfile
            objCustomerModel.dataCustomer.CustomerName = res.CustomerName;
            objCustomerModel.dataCustomer.CustomerFatherName = res.CustomerFatherName;
            objCustomerModel.dataCustomer.CustomerMotherName = res.CustomerMotherName;
            objCustomerModel.dataCustomer.CustomerGender = res.CustomerGender;
            objCustomerModel.dataCustomer.CustomerDateOfBirth = dateMixin().$convertToCalendarFormat(res.CustomerDateOfBirth); //converted the date to Calender format
            objCustomerModel.dataCustomer.CustomerMaritalStatus = res.CustomerMaritalStatus;
            objCustomerModel.dataCustomer.CustomerMaritalStatus = res.CustomerMaritalStatus;
            objCustomerModel.dataCustomer.CustomerSpouseName = res.CustomerSpouseName;
            objCustomerModel.dataCustomer.CustomerNID = res.CustomerNID;
            //IntroducerInfo
            objIntroducerModel.dataIntroducer.IntroducerType = res.IntroducerInformation.IntroducerType;
            objIntroducerModel.dataIntroducer.IntroducerAccBranch = res.IntroducerInformation.IntroducerAccBranch;
            objIntroducerModel.dataIntroducer.IntroducerAccNo = res.IntroducerInformation.IntroducerAccNo;
            objIntroducerModel.dataIntroducer.IntroducerDetails = res.IntroducerInformation.IntroducerDetails;
            console.log('list of Address:', res.AddressListInformation);
            //AddressList (AddressList UI Table)
            addressList_items.value = res.AddressListInformation;

            console.log('addressList_items', addressList_items);
            toast.success('Data fetched Successfully');

            //to activate Edit button
            editBtn.value = true;
            //to activate Add button
            if (addressList_items.value.length >= 2) {
              addfBtn.value = false;
            } else {
              addfBtn.value = true;

              for (let i = 0; i < addressList_items.value.length; i++) {
                if (objAddressListModel.dataAddressList.AddressType !== addressList_items.value[i].AddressType) {
                  flag = 1;
                }
              }
            }
          })
          .catch((error) => {
            //toast.error(error.value);
            toast.warning('Please Update All Required Data');
          });
      } else {
        toast.error('Please Input All Required Fields.');
      }
    }

    //<!----- Customer(GET-ALL)----->
    async function getAllCustomer() {
      await CustomerService.GetAllCustomer()
        .then((res) => {
          customerTableItems.value = res?.responseData as any;
        })
        .catch((error) => {
          toast.error(error.value);
        });
    }

    //<!----- Country(GET-ALL)----->
    async function getAllCountry() {
      await CustomerService.GetAllCountryInfo()
        .then((res) => {
          sCountryName.data = res?.responseData as any;
        })
        .catch((error) => {
          toast.error(error.value);
        });
    }

    //<!----- Division(GET-ALL)----->
    async function getAllDivision(pf_CountryId) {
      await CustomerService.GetAllDivisionInfo(pf_CountryId)
        .then((res) => {
          if (res == undefined || res == null || res == '') {
            sDivisionName.data = [];
            sDistrictName.data = [];
            sThanaName.data = [];
            objAddressListModel.dataAddressList.DIVISION_ID = '';
            objAddressListModel.dataAddressList.DISTRICT_ID = '';
            objAddressListModel.dataAddressList.THANA_ID = '';
          }

          sDivisionName.data = res;
        })
        .catch((error) => {
          toast.error(error.value);
        });
    }

    //<!----- District(GET-ALL)----->
    async function getAllDistrict(pf_DivisionId) {
      await CustomerService.GetAllDistrictInfo(pf_DivisionId)
        .then((res) => {
          sDistrictName.data = [];
          sDistrictName.data = res;
        })
        .catch((error) => {
          toast.error(error.value);
        });
    }

    //<!----- Thana(GET-ALL)----->
    async function getAllThana(pf_DistrictId) {
      await CustomerService.GetAllThanaInfo(pf_DistrictId)
        .then((res) => {
          sThanaName.data = [];
          sThanaName.data = res;
        })
        .catch((error) => {
          toast.error(error.value);
        });
    }

    //To Clear Selected Item Fields
    async function clearDivision() {
      objAddressListModel.dataAddressList.DIVISION_ID = '';
      objAddressListModel.dataAddressList.DISTRICT_ID = '';
      objAddressListModel.dataAddressList.THANA_ID = '';
    }
    async function clearDistrict() {
      objAddressListModel.dataAddressList.DISTRICT_ID = '';
      objAddressListModel.dataAddressList.THANA_ID = '';
    }
    async function clearThana() {
      objAddressListModel.dataAddressList.THANA_ID = '';
    }

    //<!-- UI : CustomerTable Modals -->
    let showCustomerTable = ref() as any;
    let customerTableItems = ref<[]>([]);

    //<!-- UI : CustomerTable Modal : Send Data From Table to Input Fields -->
    async function scustomerDisplay(selectedCustomer) {
      objCustomerModel.dataCustomer.CUSTOMER_ID = selectedCustomer.CUSTOMER_ID;

      //To Empty UI AddressList Table
      emptyAdrsTbl();

      getCustomerById();
    }

    //<!-- UI : TABLE : AddressList (Present Address & Permanent Address) -->
    const addressList_headers = ref<any[]>([
      { text: 'Address Type', value: 'AddressType', sortable: true },
      { text: 'Address', value: 'Address' },
      { text: 'City', value: 'CityName' },
      { text: 'Zip Code', value: 'ZipCode' },
      //{ text: 'Country-ID', value: 'COUNTRY_ID' },
      { text: 'Country', value: 'CountryName' },
      //{ text: 'Division-ID', value: 'DIVISION_ID' },
      { text: 'Division', value: 'DivisionName' },
      //{ text: 'District-ID', value: 'DISTRICT_ID' },
      { text: 'District', value: 'DistrictName' },
      //{ text: 'Thana-ID', value: 'THANA_ID' },
      { text: 'Thana', value: 'ThanaName' },
      { text: 'Phone No.', value: 'PhoneNo' },
      { text: 'Mobile No.', value: 'MobileNo' },
      //{ text: 'ADDRESS_ID', value: 'ADDRESS_ID' },
      { text: 'Email', value: 'Email' },
      { text: '', value: 'operation' }
    ]);

    //<!-- UI : AddressList Table : Functionality-->
    let addressList_items = ref([] as any);
    let presentAddressAdded = false;
    let permanentAddressAdded = false;
    let addfBtn = ref(true);
    let updatefBtn = ref(false);
    let editBtn = ref(false);
    let flag = 0;
    let flag1 = 0;

    //<!-- UI : AddressList Table : Add button-->
    const addAddressListBtn = (dataAddressList) => {
      //<!-- add button Validation -->
      if (flag == 2) {
        toast.error('Already added two addresses');
        return;
      }
      if (flag == 1) {
        if (objAddressListModel.dataAddressList.AddressType == addressList_items.value[0].AddressType) {
          toast.error('Already added same Address');
          return;
        }
      }

      //<!-- For sending COUNTRY_NM to Backend & UI Table , Databasetable -->
      console.log('address list : ', addressList_items);
      //For Country Name
      let country = sCountryName.data.find((item) => item.COUNTRY_ID == objAddressListModel.dataAddressList.COUNTRY_ID);
      dataAddressList.CountryName = country.COUNTRY_NM;
      //For Division Name
      let division = sDivisionName.data.find((item) => item.DIVISION_ID == objAddressListModel.dataAddressList.DIVISION_ID);
      dataAddressList.DivisionName = division.DIVISION_NM;
      //For District Name
      let district = sDistrictName.data.find((item) => item.DISTRICT_ID == objAddressListModel.dataAddressList.DISTRICT_ID);
      dataAddressList.DistrictName = district.DISTRICT_NM;
      //For Thana Name
      let thana = sThanaName.data.find((item) => item.THANA_ID == objAddressListModel.dataAddressList.THANA_ID);
      dataAddressList.ThanaName = thana.THANA_NM;

      addressList_items.value.push(objAddressListModel.dataAddressList);

      flag += 1;

      //For emptying AddressList Input fields
      clearAdrsInputField();
    };
    /*
    const disableAddButton = computed(() => {
      if (addressList_items.value.length >= 2) {
        return true;
      } else {
        return false;
      }
    });
    */

    //<!-- UI : AddressList Table : Edit button-->
    const editaddressBtn = async (item) => {
      console.log('edit button Click:', item);
      updatefBtn.value = true;

      objAddressListModel.dataAddressList.isAdd = false;
      objAddressListModel.dataAddressList.isOld = true;
      //<!-- creating clone object -->
      objAddressListModel.dataAddressList.CloneObj = { ...item };

      objAddressListModel.dataAddressList.AddressType = item.AddressType;
      objAddressListModel.dataAddressList.Address = item.Address;
      objAddressListModel.dataAddressList.CityName = item.CityName;
      objAddressListModel.dataAddressList.ZipCode = item.ZipCode;
      //---
      objAddressListModel.dataAddressList.COUNTRY_ID = item.COUNTRY_ID;
      objAddressListModel.dataAddressList.CountryName = item.CountryName;

      getAllDivision(objAddressListModel.dataAddressList.COUNTRY_ID);
      objAddressListModel.dataAddressList.DIVISION_ID = item.DIVISION_ID;
      objAddressListModel.dataAddressList.DivisionName = item.DivisionName;

      getAllDistrict(objAddressListModel.dataAddressList.DIVISION_ID);
      objAddressListModel.dataAddressList.DISTRICT_ID = item.DISTRICT_ID;
      objAddressListModel.dataAddressList.DistrictName = item.DistrictName;

      getAllThana(objAddressListModel.dataAddressList.DISTRICT_ID);
      objAddressListModel.dataAddressList.THANA_ID = item.THANA_ID;
      objAddressListModel.dataAddressList.ThanaName = item.ThanaName;
      //---
      objAddressListModel.dataAddressList.PhoneNo = item.PhoneNo;
      objAddressListModel.dataAddressList.MobileNo = item.MobileNo;
      objAddressListModel.dataAddressList.ADDRESS_ID = item.ADDRESS_ID;
      objAddressListModel.dataAddressList.Email = item.Email;
    };

    const updateAddressBtn = (prod) => {
      //console.log('Obj_Address_Prod', toRaw(prod));
      //updatefBtn.value = true;

      //<!-- update button Validation -->
      /*
      for (let i = 0; i < 2; i++) {
        if (objAddressListModel.dataAddressList.AddressType === addressList_items.value[i].AddressType) {
        }else{
          toast.error("AddressType Cannot be changed")
        }
      }
      */

      //<!-- For sending COUNTRY_NM to Backend & UI Table , Databasetable -->

      var findIndx = toRaw(addressList_items.value).findIndex((item) => item.ADDRESS_ID == toRaw(prod).ADDRESS_ID);
      console.log('finindx', findIndx);

      if (findIndx != -1) {
        //For Country Name
        let country = sCountryName.data.find((item) => item.COUNTRY_ID == objAddressListModel.dataAddressList.COUNTRY_ID);
        prod.CountryName = country.COUNTRY_NM;
        //For Division Name
        let division = sDivisionName.data.find((item) => item.DIVISION_ID == objAddressListModel.dataAddressList.DIVISION_ID);
        prod.DivisionName = division.DIVISION_NM;
        //For District Name
        let district = sDistrictName.data.find((item) => item.DISTRICT_ID == objAddressListModel.dataAddressList.DISTRICT_ID);
        prod.DistrictName = district.DISTRICT_NM;
        //For Thana Name
        let thana = sThanaName.data.find((item) => item.THANA_ID == objAddressListModel.dataAddressList.THANA_ID);
        prod.ThanaName = thana.THANA_NM;

        // let obj_find = addressList_items.value.find((addSearch) => {
        //   addSearch.AddressType == objAddressListModel.dataAddressList.AddressType;
        //   // sAddressType
        // });

        addressList_items.value.splice(findIndx, 1);

        addressList_items.value.push(prod);

        objAddressListModel.dataAddressList = {};
      } else {
        addressList_items.value.push(prod);
      }

      updatefBtn.value = false;
    };
    const disableUpdateBtn = computed(() => {
      // if (addressList_items.value.length < 2) {
      //   return true;
      // } else {
      //   return false;
      // }
    });

    //<!-- Validation for Input Field -->
    const customerIdReadOnly = computed(() => {
      return true;
    });

    const spouseNmDisable = computed(() => {
      if (
        objCustomerModel.dataCustomer.CustomerMaritalStatus === 'Unmarried' ||
        objCustomerModel.dataCustomer.CustomerMaritalStatus === 'Others'
      ) {
        objCustomerModel.dataCustomer.CustomerSpouseName = '';

        return true;
      }
      return false;
    });

    //const hasError = computed(() => !rules.required(rules.required));

    //<!----- sa w (end)----->

    return {
      onView,
      close,
      onExit,
      rules,
      isFormValid,
      openModal,
      dateMixin,
      //<!-- Refresh -->
      OnRefresh,
      OnRefresh2,
      clearAdrsInputField,
      emptyAdrsTbl,
      //<!-- Tab -->
      tab,

      //<!-- Obj Models -->
      ...toRefs(objCustomerModel),
      saveCustomerInfo,
      getCustomerById,
      getAllCustomer,
      ...toRefs(objIntroducerModel),
      ...toRefs(objAddressListModel),
      getAllCountry,
      getAllDivision,
      getAllDistrict,
      getAllThana,

      //<!-- etc(others) -->
      clearDivision,
      clearDistrict,
      clearThana,

      //<!-- TABLES -->
      //Table : AddressList
      addressList_headers,
      addressList_items,

      //Table : CustomerTable
      showCustomerTable,
      customerTableItems,
      scustomerDisplay,

      //<!----- Buttons Functions ----->
      addAddressListBtn,
      //disableAddButton,
      editaddressBtn,
      updateAddressBtn,
      disableUpdateBtn,
      addfBtn,
      updatefBtn,
      editBtn,
      flag,
      flag1,

      //<!----- select items (START)----->
      select: null,
      sGender,
      sMaritalStatus,
      sIntroducerType,
      sAddressType,
      sCountryName,
      sDivisionName,
      sDistrictName,
      sThanaName,
      //<!----- select items (END)----->

      //<!----- Validation Functions ----->
      customerIdReadOnly,
      spouseNmDisable,
      validform
    };
  }
});
</script>

<!-- sa w (style) -->
<style scoped>
.sa-card-title {
  height: 45px;
  width: auto;

  font-size: 14px;
  color: white;

  background-color: rgba(7, 42, 105, 0.849);
  border-radius: 5px;

  margin-bottom: 10px;
  padding-bottom: 35px;
}

.sa-card-tabs-titlebar {
  color: white;

  background-color: rgba(7, 42, 105, 0.849);
  border-radius: 5px;
}

.btnAlign {
  margin-right: 10px;
}
</style>
