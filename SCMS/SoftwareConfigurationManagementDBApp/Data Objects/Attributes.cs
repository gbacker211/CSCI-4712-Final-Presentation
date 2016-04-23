using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SoftwareConfigurationManagementDBApp
{
    /// <summary>
    ///     Parent class Attributes is for storing
    ///     data into the database. Child classes:
    ///     SoftwareDoc, CI, CIDoc
    /// </summary>
    [DataContract]
     public class Attributes
    {
        // Data Types // ============================ //
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Revision { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Location { get; set; }
        // ========================================== //
    }

    /// <summary>
    ///     Child Classes
    /// </summary>

    public class SoftwareDoc : Attributes {}

    public class CI : Attributes {}

    public class CIDocs : Attributes {}
}
