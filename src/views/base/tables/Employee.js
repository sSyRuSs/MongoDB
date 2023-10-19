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
import { createEmployye, deleteEmployye, getEmployyes, updateEmployye } from 'src/services/employee'

const Employee = () => {
  const [employees, setEmployees] = useState([])

  const [modal, setModal] = useState({})
  const [loading, setLoading] = useState(false)
  const [employeeId, setEmployeeId] = useState(0)
  const [employee, setEmployee] = useState({
    employeeID: '',
    name: '',
    email: '',
    gender: '',
    age: 0,
    password: '',
    role: {
      roleID: '',
      roleName: '',
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

  const handleDelete = async (employeeId) => {
    try {
      setLoading(true)

      await deleteEmployye(employeeId)
      getInitProduct()
      setModal({})
      setLoading(false)
      addToast(exampleToast)
    } catch (error) {
      setLoading(false)
    }
  }

  const getInitProduct = () => {
    getEmployyes().then((res) => {
      setEmployees(res.data)
    })
  }

  const handleSubmit = async (e) => {
    try {
      e.preventDefault()
      setLoading(true)
      if (modal.type === 'create') {
        await createEmployye(employee)
      }
      if (modal.type === 'update') {
        await updateEmployye(employeeId, employee)
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
              <CFormLabel htmlFor="exampleFormControlInput1">employee ID</CFormLabel>
              <CFormInput
                type="number"
                value={employee.employeeID}
                onChange={(e) => setEmployee({ ...employee, employeeID: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">Name</CFormLabel>
              <CFormInput
                value={employee.name}
                onChange={(e) => setEmployee({ ...employee, name: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">gender</CFormLabel>
              <CFormInput
                value={employee.gender}
                onChange={(e) => setEmployee({ ...employee, gender: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">password</CFormLabel>
              <CFormInput
                value={employee.password}
                onChange={(e) => setEmployee({ ...employee, password: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">age</CFormLabel>
              <CFormInput
                value={employee.age}
                onChange={(e) => setEmployee({ ...employee, age: e.target.value })}
                type="number"
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">email</CFormLabel>
              <CFormInput
                value={employee.email}
                onChange={(e) => setEmployee({ ...employee, email: e.target.value })}
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">role Id</CFormLabel>
              <CFormInput
                value={employee.role.roleID}
                onChange={(e) =>
                  setEmployee({ ...employee, role: { ...employee.role, roleID: e.target.value } })
                }
              />
            </div>

            <div className="mb-3">
              <CFormLabel htmlFor="exampleFormControlInput1">role name</CFormLabel>
              <CFormInput
                value={employee.role.roleName}
                onChange={(e) =>
                  setEmployee({ ...employee, role: { ...employee.role, roleName: e.target.value } })
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
                  <CTableHeaderCell scope="col">email</CTableHeaderCell>
                  <CTableHeaderCell scope="col">name</CTableHeaderCell>
                  <CTableHeaderCell scope="col">gender</CTableHeaderCell>
                  <CTableHeaderCell scope="col">roleId</CTableHeaderCell>
                  <CTableHeaderCell scope="col">role name</CTableHeaderCell>
                  <CTableHeaderCell scope="col">actions</CTableHeaderCell>
                </CTableRow>
              </CTableHead>
              <CTableBody>
                {employees.map((employee, index) => (
                  <CTableRow key={index}>
                    <CTableHeaderCell scope="row">{employee.employeeID}</CTableHeaderCell>
                    <CTableDataCell>{employee.email}</CTableDataCell>
                    <CTableDataCell>{employee.name}</CTableDataCell>
                    <CTableDataCell>{employee.gender}</CTableDataCell>
                    <CTableDataCell>{employee.role?.roleID}</CTableDataCell>
                    <CTableDataCell>{employee.role?.roleName}</CTableDataCell>
                    <CTableDataCell className="flex">
                      <CButton
                        onClick={() => {
                          setModal({ type: 'update' })
                          setEmployee({ ...employees[index] })
                          setEmployeeId(employee.employeeID)
                        }}
                        color="success"
                      >
                        update
                      </CButton>
                      <CButton
                        onClick={() => handleDelete(employee.employeeID)}
                        className="mx-1"
                        color="danger"
                      >
                        delete
                      </CButton>
                    </CTableDataCell>
                  </CTableRow>
                ))}
              </CTableBody>
            </CTable>
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default Employee
