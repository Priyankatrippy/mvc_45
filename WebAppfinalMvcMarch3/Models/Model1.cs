using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebAppfinalMvcMarch3.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<InterviewSchedule> InterviewSchedules { get; set; }
        public virtual DbSet<PanelMember> PanelMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.resume)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.applied_position)
                .IsUnicode(false);

            modelBuilder.Entity<InterviewSchedule>()
                .Property(e => e.feedback)
                .IsUnicode(false);

            modelBuilder.Entity<PanelMember>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PanelMember>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<PanelMember>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<PanelMember>()
                .HasMany(e => e.InterviewSchedules)
                .WithOptional(e => e.PanelMember)
                .HasForeignKey(e => e.panel_member_id);
        }
    }
}
