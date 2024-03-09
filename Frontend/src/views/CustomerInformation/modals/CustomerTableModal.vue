<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" max-width="80%" min-height="auto" transition="dialog-top-transition" scrollable>
      <v-card outlined>
        <v-card-text>
          <v-card-title class="sa-card-title sa-modal-titlebar">Customer Table </v-card-title>

          <v-card-actions>
            <v-container class="modal-buttons" justify="center" align="right">
              <v-btn color="secondary" variant="tonal" density="default" @click="dialog = false"> Close </v-btn>
            </v-container>
          </v-card-actions>

          <v-card-text>
            <v-container>
              <v-text-field
                v-model="searchValue"
                background-color="grey lighten-2"
                hide-details
                hide-selected
                :menu-props="{ closeOnContentClick: true, maxHeight: 400, maxWidth: 150 }"
                no-data-text="No data found"
                variant="solo"
                clearable
                density="compact"
                class="flex-full-width"
                placeholder="Search Customer"
                prepend-inner-icon="mdi-magnify"
              >
              </v-text-field>
            </v-container>

            <v-container>
              <VSheet>
                <EasyDataTable
                  :headers="customerTable_headers"
                  :items="customerTable_items"
                  buttons-pagination
                  :search-value="searchValue"
                  class="elevation-1"
                  @click-row="editCustomerBtn"
                >
                  <!-- <template #item-operation="item">
                    <div class="operation-wrapper">
                      <v-btn small variant="tonal" density="default" color="primary" @click="editCustomerBtn(item)">Edit</v-btn>
                    </div>
                  </template> -->
                </EasyDataTable>
              </VSheet>
            </v-container>
          </v-card-text>
        </v-card-text>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import type ICustomer from '@/views/CustomerInformation/models/ICustomer';
import CustomerService from '@/views/CustomerInformation/services/CustomerService';
import CustomerInformation from '../CustomerInformation.vue';

export default defineComponent({
  props: {
    customerTable_items: {
      type: Object
    }
  },

  //emits: ['selectedCustomer.value'],

  setup(props, { emit }) {
    //  console.log('props :', props);

    const dialog = ref(false);
    async function displayCustomerTable() {
      dialog.value = true;
    }

    const searchValue = ref('');

    //TABLE : All Customer Info
    const customerTable_headers = ref<any[]>([
      { text: 'Customer-ID', value: 'CUSTOMER_ID', sortable: true },
      { text: 'Customer-Name', value: 'CustomerName' },
      { text: 'Father-Name', value: 'CustomerFatherName' },
      { text: 'Mother-Name', value: 'CustomerMotherName' },
      { text: 'Gender', value: 'CustomerGender' },
      { text: 'DateOfBirth', value: 'CustomerDateOfBirth' },
      { text: 'Marital-Status', value: 'CustomerMaritalStatus' },
      { text: 'Spouse-Name', value: 'CustomerSpouseName' },
      { text: 'Customer-NID', value: 'CustomerNID' },
      { text: '', value: 'operation' }
    ]);

    const selectedCustomer = ref({});
    const editCustomerBtn = (item) => {
      //objCustomerModel.dataCustomer.CUSTOMER_ID = item.CUSTOMER_ID;
      selectedCustomer.value = { ...item };

      emit('selected_Customer', selectedCustomer.value);

      dialog.value = false;
    };

    /* async function showIndex() {
      emit('itemRowIndex');
     }
    */

    return {
      dialog,
      displayCustomerTable,
      //TABLE : AddressList
      customerTable_headers,
      editCustomerBtn,
      searchValue
    };
  }
});
</script>

<style scoped>
.sa-modal-titlebar {
  position: relative;
  top: 47px;
}

.modal-buttons {
  position: relative;
  top: 50px;
  left: 15px;
  margin: -15px;
  padding-bottom: 5px;
}
</style>
