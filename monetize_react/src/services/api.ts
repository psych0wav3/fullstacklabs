import axios from 'axios';

export enum Endpoint {
  Balance = 'Balance',
  Moviments = 'moviments',
  Convert = 'Convert'
}

const api = axios.create({
  baseURL: "https://localhost:5001/"
})

export default api;