import axios from 'axios'


const baseUrl = process.env.API_BASE_URL ?? 'https://localhost:7194';

const api = axios.create({
  baseURL: baseUrl,
  headers: {
    'Content-Type': 'application/json',
  },
})

export default api;
