using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace SoftwareConfigurationManagementDBApp
{
    [DataContract]
    class Groups
    {
        [DataMember]
        public String GroupName { get; set; }

        [DataMember]
        public Int32 GroupID { get; set; }
    }
}
