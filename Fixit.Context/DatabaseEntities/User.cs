using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;
using Fixit.Context.BaseTable;
using Fixit.Context.DatabaseEntities.ReferenceEntities;

namespace Fixit.Context
{
    [TableName("tbl_User")]
  public  class User  : BaseTrackable
    {
        public string UserName { get; set; }
        public string  Email_address { get; set; }
        public string Password { get; set; }
        [ForeignKey("UserType")]
        public long UserTypeId { get; set; }
        public virtual Ref_tbl_UserType UserType { get; set; }

    }

}
