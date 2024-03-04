namespace WebAppfinalMvcMarch3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterviewSchedule")]
    public partial class InterviewSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int schedule_id { get; set; }

        public int? candidate_id { get; set; }

        public int? panel_member_id { get; set; }

        public DateTime? interview_date { get; set; }

        [Column(TypeName = "text")]
        public string feedback { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual PanelMember PanelMember { get; set; }
    }
}
