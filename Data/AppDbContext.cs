using ApiCrud.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCrud.Api.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<StudentModel> Students {  get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
