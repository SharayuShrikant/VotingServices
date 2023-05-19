using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VotingService.Models;

namespace VotingService.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer("DefaultConnection"));
        }

        public DbSet<UserModel> Users {get; set;}
        public DbSet<PollModel> Polls {get; set;}
        public DbSet<QueryModel> Queries {get; set;}
        public DbSet<SolutionModel> Solutions {get; set;}
        public DbSet<ResponseModel> Responses {get; set;}
        public DbSet<PollQueryModel> PollQueries { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //============================= SolutionModel =============================
            modelBuilder.Entity<SolutionModel>()
                .HasOne(v => v.Query)
                .WithMany(u => u.Solutions)
                .HasForeignKey(v => v.QueryId)
                .OnDelete(DeleteBehavior.Cascade);

            //============================= PollQueryModel =============================

            modelBuilder.Entity<PollQueryModel>()
                .HasOne(p => p.Poll)
                .WithMany(p=>p.PollQueries)
                .HasForeignKey(p=>p.PollId)
                .OnDelete(DeleteBehavior.Cascade); ;

            modelBuilder.Entity<PollQueryModel>()
                .HasOne(p => p.Query)
                .WithMany(p => p.PollQueries)
                .HasForeignKey(p => p.QueryId)
                .OnDelete(DeleteBehavior.Cascade); ;

            //============================= PollQueryModel =============================

            modelBuilder.Entity<ResponseModel>()
                .HasOne(p => p.Query)
                .WithMany()
                .HasForeignKey(p => p.QueryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ResponseModel>()
                .HasOne(p => p.Poll)
                .WithMany()
                .HasForeignKey(p => p.PollId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ResponseModel>()
                .HasOne(p => p.Solution)
                .WithMany()
                .HasForeignKey(p => p.SolutionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ResponseModel>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //============================= PollQueryModel =============================



            base.OnModelCreating(modelBuilder);
        }
    }
}
