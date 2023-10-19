import React, { useEffect, useRef, useState } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CForm,
  CFormInput,
  CFormLabel,
  CModal,
  CModalBody,
  CModalHeader,
  CModalTitle,
  CRow,
  CSpinner,
  CTable,
  CTableBody,
  CTableDataCell,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CToast,
  CToastBody,
  CToastHeader,
  CToaster,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilPlus } from '@coreui/icons'
import { createProduct, deleteProduct, getProducts, updateProduct } from 'src/services/product'

const Tables = () => {
  const [products, setProducts] = useState([])
  const [modal, setModal] = useState({})
  const [loading, setLoading] = useState(false)
  const [productId, setProductId] = useState(0)
  const [product, setProduct] = useState({
    productID: 0,
    productName: '',
    productImage: '',
    unitPrice: 0,
    quantity: 0,
    discount: 0,
    category: {
      categoryID: '',
      categoryName: '',
    },
    supplier: {
      supplierID: '',
      supplierName: '',
    },
  })
  const [toast, addToast] = useState(0)
  const toaster = useRef()

  const exampleToast = (
    <CToast title="CoreUI for React.js">
      <CToastHeader closeButton>
        <svg
          className="rounded me-2"
          width="20"
          height="20"
          xmlns="http://www.w3.org/2000/svg"
          preserveAspectRatio="xMidYMid slice"
          focusable="false"
          role="img"
        >
          <rect width="100%" height="100%" fill="#007aff"></rect>
        </svg>
        <strong className="me-auto">CoreUI for React.js</strong>
        <small>7 min ago</small>
      </CToastHeader>
      <CToastBody>success</CToastBody>
    </CToast>
  )

  const handleDelete = async (productID) => {
    try {
      setLoading(true)

      await deleteProduct(Number(productID))
      getInitProduct()
      setModal({})
      setLoading(false)
      addToast(exampleToast)
    } catch (error) {
      setLoading(false)
    }
  }

  const getInitProduct = () => {
    getProducts().then((res) => {
      setProducts(res.data)
    })
  }

  const handleSubmit = async (e) => {
    try {
      e.preventDefault()
      setLoading(true)
      if (modal.type === 'create') {
        await createProduct(product)
      }
      if (modal.type === 'update') {
        await updateProduct(productId, product)
      }

      getInitProduct()
      setModal({})
      setLoading(false)
      addToast(exampleToast)
    } catch (error) {
      setLoading(false)
    }
  }

  useEffect(() => {
    getInitProduct()
  }, [])

  return (
    <CRow>
      {loading && <CSpinner color="primary" />}
      <CToaster ref={toaster} push={toast} placement="top-end" />

      <CModal size="lg" visible={modal.type ? true : false} onClose={() => setModal({})}>
        <CModalHeader>
          <CModalTitle>From product</CModalTitle>
          {loading && <CSpinner color="primary" />}
        </CModalHeader>
        <CModalBody>
          <CForm onSubmit={handleSubmit}>
            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Product ID</CFormLabel>
              <CFormInput
                type="number"
                value={product.productID}
                onChange={(e) => setProduct({ ...product, productID: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Product Name</CFormLabel>
              <CFormInput
                value={product.productName}
                onChange={(e) => setProduct({ ...product, productName: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Product image</CFormLabel>
              <CFormInput
                value={product.productImage}
                onChange={(e) => setProduct({ ...product, productImage: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Quantity</CFormLabel>
              <CFormInput
                value={product.quantity}
                onChange={(e) => setProduct({ ...product, quantity: e.target.value })}
                type="number"
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">unitPrice</CFormLabel>
              <CFormInput
                value={product.unitPrice}
                onChange={(e) => setProduct({ ...product, unitPrice: e.target.value })}
                type="number"
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">discount</CFormLabel>
              <CFormInput
                value={product.discount}
                onChange={(e) => setProduct({ ...product, discount: e.target.value })}
                type="number"
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Category Id</CFormLabel>
              <CFormInput
                value={product.category.categoryID}
                onChange={(e) =>
                  setProduct({
                    ...product,
                    category: { ...product.category, categoryID: e.target.value },
                  })
                }
              />
            </div>
            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Category Name</CFormLabel>
              <CFormInput
                value={product.category.categoryName}
                onChange={(e) =>
                  setProduct({
                    ...product,
                    category: { ...product.category, categoryName: e.target.value },
                  })
                }
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Supplier Id</CFormLabel>
              <CFormInput
                value={product.supplier.supplierID}
                onChange={(e) =>
                  setProduct({
                    ...product,
                    supplier: { ...product.supplier, supplierID: e.target.value },
                  })
                }
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Supplier Name</CFormLabel>
              <CFormInput
                value={product.supplier.supplierName}
                onChange={(e) =>
                  setProduct({
                    ...product,
                    supplier: { ...product.supplier, supplierName: e.target.value },
                  })
                }
              />
            </div>

            <CButton type="submit">{modal.type}</CButton>
          </CForm>
        </CModalBody>
      </CModal>
      <CCol xs={12}>
        <CButton className="my-2" onClick={() => setModal({ type: 'create' })}>
          <CIcon icon={cilPlus} className="me-2" />
          create
        </CButton>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Product Table</strong> <small>Basic Product table</small>
          </CCardHeader>
          <CCardBody>
            <p className="text-medium-emphasis small">Anh Long mào gà</p>

            <CTable>
              <CTableHead>
                <CTableRow>
                  <CTableHeaderCell scope="col">#</CTableHeaderCell>
                  <CTableHeaderCell scope="col">product name</CTableHeaderCell>
                  <CTableHeaderCell scope="col">quantity</CTableHeaderCell>
                  <CTableHeaderCell scope="col">category</CTableHeaderCell>
                  <CTableHeaderCell scope="col">supplier name</CTableHeaderCell>
                  <CTableHeaderCell scope="col">unit price</CTableHeaderCell>
                  <CTableHeaderCell scope="col">actions</CTableHeaderCell>
                </CTableRow>
              </CTableHead>
              <CTableBody>
                {products.map(
                  ({ productID, productName, quantity, supplier, unitPrice, category }, index) => (
                    <CTableRow key={index}>
                      <CTableHeaderCell scope="row">{productID}</CTableHeaderCell>
                      <CTableDataCell>{productName}</CTableDataCell>
                      <CTableDataCell>{quantity}</CTableDataCell>
                      <CTableDataCell>{supplier.supplierName}</CTableDataCell>
                      <CTableDataCell>{category.categoryName}</CTableDataCell>
                      <CTableDataCell>{unitPrice}</CTableDataCell>
                      <CTableDataCell className="flex">
                        <CButton
                          onClick={() => {
                            setModal({ type: 'update' })
                            setProduct({ ...products[index] })
                            setProductId(productID)
                          }}
                          color="success"
                        >
                          update
                        </CButton>
                        <CButton
                          onClick={() => handleDelete(productID)}
                          className="mx-1"
                          color="danger"
                        >
                          delete
                        </CButton>
                      </CTableDataCell>
                    </CTableRow>
                  ),
                )}
              </CTableBody>
            </CTable>
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default Tables
