using System;
using System.Collections.Generic;

namespace Labb_3___SQL___Orm.Models
{
    public partial class TblBetyg
    {
        public int BetygId { get; set; }
        public int? KursId { get; set; }
        public int? BetygskalaId { get; set; }
        public int? ElevId { get; set; }
        public int? PersonalId { get; set; }
        public DateTime? DatumFörBetyg { get; set; }

        public virtual TblBetygskala? Betygskala { get; set; }
        public virtual TblElever? Elev { get; set; }
        public virtual TblKurser? Kurs { get; set; }
        public virtual TblPersonal? Personal { get; set; }
    }
}
