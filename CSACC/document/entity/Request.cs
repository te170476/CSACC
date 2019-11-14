﻿using System;
using System.Data.OleDb;
using jp.jc_21.No170476.CSACC.document.enums;
using jp.jc_21.No170476.CSACC.extensions;

namespace jp.jc_21.No170476.CSACC.document.entity
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
            return $"request( employee = {Employee}, division = {Division}, work_plan = {WorkPlan}, rest_plan = {RestPlan} )";
        }


        public void ToDatabase(OleDbConnection connection, int documentId)
        {
            var employeeId = Employee.GetId(connection);
            var divisionName = Enum<RequestDivision>.DescriptionValueDictionary[Division];

            Insert(connection, documentId, employeeId, divisionName);
            var requestId = GetId(connection, documentId, employeeId, divisionName);

            WorkPlan.Insert(connection, requestId);
            RestPlan.Insert(connection, requestId);
        }
        private int GetId(OleDbConnection connection, int documentId, int employeeId, String divisionName)
        {
            var order = $"SELECT id FROM request WHERE document_id = {documentId} and employee_id = {employeeId} and division = '{divisionName}'";
            var command = new OleDbCommand(order, connection);
            var orderResult = command.ExecuteScalar();
            //if (orderResult == null)
            //{
            //    Insert(connection);
            //    return GetId(connection);
            //}
            return (int)orderResult;
        }
        private void Insert(OleDbConnection connection, int documentId, int employeeId, String divisionName)
        {
            var insertOrder = new SQLBuilder.Insert("request (document_id, employee_id, division)")
                                            .add(documentId)
                                            .add(employeeId)
                                            .add(divisionName)
                                            .build(connection);
            insertOrder.ExecuteNonQuery();
        }
    }
}