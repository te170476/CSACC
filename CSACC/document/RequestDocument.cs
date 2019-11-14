using System;
using System.Collections.Generic;
using System.Data.OleDb;
using jp.jc_21.No170476.CSACC.document.entity;

namespace jp.jc_21.No170476.CSACC.document
{
    class RequestDocument
    {
        public Employee   Writer;
        public Department Department;
        public DateTime   Date;
        public List<Request> Requests;
        public RequestDocument(Employee writer, Department department, DateTime date, List<Request> requests)
        {
            this.Writer     = writer;
            this.Department = department;
            this.Date       = date;
            this.Requests   = requests;
        }
        public override string ToString()
        {
            return $"document( writer = {Writer}, department = {Department}, date = {Date}, requests = {Requests} )";
        }

        public int GetId(OleDbConnection connection)
        {
            var writerId     = Writer.GetId(connection);
            var departmentId = Department.GetId(connection);

            var order = $"SELECT id FROM document WHERE writer_id = {writerId} and department_id = {departmentId} and `date` = #{Date}#";
            var command = new OleDbCommand(order, connection);
            var orderResult = command.ExecuteScalar();
            if (orderResult == null)
            {
                Insert(connection, writerId, departmentId);
                return GetId(connection);
            }
            return (int)orderResult;
        }
        private void Insert(OleDbConnection connection, int writerId, int departmentId)
        {
            var insertOrder = new SQLBuilder.Insert("document (writer_id, department_id, `date`)")
                                            .add(writerId)
                                            .add(departmentId)
                                            .add(Date)
                                            .build(connection);
            insertOrder.ExecuteNonQuery();
        }
    }
}
