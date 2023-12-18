<template>
    <div class="signin-container">
        <h2>Sign in</h2>
        <form>
            <div class="form-group">
                <label>Email address</label>
                <input type="email" required>
            </div>
            <div class="form-group">
                <label>Password</label>
                <input type="password" required>
            </div>
            <button type="submit">Sign in</button>
        </form>
    </div>

    <div class="createanaccount-container">
        <span>New to here? <a href="" @click.prevent="goToPage('/signup')">Create an Account</a></span>
    </div>
</template>

<script>
    export default {
        methods: {
            goToPage(path) {
                this.$router.push(path);
            }
        },
    }
</script>

<style scoped>
    .signin-container {
        max-width: 400px;
        margin: 10px auto;
        padding: 20px;
        background-color: #fff;
        border-radius: 5px;
    }

        .signin-container h2 {
            text-align: center;
            color: #333;
        }

        .signin-container form {
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

    input[type="email"],
    input[type="password"] {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        border: 1px solid #ccc;
        border-radius: 5px;
        font-size: 16px;
        box-sizing: border-box;
    }

    button {
        background-color: #63C132;
        color: #fff;
        border: none;
        padding: 10px;
        border-radius: 5px;
        font-size: 18px;
        cursor: pointer;
    }

        button:hover {
            background-color: #59ad2d;
        }

    .createanaccount-container {
        max-width: 400px;
        margin: 10px auto;
        padding: 20px;
        background-color: #fff;
        border-radius: 5px;
        text-align: center;
    }

        .createanaccount-container a {
            text-decoration: none;
            font-weight: lighter;
        }
</style>