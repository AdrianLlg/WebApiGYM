﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.Entities.FKRelationships
{
    public class FKListEntity
    {
        public string PKTABLE_QUALIFIER { get; set; }
        public string PKTABLE_OWNER { get; set; }
        public string PKTABLE_NAME { get; set; }
        public string PKCOLUMN_NAME { get; set; }
        public string FKTABLE_QUALIFIER { get; set; }
        public string FKTABLE_OWNER { get; set; }
        public string FKTABLE_NAME { get; set; }
        public string FKCOLUMN_NAME { get; set; }
        public short KEY_SEQ { get; set; } 
        public short UPDATE_RULE { get; set; }
        public short DELETE_RULE { get; set; } 
        public string FK_NAME { get; set; }
        public string PK_NAME { get; set; }
        public short DEFERRABILITY { get; set; }


    }
}
