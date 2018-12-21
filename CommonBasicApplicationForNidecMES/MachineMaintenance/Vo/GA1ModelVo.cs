using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
    public class GA1ModelVo : ValueObject
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

        //from main a90
        public int A90Id { get; set; }
        public string A90Model { get; set; }
        public string A90Line { get; set; }
        public string A90Barcode { get; set; }
        public string A90ThurstStatus { get; set; }
        public string A90NoiseStatus { get; set; }
        public string A90OQCStatus { get; set; }
        public string A90OQCData { get; set; }
        public bool A90Shipping { get; set; }

        public DateTime DateTimeTo { get; set; }
        public DateTime DateTimeFrom { get; set; }

        public string STT { get; set; }
        public bool DaTa { get; set; }
        //common
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }

        public List<GA1ModelVo> volist = new List<GA1ModelVo>();
    }
}
