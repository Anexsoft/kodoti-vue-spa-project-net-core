import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

function getUser() {
    let token = localStorage.getItem("access_token");

    if (!token) {
        return;
    }

    token = localStorage.getItem("access_token").split(".");

    if (!token) {
        return null;
    }

    let result = JSON.parse(
        decodeURIComponent(
            atob(token[1])
                .split("")
                .map(c => {
                    return (
                        "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2)
                    );
                })
                .join("")
        )
    );

    // Cuando trae un solo rol se vuelve un string la propiedad, así que lo forzamos para que sea siempre un array.
    if (typeof result.role !== 'object') {
        result.role = [result.role];
    }

    return {
        id: result.nameid,
        name: result.unique_name,
        lastName: result.family_name,
        email: result.email,
        roles: result.role
    };
}

const store = new Vuex.Store({
    state: {
        user: null
    },
    getters: {
        user: (state) => {
            if (!state.user) {
                return getUser();
            }

            return state.user;
        }
    },
    mutations: {
        signIn(state) {
            state.user = getUser();
        }
    }
})

export default store;