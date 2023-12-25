<template>

    <button class="btn btn-primary" @click="goToPage('/user/' + $route.params.id + '/add')">Add</button>
    <section class="grid-container">
        <vehiclecard v-for="n in users2.find(user => user.u_id == $route.params.id)?.number_of_car"
                     :plate="vehicles2.filter(vehicle => vehicle.user_id == $route.params.id)[n-1]?.plate"
                     :src="models.find(model => model.id == vehicles2.filter(vehicle => vehicle.user_id == $route.params.id)[n-1]?.model_id)?.img"
                     :vid="vehicles2.filter(vehicle => vehicle.user_id == $route.params.id)[n-1]?.v_id">
        </vehiclecard>
        <vehiclecard v-for="n in number_of_cars"
                     :plate="vehicles.filter(vehicle => vehicle.userId == $route.params.id)[n-1]?.plate"
                     :src="vehicleModels.find(model => model.id == vehicles.filter(vehicle => vehicle.userId == $route.params.id)[n-1]?.modelId)?.imageUrl"
                     :vid="vehicles.filter(vehicle => vehicle.userId == $route.params.id)[n-1]?.vin"></vehiclecard>
                     
    </section>

</template>

<script>
    import Vehiclecard from "@/components/Vehiclecard.vue";
    import axios from 'axios';

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
                users2: [],
                vehicles: [],
                vehicles2: [],
                models: [],
                vehicleModels: [],
                number_of_cars: null,
            }
        },
        mounted() {
            this.fetchVehicles();
            this.fetchUsers();
            this.fetchVehicleModels();
        },

        methods: {
            goToPage(path) {
                this.$router.push(path);
            },
            async getUsers() {
                let res = await fetch('users.json');
                let data = await res.json();

                this.users2 = data;
            },
            async getVehicles() {
                let res = await fetch('vehicles.json');
                let data = await res.json();

                this.vehicles2 = data;
            },

            async fetchVehicles() {
                try {
                    const response = await axios.get('https://localhost:7083/Vehicles');
                    this.vehicles = response.data;                    
                    this.number_of_cars = this.vehicles.filter(vehicle => vehicle.userId == this.$route.params.id).length;
                } catch (error) {
                    console.error('Error fetching vehicles:', error);
                }
            },

            async fetchUsers() {
                try {
                    const response = await axios.get('https://localhost:7083/Users');
                    this.users = response.data;
                    const test = this.users.find(user => user.id == this.$route.params.id)?.name;

                } catch (error) {
                    console.log('Error fetching users:', error);
                }
            },

            async fetchVehicleModels() {
                try {
                    const response = await axios.get('https://localhost:7083/VehicleModels');
                    this.vehicleModels = response.data;                    
                } catch (error) {
                    console.log('Error fetching users:', error);
                }
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
