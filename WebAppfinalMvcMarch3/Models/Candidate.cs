namespace WebAppfinalMvcMarch3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidate()
        {
            InterviewSchedules = new HashSet<InterviewSchedule>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int candidate_id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [Column(TypeName = "text")]
        public string resume { get; set; }

        [StringLength(100)]
        public string applied_position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; }
    }
}
