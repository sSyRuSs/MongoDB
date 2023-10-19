import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:5198/api'

export const getEmployyes = () => {
  return axios.get('/nhanvien')
}

export const createEmployye = (body) => {
  return axios.post('/nhanvien', body)
}

export const updateEmployye = (id, body) => {
  return axios.put(`/nhanvien/${id}`, body)
}

export const deleteEmployye = (id) => {
  return axios.delete(`/nhanvien/${id}`)
}
