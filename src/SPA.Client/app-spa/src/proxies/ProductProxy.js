export default class ProductProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    get(id) {
        return this.axios.get(this.url + `products/${id}`);
    }

    getAll(page, take) {
        return this.axios.get(this.url + `products?page=${page}&take=${take}`);
    }

    create(params) {
        return this.axios.post(this.url + `products`, params);
    }

    update(id, params) {
        return this.axios.put(this.url + `products/${id}`, params);
    }

    remove(id) {
        return this.axios.delete(this.url + `products/${id}`);
    }
}