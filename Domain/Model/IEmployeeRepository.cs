﻿namespace MyFirstAPI.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> Get(int pageNumber, int pageQuantity);

        Employee? GetEmployeeById(int id);

    }
}
