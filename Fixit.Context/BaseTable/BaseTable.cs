using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixit.Context.BaseTable
{
    public interface IPrimaryKeyHolder
    {
        [Key]
        long Id { get; set; }
        bool isActive { get; set; }
    }

    public interface ITrackable
    {
        long CreatedBy { get; set; }
        long? UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        bool isDeleted { get; set; }
        bool isActive { get; set; }

    }

    public abstract class BaseTable : IPrimaryKeyHolder
    {
        public virtual long Id { get; set; }
        public virtual bool isActive { get; set; }
    }

    public abstract class BaseTrackable : BaseTable, ITrackable
    {
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long? UpdatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual bool isDeleted { get; set; }
    }
}
