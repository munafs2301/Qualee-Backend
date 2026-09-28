using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QualeeBackend.Domain.Interfaces;
using QualeeBackend.Infrastructure.Persistence;
using QualeeBackend.Infrastructure.Repositories;
using QualeeBackend.Infrastructure.Services;

namespace QualeeBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
        {
            // EF Core
            services.AddDbContext<QualeeContext>(opts =>
            opts.UseSqlServer(config.GetConnectionString("DefaultConnection"),
            sql => sql.MigrationsAssembly(
            typeof(QualeeContext).Assembly.FullName)));
            // Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // JWT
            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
