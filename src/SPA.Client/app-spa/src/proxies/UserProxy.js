export default class UserProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    getAll(page, take) {
        return this.axios.get(this.url + `users?page=${page}&take=${take}`);
    }
}