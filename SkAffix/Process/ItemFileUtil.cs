using SkAffix.Constants;
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
    public class ItemFileUtil
    {

        public static List<Item> CsvToItemList(string affixFileName)
        {
            return ItemFileUtil.DataTableToItemList(CT_CSV.Load_CSVData(FilePath.resourcePath + affixFileName, Encoding.UTF8));
        }
        public static List<Item> DataTableToItemList(DataTable dt)
        {
            List<System.Data.DataRow> rows = dt.AsEnumerable().ToList();
            return rows.Select((r, index) => new Item { id = index, Name = (string)r[0], NameEN = (string)r[1] }).ToList(); 
        }
        public static List<Affix> CsvToAffixList(string affixFileName)
        {
            return ItemFileUtil.DataTableToAffixList(CT_CSV.Load_CSVData(FilePath.resourcePath + affixFileName, Encoding.UTF8));
        }
        public static List<Affix> DataTableToAffixList(DataTable dt)
        {
            List<System.Data.DataRow> AffixRows = dt.AsEnumerable().ToList();
            return AffixRows.Select((r, index) => new Affix
            {
                id = index,
                Name = (string)r[0],
                Option = (string)r[1],
                IsRange = r[2].Equals("TRUE"),
                Min = CT_Converter.StringObjectToDouble(r[3]),
                Max = CT_Converter.StringObjectToDouble(r[4]),
                NameEN = (string)r[5],
                OptionEN = (string)r[6]
            }).ToList();
        }
    }
}
