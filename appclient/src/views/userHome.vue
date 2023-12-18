<template>

    <button class="btn btn-primary" @click="goToPage('/user/' + $route.params.id + '/add')">Add</button>
    <section class="grid-container">
        <vehiclecard v-for="n in users.find(user => user.u_id == $route.params.id)?.number_of_car"
                     :plate="vehicles.filter(vehicle => vehicle.user_id == $route.params.id)[n-1]?.plate"
                     :src="models.find(model => model.id == vehicles.filter(vehicle => vehicle.user_id == $route.params.id)[n-1]?.model_id)?.img"
                     :vid="vehicles.filter(vehicle => vehicle.user_id == $route.params.id)[n-1]?.v_id"
                     >
        </vehiclecard>
    </section>

</template>

<script>
    import Vehiclecard from "@/components/Vehiclecard.vue";

    export default {
        components: {
            Vehiclecard
        },

        created() {
            this.getUsers();
            this.getVehicles();
            this.getModels();
        },

        data() {
            return {
                users: [],
                vehicles: [],
                models: [],
            }
        },

        methods: {
            goToPage(path) {
                this.$router.push(path);
            },
            async getUsers() {
                let res = await fetch('users.json');
                let data = await res.json();
                    
                this.users = data;
            },
            async getVehicles() {
                let res = await fetch('vehicles.json');
                let data = await res.json();

                this.vehicles = data;
            },
            async getModels() {
                let res = await fetch('models.json');
                let data = await res.json();
                    
                this.models = data;
               
            },

        },
    }
</script>

<style scoped>
    .btn-primary {
        margin-top: 20px;
        margin-left: 20px;
    }

    .grid-container {
        display: grid;
        grid-template-columns: repeat(3, 1fr);
        grid-gap: 20px;
        margin: 20px;
    }
</style>
