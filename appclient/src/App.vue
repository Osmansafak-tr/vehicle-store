<template>
    <navbar :pages="pages">
    </navbar>

    <router-view></router-view>

</template>

<script>
    import Navbar from "./components/Navbar.vue";
    import Signup from "./components/Signup.vue";
    import Signin from "./components/Signin.vue";
    import Vehiclecard from "./components/Vehiclecard.vue";
   

    export default {
        components: {
            Navbar,
            Signup,
            Signin,
            Vehiclecard
        },

        created() {
            this.getPages();
        },

        data() {
            return {
                activePage: 0,
                theme: "dark",
                pages: [],
            }
        },
        methods: {
            async getPages() {
                let res = await fetch('pages.json');
                let data = await res.json();

                this.pages = data;
            },
        },
    };
</script>