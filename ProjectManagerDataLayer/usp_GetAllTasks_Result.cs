//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagerDataLayer
{
    using System;
    
    public partial class usp_GetAllTasks_Result
    {
        public int Task_ID { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public Nullable<int> Project_ID { get; set; }
        public string Task { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public string Parent_Task { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string UserName { get; set; }
    }
}
