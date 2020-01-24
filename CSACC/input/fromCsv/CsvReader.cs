using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACC.input.fromCsv
{
    class CsvReader
    {
        public List<CsvLine> read(String path)
        {
            var lines = System.IO.File.ReadAllLines(path, Encoding.Default);
            var csvLines
                = lines.Skip(1)
                    .Select(line =>
                    {
                        var columns = line.Split(',');
                        return new CsvLine(columns);
                    });
            return csvLines.ToList();
        }
    }
}
