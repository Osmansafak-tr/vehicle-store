<template>
    <nav class= "navbar-light bg-light navbar navbar-expand-lg">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">Ford Otosan</a>
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li v-for="(page) in pages" class="nav-item">
                    <a class="nav-link"
                       href=""
                       :title="` ${ page.link.text } `"
                       @click.prevent="goToPage(`${page.link.url}`)">{{ page.link.text }}</a>
                </li>
            </ul>
            <div class="user-box">
                <button id="signInButton" @click="goToPage('/')" class="btn btn-success">Sign in</button>
                <button id="signUpButton" @click="goToPage('/signup')" class="btn btn-primary">Sign up</button>
            </div>
        </div>
    </nav>
</template>

<script>
    export default {
        props: ['pages'],
        methods: {
            goToPage(path) {
                this.$router.push(path);
            }
        },
    }
</script>

<style scoped>
    .user-box {
        display: flex;
        align-items: center;
        margin-right: 10px;
    }
    #signUpButton {
        margin-left: 10px;
    }

    #signUpButton {
        margin-left: 10px;
    }
</style>