using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHODNO
{
    public class Employee 
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string address;
        private int workNumber;
        private double salary;


        public Employee()
        {

        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public int WorkNumber
        {
            get { return this.workNumber; }
            set { this.workNumber = value; }
        }

        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }


        public string PrintEmployeeStandard()
        {
            return $"Name: {this.FirstName} {this.MiddleName} {this.LastName}; Address: {this.Address}; Work Number: {this.workNumber}";
        }
        public string PrintEmployeeAdmin()
        {
            return $"Name: {this.FirstName} {this.MiddleName} {this.LastName}; Address: {this.Address}; Work Number: {this.workNumber}; Salary: {this.salary} lv.";
        }
    }
}