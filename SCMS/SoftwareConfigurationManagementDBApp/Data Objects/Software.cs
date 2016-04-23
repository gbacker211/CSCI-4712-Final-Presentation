using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SoftwareConfigurationManagementDBApp
{
    /// <summary>
    ///     Class Software is for storing data of a software
    ///     system to store into the database.
    /// </summary>
    
    [DataContract]
    public class Software
    {
        // Data Types // =================================== //
        [DataMember]
        public int Software_ID { get; set; }

        [DataMember]
        public string SoftwareName { get; set; }

        [DataMember]
        public string Owner { get; set; }

        [DataMember]
        public string Group { get; set; }

        [DataMember]
        public string ResponsibleEngineer { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Classification { get; set; }

        [DataMember]
        public string DesignAuthority { get; set; }

        [DataMember]
        public string SystemName { get; set; }
        // ================================================= //
    }
}
