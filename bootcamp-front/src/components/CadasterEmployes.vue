<template>
  <div>
    <b-card
      bg-variant="dark"
      text-variant="white"
      title="Below Employe's Information"
    >
      <b-form @submit.prevent="submitForm">
        <b-form-group id="input-group-1" label="Nome:" label-for="input-1">
          <b-form-input
            id="input-1"
            v-model="employee.name"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="E-mail:" label-for="input-2">
          <b-form-input
            id="input-3"
            v-model="employee.email"
            type="email"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Phone:" label-for="input-3">
          <b-form-input id="input-4" v-model="employee.phone"></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-3"
          label="Cell Phone:"
          label-for="input-3"
        >
          <b-form-input
            id="input-4"
            v-model="employee.phoneNumber"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-4" label="Address:" label-for="input-4">
          <b-form-input id="input-4" v-model="employee.address"></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-5" label="City:" label-for="input-5">
          <b-form-input id="input-2" v-model="employee.city"></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-6"
          label="Birthday Date:"
          label-for="input-6"
        >
          <b-form-input
            type="date"
            id="input-2"
            v-model="employee.birthday"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-6" label="Position:" label-for="input-6">
          <b-form-input id="input-2" v-model="employee.position"></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-6" label="Company:" label-for="input-6">
          <b-form-input id="input-2" v-model="employee.company"></b-form-input>
        </b-form-group>

        <b-button
          :disabled="isSubmitting"
          type="submit"
          variant="primary"
          @click="submitForm"
          class="mt-3"
          >Cadastrar</b-button
        >

        <b-modal
          v-model="showAlertSuccess"
          variant="success"
          id="bv-modal-example"
          hide-footer
        >
          <template #modal-title> Success </template>
          <div class="d-block text-center">
            <h4>Employee cadastred!</h4>
          </div>
          <b-button
            class="mt-3"
            block
            @click="$bvModal.hide('bv-modal-example')"
            >Okay</b-button
          >
        </b-modal>

        <b-modal
          v-model="showAlertInsuccess"
          variant="danger"
          id="bv-modal-example"
          hide-footer
        >
          <template #modal-title> Insuccess </template>
          <div class="d-block text-center">
            <h4>Occurred a problem, try again later!</h4>
          </div>
          <b-button
            class="mt-3"
            block
            @click="$bvModal.hide('bv-modal-example')"
            >Okay</b-button
          >
        </b-modal>
      </b-form>
    </b-card>
  </div>
</template>

<style></style>

<script>
import axios from "axios";

export default {
  data() {
    return {
      showAlertInsuccess: false,
      showAlertSuccess: false, //verificar se o funcionário foi cadastrado
      isSubmitting: false, // flag para verificar se o formulário já está sendo enviado
      employee: {
        name: "",
        email: "",
        phone: "",
        phoneNumber: "",
        address: "",
        city: "",
        birthday: "",
        position: "",
        company: "",
      },
    };
  },
  methods: {
    submitForm() {
      if (this.isSubmitting) return; // se já estiver enviando, não faz nada
      this.isSubmitting = true; // marca que está enviando

      axios
        .post("https://localhost:44364/Contact/contacts", this.employee)
        .then((response) => {
          if (response.status === 200) {
            this.showAlertSuccess = true;
          } else {
            this.showAlertInsuccess = true;
          }
          console.log(response.data);
          this.employee.name = "";
          this.employee.email = "";
          this.employee.phone = "";
          this.employee.phoneNumber = "";
          this.employee.address = "";
          this.employee.city = "";
          this.employee.birthday = "";
          this.employee.position = "";
          this.employee.company = "";
        })
        .catch((error) => {
          console.log(error.response.data);
        })
        .finally(() => {
          this.isSubmitting = false; // libera o botão para uma nova submissão
        });
    },
  },
};
</script>
