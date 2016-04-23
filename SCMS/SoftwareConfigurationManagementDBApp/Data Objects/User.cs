using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SoftwareConfigurationManagementDBApp
{
    /// <summary>
    ///     Class User is for storing data of an user to store
    ///     into the database.
    /// </summary>
    [DataContract]
    public class User
    {
        // Data Types for User // ========================== //
        [DataMember]
        public int User_ID { get; set; }

        [DataMember]
        public string Fname { get; set; }

        [DataMember]
        public string Lname { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public Int32 GroupID { get; set; }

        [DataMember]
        public int AccessGroup { get; set; }
        // ================================================= //
    }
}
