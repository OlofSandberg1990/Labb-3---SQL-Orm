using System;
using System.Collections.Generic;

namespace Labb_3___SQL___Orm.Models
{
    public partial class TblPersonal
    {
        public TblPersonal()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int PersonalId { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Befattning { get; set; }

        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
