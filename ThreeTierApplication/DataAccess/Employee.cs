using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Employee
    {
        private int m_empId;
        private string m_empName;
        private string m_empDesignation;
        private int m_empService;
        public int EmployeeId
        {
            get
            {
                return m_empId;

            }
            set
            {
                m_empId = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return m_empName;

            }
            set
            {
                m_empName = value;
            }
        }
        public string EmployeeDesignation
        {
            get
            {
                return m_empDesignation;

            }
            set
            {
                m_empDesignation = value;
            }
        }

        public int EmployeeService
        {
            get
            {
                return m_empService;

            }
            set
            {
                m_empService = value;
            }
        }
        public Employee(int empId, string empName, string empDesignation, int empService)
        {
            this.EmployeeId = empId;
            this.EmployeeName = empName;
            this.EmployeeDesignation = empDesignation;
            this.EmployeeService = empService;
        }

    }
}
