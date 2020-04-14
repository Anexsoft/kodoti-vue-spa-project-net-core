import Axios from 'axios';
import IdentityProxy from './IdentityProxy';
import UserProxy from './UserProxy';
import ProductProxy from './ProductProxy';
import OrderProxy from './OrderProxy';
import ClientProxy from './ClientProxy';

// Axios default behavior
Axios.defaults.headers.common.Accept = 'application/json';

// Token
Axios.interceptors.request.use(
    config => {
        let token = localStorage.getItem('access_token');

        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }

        return config;
    },
    error => Promise.reject(error)
);

Axios.interceptors.response.use(
    response => response,
    error => {
        const { status } = error.response;

        if (status === 401) {
            localStorage.removeItem('access_token');
            window.location.reload(true);
        }

        return Promise.reject(error);
    }
);


let url = null;

if (localStorage.getItem("config") !== null) {
    let config = JSON.parse(localStorage.getItem("config"));
    url = config.apiUrl;
}

export default {
    identityProxy: new IdentityProxy(Axios, url),
    userProxy: new UserProxy(Axios, url),
    productProxy: new ProductProxy(Axios, url),
    orderProxy: new OrderProxy(Axios, url),
    clientProxy: new ClientProxy(Axios, url)
}