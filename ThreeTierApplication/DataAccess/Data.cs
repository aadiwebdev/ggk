using System;
using System.Collections.Generic;

namespace DataAccess
{
    public  class Data
    {
        public  List<Employee> m_data = new List<Employee>();

        /// <summary>
        /// Inserting employee into the database
        /// </summary>
        /// <param name="emp"></param>   
        public  void Save(Employee emp)
        {
            m_data.Add(emp);
        }
        /// <summary>
        /// retrieving employees from the database
        /// </summary>
        /// <returns></returns>
        public  List<Employee> Fetch()
        {
            return m_data;
        }
        /// <summary>
        /// retrieving employee details from the database by passing employee Id as parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  Employee FindById(int id)
        {
            for (int index = 0; index < m_data.Count; index++)
            {
                if (m_data[index].EmployeeId == id)
                {
                    return m_data[index];
                }
            }
            return null;
        }
        
    }

}