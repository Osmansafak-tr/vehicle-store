<template>
    <div class="signup-container">
        <h2>Sign up</h2>
        <form>
            <div class="form-group">
                <label>Name</label>
                <input type="text" required>
            </div>
            <div class="form-group">
                <label>Surname</label>
                <input type="text" required>
            </div>
            <div class="form-group">
                <label>Email address</label>
                <input type="email" required>
            </div>
            <div class="form-group">
                <label>Create a password</label>
                <input type="password" required>
            </div>
            <div class="form-group">
                <label>Confirm your password</label>
                <input type="password" required>
            </div>
            <button type="submit">Create an Account</button>
        </form>
    </div>
</template>

<style scoped>
    .signup-container {
        max-width: 400px;
        margin: 10px auto;
        padding: 20px;
        background-color: #fff;
        border-radius: 5px;
    }

        .signup-container h2 {
            text-align: center;
            color: #333;
        }

        .signup-container form {
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
    input[type="password"],
    input[type="text"],
    select[id="role"] {
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
</style>