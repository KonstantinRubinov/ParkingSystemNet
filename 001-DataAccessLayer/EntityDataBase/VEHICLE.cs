//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingSystem.EntityDataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class VEHICLE
    {
        public string vehicleNumber { get; set; }
        public string vehicleManufacturer { get; set; }
        public string vehicleColor { get; set; }
        public string vehicleOwnerId { get; set; }
    
        public virtual PERSON PERSON { get; set; }
    }
}
