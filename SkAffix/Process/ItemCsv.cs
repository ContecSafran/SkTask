using SkAffix.Dto;
using SkUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkAffix.Process
{
    public class ItemCsv
    {
        public List<Item> getItems()
        {
            DataTable dt = CT_CSV.Load_CSVData("../../resource/Item/flask.csv", Encoding.UTF8);

            List<System.Data.DataRow> rows = dt.AsEnumerable().ToList();
            return rows.Select((r,index) =>  new Item { id = index, name = (string)r[0] }).ToList();
        }
    }
}
