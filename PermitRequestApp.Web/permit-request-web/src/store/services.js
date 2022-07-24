import Axios from "axios";
import PermitService from "../components/services/PermitService";

let apiUrl = 'https://localhost:44356';

// Axios Configuration //
Axios.defaults.headers.common.Accep = 'application/json'

export default {
    permitService: new PermitService(Axios,apiUrl)
}