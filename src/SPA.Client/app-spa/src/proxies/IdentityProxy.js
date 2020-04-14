export default class IdentityProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    register(params) {
        return this.axios.post(this.url + 'identity/register', params);
    }

    login(params) {
        return this.axios.post(this.url + 'identity/login', params);
    }

    refresh() {
        return this.axios.get(this.url + 'identity/refresh_token');
    }
}