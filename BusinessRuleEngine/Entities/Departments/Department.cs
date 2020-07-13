using System;

namespace BusinessRuleEngine.Entities.Departments
{
    public class Department
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DepartmentType DepartmentType { get; set; }
    }
}
