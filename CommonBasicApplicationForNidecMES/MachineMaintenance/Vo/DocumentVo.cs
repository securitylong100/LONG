using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class DocumentVo : ValueObject
    {
        public int DocumentID { get; set; }
        public string DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string Department { get; set; }
        public string Group { get; set; }
        public string Revision { get; set; }
        public string DocumentType { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }

        /// <summary>
        //
        /// from m_model table
        public int ModelID { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }

        /// </summary>
        //common
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
    }
}