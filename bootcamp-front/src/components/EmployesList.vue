<template>
  <div>
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
      <template #cell(excluir)>
        <b-button size="sm" variant="danger">Excluir</b-button>
      </template>
      <template #cell(editar)>
        <b-button size="sm" variant="primary" @click="editarFuncionario(form)"
          >Editar</b-button
        >
      </template>
    </b-table>

    <b-modal v-model="showModal" title="Edit the employee's information">
      <b-form>
        <b-form-group id="input-group-1" label="Nome:" label-for="input-1">
          <b-form-input id="input-1" v-model="form.name"></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Email:" label-for="input-2">
          <b-form-input id="input-2" v-model="form.email"></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Cargo:" label-for="input-3">
          <b-form-input id="input-3" v-model="form.position"></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-4" label="Telefone:" label-for="input-4">
          <b-form-input id="input-4" v-model="form.phone"></b-form-input>
        </b-form-group>

        <b-button type="submit" variant="primary" @click="updateEmployee()"
          >Save</b-button
        >
        <b-button variant="secondary">Cancel</b-button>
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

          this.showModal = false;
        })
        .catch((error) => {
          console.log(error.response.data);
        })
        .finally(() => {
          this.isSubmitting = false;
        });
    },

    editarFuncionario(form) {
      this.form = { ...form };
      this.showModal = true;
    },
  },
};
</script>
