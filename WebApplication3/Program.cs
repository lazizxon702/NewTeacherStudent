using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using WebApplication3.Interface;
using WebApplication3.Services;
using WebApplication3.Data;


var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddControllers();                       
 builder.Services.AddEndpointsApiExplorer();             
 builder.Services.AddSwaggerGen();                
   
 builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

 builder.Services.AddScoped<IStudentSubjectService, StudentSubjectService>();
 builder.Services.AddScoped<ITeacherService, TeacherService>();
 builder.Services.AddScoped<IStudentService, StudentService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                                    
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); 
}

app.UseHttpsRedirection();
  app.UseAuthorization(); 

  app.MapControllers();                                     

  app.Run();