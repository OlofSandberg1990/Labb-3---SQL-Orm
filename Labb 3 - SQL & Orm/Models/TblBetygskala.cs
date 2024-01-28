using System;
using System.Collections.Generic;

namespace Labb_3___SQL___Orm.Models
{
    public partial class TblBetygskala
    {
        public TblBetygskala()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int BetygskalaId { get; set; }
        public string? BetygNamn { get; set; }
        public int? BetygPoäng { get; set; }

        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
