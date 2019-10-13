namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DefaultDbContext : DbContext
    {
        public DefaultDbContext()
            : base("name=DefaultDbContext")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<FunctionRoleRelationship> FunctionRoleRelationships { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Practice> Practices { get; set; }
        public virtual DbSet<PracticeType> PracticeTypes { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentFieldRelationship> StudentFieldRelationships { get; set; }
        public virtual DbSet<StudentNotificationRelationship> StudentNotificationRelationships { get; set; }
        public virtual DbSet<StudentPracticeRelationship> StudentPracticeRelationships { get; set; }
        public virtual DbSet<StudentSubjectRelationship> StudentSubjectRelationships { get; set; }
        public virtual DbSet<StudentTeacherRelationship> StudentTeacherRelationships { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherRoleRelationship> TeacherRoleRelationships { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TopicStudent> TopicStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StudentPracticeRelationship>()
                .HasMany(e => e.Reports)
                .WithOptional(e => e.StudentPracticeRelationship)
                .HasForeignKey(e => e.StudentPracticeID);

            modelBuilder.Entity<StudentPracticeRelationship>()
                .HasMany(e => e.TopicStudents)
                .WithOptional(e => e.StudentPracticeRelationship)
                .HasForeignKey(e => e.StudentPracticeID);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Phone)
                .IsFixedLength();
        }
    }
}
