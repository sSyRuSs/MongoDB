import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:5198/api'

export const getProducts = () => {
  return axios.get('/sanpham')
}

export const createProduct = (body) => {
  return axios.post('/sanpham', body)
}

export const updateProduct = (id, body) => {
  return axios.put(`/sanpham/${id}`, body)
}

export const deleteProduct = (id) => {
  return axios.delete(`/sanpham/${id}`)
}
