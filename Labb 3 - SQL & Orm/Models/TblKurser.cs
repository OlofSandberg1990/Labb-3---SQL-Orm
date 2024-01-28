using System;
using System.Collections.Generic;

namespace Labb_3___SQL___Orm.Models
{
    public partial class TblKurser
    {
        public TblKurser()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int KursId { get; set; }
        public string? Kursnamn { get; set; }

        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
