using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSACC
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    var toEntity = new input.fromCsv.ToEntityConverter();
                    var fromEntity = new gateway.FromEntityConverter();
                    var gateway = new gateway.Gateway();
                    args.ToList().ForEach(path =>
                        new input.fromCsv.CsvReader().read(path)
                            .SelectMany(it => toEntity.ToRequest(it))
                            .Select(it => fromEntity.FromRequest(it))
                            .ToList()
                            .ForEach(it => gateway.Apply(it))
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: "+e.StackTrace);
                }
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
