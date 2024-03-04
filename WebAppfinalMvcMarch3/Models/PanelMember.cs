namespace WebAppfinalMvcMarch3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PanelMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PanelMember()
        {
            InterviewSchedules = new HashSet<InterviewSchedule>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int member_id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string position { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; }
    }
}
