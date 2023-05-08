<template>
  <div>
    <b-alert v-model="showAlertSuccess" variant="success" show
      >Record updated!</b-alert
    >
    <b-alert v-model="showAlertDelete" variant="success" show
      >Record deleted!</b-alert
    >
    <h2>Lista de Funcionários</h2>
    <b-table :items="funcionarios" :fields="fields" striped hover responsive>
      <template #cell(nome)="item">
        <p>{{ item.Name }}</p>
      </template>
      <template #cell(Email)="item">
        <p>{{ item.Email }}</p>
      </template>
      <template #cell(cargo)="item">
        <p>{{ item.Position }}</p>
      </template>
      <template #cell(phone)="item">
        <p>{{ item.PhoneNumber }}</p>
      </template>
      <template #cell(excluir)="item">
        <b-button
          size="sm"
          variant="danger"
          @click="excluirFuncionario(item.item)"
          >Excluir</b-button
        >
      </template>
      <template #cell(editar)="item">
        <b-button
          size="sm"
          variant="primary"
          @click="editarFuncionario(item.item)"
          >Editar</b-button
        >
      </template>
    </b-table>

    <b-modal
      v-model="showModalDelete"
      id="modal-lg"
      size="lg"
      title="Delete the employee's information"
      ok-only
      no-close-on-backdrop
      @ok="deleteEmployee()"
    >
      Are you sure to delete this employee contact?
    </b-modal>

    <b-modal
      v-model="showModal"
      title="Edit the employee's information"
      hide-footer
    >
      <b-form>
        <b-form-group id="input-group-1" label="Nome:" label-for="input-1">
          <b-form-input
            id="input-1"
            v-model="form.name"
            class="mb-2"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Email:" label-for="input-2">
          <b-form-input
            id="input-2"
            v-model="form.email"
            class="mb-2"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Cargo:" label-for="input-3">
          <b-form-input
            id="input-3"
            v-model="form.position"
            class="mb-2"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-4" label="Telefone:" label-for="input-4">
          <b-form-input
            id="input-4"
            v-model="form.phone"
            class="mb-2"
          ></b-form-input>
        </b-form-group>

        <b-button variant="primary" @click="updateEmployee()" class="mt-3 mr-4"
          >Save</b-button
        >
        <b-button variant="secondary" class="mt-3" style="margin-left: 0.5rem"
          >Cancel</b-button
        >
      </b-form>
    </b-modal>
  </div>
</template>

<style>
.nome-col {
  width: 200px;
}
</style>

<script>
import axios from "axios";

export default {
  data() {
    return {
      isSubmitting: false,
      showModal: false,
      showAlertSuccess: false,
      showModalDelete: false,
      showAlertDelete: false,

      form: {
        id: null,
        name: "",
        email: "",
        position: "",
        phone: "",
      },

      employee: {
        id: null,
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

      funcionarios: [],
      fields: [
        { key: "name", label: "Nome", tdClass: "nome-col" },
        { key: "email", label: "E-mail" },
        { key: "position", label: "Cargo" },
        { key: "phoneNumber", label: "Telefone" },
        {
          key: "editar",
          label: "Ações",
          class: "text-center",
          sortable: false,
        },
        {
          key: "excluir",
          label: "Ações",
          class: "text-center",
          sortable: false,
        },
      ],
    };
  },

  created() {
    this.getFuncionarios();
  },
  methods: {
    async getFuncionarios() {
      try {
        const response = await axios.get(
          "https://localhost:44364/Contact/contacts"
        );
        this.funcionarios = response.data;
      } catch (error) {
        console.log(error);
      }
    },

    updateEmployee() {
      if (this.isSubmitting) return;
      this.isSubmitting = true;

      const { id, ...updateContact } = this.form;
      axios
        .put(`https://localhost:44364/Contact/contacts/${id}`, updateContact)
        .then((response) => {
          console.log(response.data);
          const index = this.funcionarios.findIndex(
            (employee) => employee.id === id
          );
          this.funcionarios[index] = {
            ...this.funcionarios[index],
            ...updateContact,
          };

          this.getFuncionarios();

          this.showModal = false;
          this.showAlertSuccess = true;
          setTimeout(() => {
            this.showAlertSuccess = false;
          }, 3000);
        })
        .catch((error) => {
          console.log(error.response.data);
        })
        .finally(() => {
          this.isSubmitting = false;
        });
    },

    deleteEmployee() {
      const id = this.form.id;

      axios
        .delete(`https://localhost:44364/Contact/contacts/${id}`)
        .then((response) => {
          console.log(response.data);

          this.getFuncionarios();

          this.showModalDelete = false;
          this.showAlertDelete = true;
          setTimeout(() => {
            this.showAlertDelete = false;
          }, 3000);
        })
        .catch((error) => {
          console.log(error.response.data);
        });
    },

    editarFuncionario(form) {
      this.form = { ...form };
      this.showModal = true;
    },

    excluirFuncionario(form) {
      this.form = { ...form };
      this.showModalDelete = true;
    },
  },
};
</script>
