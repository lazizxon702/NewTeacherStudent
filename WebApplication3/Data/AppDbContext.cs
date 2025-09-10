using Microsoft.EntityFrameworkCore;
using StudentTeacher.Student;
using WebApplication3.model;

namespace WebApplication3.Data;

public class AppDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    public DbSet<StudentsSubjects> StudentsSubjects { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public AppDbContext() { }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Student>(entity =>
        {
          entity.ToTable("Talabala");
          entity.HasKey(i => i.Id);
          entity.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FullName");
            
         entity.Property(s => s.Gender)
              .IsRequired()
              .HasMaxLength(10)
              .HasColumnName("gender");

         entity.Property(s => s.DateOfBirth)
              .IsRequired()
              .HasColumnName("birth_date");

         entity.Property(s => s.GradeLevel)
              .HasDefaultValue(1)
              .HasColumnName("grade_level");

         entity.Property(s => s.CityId)
              .HasColumnName("city_id");

         entity.Property(s => s.DepartmentId)
              .HasColumnName("department_id");

         entity.HasOne(s => s.City)
              .WithMany(c => c.Students)
              .HasForeignKey(s => s.CityId)
              .OnDelete(DeleteBehavior.Restrict);                                                                       
                                                                                                                        
         entity.HasOne(s => s.Departments)                                
              .WithMany(d => d.Students)
              .HasForeignKey(s => s.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);
        });

     modelBuilder.Entity<Teacher>(entity =>
     {
        entity.ToTable("O'qituvchi");

        entity.HasKey(t => t.Id);

        entity.Property(t => t.Name)
              .IsRequired()
              .HasMaxLength(100)
              .HasColumnName("full_name");
        
       entity.Property(t => t.Gender)
              .IsRequired()
              .HasMaxLength(10)
              .HasColumnName("gender");

        entity.Property(t => t.DateOfBirth)
              .IsRequired()
              .HasColumnName("birth_date");
     } );

  
     modelBuilder.Entity<Subject>( entity =>
      {
        entity.ToTable("Subjects");

        entity.HasKey(s => s.Id);

        entity.Property(s => s.Id).HasColumnName("subject_id");

        entity.Property(s => s.Name)
              .IsRequired()
              .HasMaxLength(100)
              .HasColumnName("subject_name");
      });

     modelBuilder.Entity<City>(entity =>
     {
        entity.ToTable("Cities");

        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id).HasColumnName("city_id");

        entity.Property(c => c.Name)
              .IsRequired()
              .HasMaxLength(100)
              .HasColumnName("city_name");
     });
    
     modelBuilder.Entity<Departments>(entity =>
     {
        entity.ToTable("Departments");

        entity.HasKey(d => d.Id);

        entity.Property(d => d.Id).HasColumnName("department_id");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("department_name");
     });


     modelBuilder.Entity<StudentsSubjects>(entity =>
     {
           entity.HasKey(e => new { e.StudentId, e.SubjectId });

           entity.HasOne(e => e.Student)
                 .WithMany(s => s.StudentsSubjects)
                 .HasForeignKey(e => e.StudentId);

           entity.HasOne(e => e.Subject)
                 .WithMany(s => s.StudentsSubjects)
                 .HasForeignKey(e => e.SubjectId);
     }); 

     modelBuilder.Entity<TeacherSubject>(entity =>
     {
           entity.HasKey(e => new { e.TeacherId, e.SubjectId });

           entity.HasOne(e => e.Teacher)
                 .WithMany(t => t.TeacherSubjects)
                 .HasForeignKey(e => e.TeacherId);

           entity.HasOne(e => e.Subject)
                 .WithMany(s => s.TeacherSubjects)
                 .HasForeignKey(e => e.SubjectId);
     });

     modelBuilder.Entity<City>().HasData(
           new City { Id = 1, Name = "Toshkent" },
           new City { Id = 2, Name = "Samarqand" },
           new City { Id = 3, Name = "Buxoro" },
           new City { Id = 4, Name = "Andijon" },
           new City { Id = 5, Name = "Xorazm" },
           new City { Id = 6, Name = "Namangan" },
           new City { Id = 7, Name = "Farg‘ona" },
           new City { Id = 8, Name = "Qashqadaryo" },
           new City { Id = 9, Name = "Surxondaryo" },
           new City { Id = 10, Name = "Jizzax" },
           new City { Id = 11, Name = "Sirdaryo" },
           new City { Id = 12, Name = "Navoiy" }
     );


     modelBuilder.Entity<Departments>().HasData(
           new Departments { Id = 1, Name = "Information" },
           new Departments { Id = 2, Name = "Fizika" },
           new Departments { Id = 3, Name = "Biology" },
           new Departments { Id = 4, Name = "Geography" },
           new Departments { Id = 5, Name = "Kimyo" },
           new Departments { Id = 6, Name = "English" }
     );

     modelBuilder.Entity<Subject>().HasData(
           new Subject { Id = 1, Name = "mathematica" },
           new Subject { Id = 2, Name = "Fizika" },
           new Subject { Id = 3, Name = "Biology" },
           new Subject { Id = 4, Name = "Geography" },
           new Subject { Id = 5, Name = "Kimyo" },
           new Subject { Id = 6 , Name = "English"}
     );
    }        
}