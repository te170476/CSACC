using CSACC3.document.enums;
using System;
using System.Data;
using System.Data.OleDb;

namespace CSACC3.document.entity
{
    class Request
    {
        public Employee        Employee;
        public RequestDivision Division;
        public HolidayWorkPlan WorkPlan;
        public WeekdayRestPlan RestPlan;
        public Request(Employee employee, RequestDivision division, HolidayWorkPlan workPlan, WeekdayRestPlan restPlan)
        {
            this.Employee = employee;
            this.Division = division;
            this.WorkPlan = workPlan;
            this.RestPlan = restPlan;

            switch (division)
            {
                case RequestDivision.New:
                    break;
                case RequestDivision.Update:
                    break;
                case RequestDivision.Delete:
                    break;
            }
        }
        public override string ToString()
        {
            return $"request({Employee}, {Division}, {WorkPlan}, {RestPlan})";
        }
    }
}
