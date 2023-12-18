<template>
    <div class="add-container">
        <h2>Add Vehicle</h2>
        <form>
            <select class="vehicleType">
                <option v-for="(model) in models"> {{model.name}} </option>
            </select>
            <div class="form-group">
                <label>Plate</label>
                <input type="text" required>
            </div>
            <div class="form-group">
                <label>Vehicle Identification Number</label>
                <input type="text" required>
            </div>
            <button type="submit" class="btn btn-primary">Add</button>
        </form>
</div>
</template>

<script>
    export default {
        created() {
            this.getModels();
        },

        data() {
            return {
                models: [],
            }
        },

        methods: {
            async getModels() {
                let res = await fetch('models.json');
                let data = await res.json();
                
                this.models = data;
            }
        }
    }
</script>


<style scoped>
    .add-container {
        max-width: 400px;
        margin: 10px auto;
        padding: 20px;
        background-color: #fff;
        border-radius: 5px;
    }

        .add-container h2 {
            text-align: center;
            color: #333;
        }

        .add-container form {
            display: flex;
            flex-direction: column;
        }

    .form-group {
        margin: 10px;
    }

        .form-group label {
            font-size: 16px;
            color: #333;
        }

    input[type="text"]{
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 16px;
        box-sizing: border-box;
    }

    .vehicleType {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 16px;
        box-sizing: border-box;
    }


</style>