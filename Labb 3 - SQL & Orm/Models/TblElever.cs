using System;
using System.Collections.Generic;

namespace Labb_3___SQL___Orm.Models
{
    public partial class TblElever
    {
        public TblElever()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int ElevId { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Personnummer { get; set; }
        public string? Klass { get; set; }

        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
