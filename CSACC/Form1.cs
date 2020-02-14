using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jp.jc_21.No170476.CSACC.document;
using jp.jc_21.No170476.CSACC.document.entity;
using jp.jc_21.No170476.CSACC.extensions;

namespace jp.jc_21.No170476.CSACC
{
    /*
     * TODO: DBの設計
     * リクエスト と [出勤/休み]予定 の対応関係 
     */
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CSDB.accdb";

        public Form1()
        {
            InitializeComponent();

            connection = databaseConnection();
            var requestDocuments = readCSV();
            foreach (RequestDocument document in requestDocuments)
            {
                Console.WriteLine(document);
                var documentId = document.GetId(connection);
                foreach (Request request in document.Requests)
                {
                    Console.WriteLine(request);
                    request.ToDatabase(connection, documentId);
                }
            }
        }

        private IEnumerable<RequestDocument> readCSV()
        {
            var lines = System.IO.File.ReadAllLines("Input.csv", Encoding.Default);
            var parser = new DocumentParser();
            return lines.Select(line =>
                {
                    var cells = line.Split(',');
                    return parser.parse(cells);
                });
        }

        private OleDbConnection databaseConnection()
        {
            var connection = new OleDbConnection(strAccessConn);
            Result result = connection.Connect();
            label1.Text = result.Message;
            //if (result is Failure) return;

            return connection;
        }
    }

    class Option<A>
    {
        public A Get = default(A);
        public Boolean isEmpty = true;
        public Option(A value)
        {
            Get = value;
            isEmpty = false;
        }
        public Option() { }
    }

    //class Maybe<A>
    //{
    //    public Boolean IsExcepted = false;
    //    public A Result = default(A);
    //
    //    public Maybe(Func<A> getValueAction, Action<Exception> exceptedAction)
    //    {
    //        try
    //        {
    //            Result = getValueAction();
    //        }
    //        catch(Exception exception)
    //        {
    //            exceptedAction(exception);
    //            IsExcepted = true;
    //        }
    //    }
    //}
    // useage:
    ////Maybe<OleDbConnection> maybeConnection = connect(strAccessConn);
    ////if (maybeConnection.IsExcepted) return;
    ////
    ////private Maybe<OleDbConnection> econnect(string connectionString)
    ////{
    ////    return new Maybe<OleDbConnection>(
    ////        ()          => new OleDbConnection(connectionString)
    ////       ,(exception) => label1.Text = "Error: Failed connection. " + exception.Message
    ////        );
    ////}

    //class Either<A>
    //{
    //    public Exception left = null;
    //    public A right;
    //    public Boolean isRight = false;
    //    public Boolean isLeft = false;
    //    public Either(A value)
    //    {
    //        right = value;
    //        isRight = true;
    //    }
    //    public Either(Exception exception)
    //    {
    //        left = exception;
    //        isLeft = true;
    //    }
    //}
}
