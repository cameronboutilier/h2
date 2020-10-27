import axios from 'axios';

// This is my api file, all of the calls to the calls to the backend go here.
// you can change the port on the url to whatever suits you.
const url = "https://localhost:44387/Car";

const Api = {
    loadItems(d){
        return axios.get(url + "?date=" +  d.toLocaleString(), {});
    },
};

export default Api;