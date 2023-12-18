<template>
    <div class="card" :vid="`${vid}`">
        <button class="btn btn-warning" @click="editVehicle(vid)"> Edit </button>
        <button class="btn btn-danger"> Delete </button>
        <img v-if="src" alt="Vehicle" :src="require(`@/assets/${src}`)">
        <h2>{{plate}}</h2>
    </div>

</template>

<script>
    export default {
        props: ['plate', 'src', 'vid'],
        data() {
            return {
                open: false,
            }

        },
        methods: {
            editVehicle(vId) {
                this.$router.push({
                    path: `/user/${this.$route.params.id}/edit`,
                    query: {
                        vId,
                    },
                });
            },
        }
    }
</script>


<style >
    .card {
        position: relative;
        background-color: gray;
        border: 1px;
        margin: 10px;
        border-radius: 10px;
        overflow: hidden;
    }

        .card h2 {
            text-align: center;
            color: white;
        }

    .btn-warning {
        position: absolute;
        top: 8px;
        left: 16px;
    }

    .btn-danger {
        position: absolute;
        top: 8px;
        right: 16px;
    }
    
</style>