using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace Fixit.Context.DatabaseEntities.ReferenceEntities
{
    [TableName("Category")]
    public class Ref_tbl_Category : BaseTable.BaseTable
    {
        public string Name { get; set; }
    }
}
