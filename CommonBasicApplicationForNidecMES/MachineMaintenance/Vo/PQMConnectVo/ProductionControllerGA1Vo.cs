using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class ProductionControllerGA1Vo : ValueObject
    {

        /// <summary>
        //
        /// from m_model table
        public int ModelId { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }


        // m_line
        public int LineId { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }

        public string Serno { get; set; }
        public DateTime InspectDate { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Data { get; set; }


        public string TableName { get; set; }

        //common
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public DataTable dt { get; set; }

        public List<ProductionControllerGA1Vo> volist = new List<ProductionControllerGA1Vo>();
    }
}
