using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace Fixit.Context.DatabaseEntities.ReferenceEntities
{
    [TableName("UserType")]
   public class Ref_tbl_UserType : BaseTable.BaseTable
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
