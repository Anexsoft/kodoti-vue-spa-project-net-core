export default class ClientProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    getAll(page, take) {
        return this.axios.get(this.url + `clients?page=${page}&take=${take}`);
    }
}