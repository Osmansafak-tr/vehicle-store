import { createRouter, createWebHashHistory } from 'vue-router';
import Home from './views/home.vue';
import Signup from './views/signupPage.vue';
import User from './views/user.vue';
import UserHome from './views/userHome.vue';
import Add from './views/add.vue';
import Edit from './views/edit.vue';
import PageNotFound from './views/pageNotFound.vue';

const routes= [
    { path: '/', component: Home },
    { path: '/signup', component: Signup },
    {   path: '/user/:id', component: User,
        children: [
            { path: '', component: UserHome },
            { path: 'edit', component: Edit },
            { path: 'add', component: Add },
        ],
    },
    { path: '/pagenotfound', component: PageNotFound}
];

const router = createRouter({
    history: createWebHashHistory(),
    routes,   
});



router.beforeEach((to, from, next) => {
    if (!to.matched.length) {
        next('/pagenotfound');
    } else {
        next();
    }
});

export default router;





