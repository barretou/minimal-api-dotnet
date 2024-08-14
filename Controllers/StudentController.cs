using ApiCrud.Api.Data;
using ApiCrud.Api.DTO_s;
using ApiCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Api.Controllers
{
	public static class StudentController
	{
		public static void AddController(this WebApplication app)
		{
			app.MapGet("students", async (AppDbContext context, CancellationToken ct) =>
			{
				var allStudents = await context
					.Students
					.Where(std => std.IsActive == true)
					.Select(std => new StudentDto(std.Id, std.Name)) // parecido com o map no js
					.ToListAsync(ct);

				if (allStudents.Count == 0)
					return Results.NoContent();

				
				return Results.Ok(allStudents);
			});

			app.MapPost("students", async (CreateStudentDto request, AppDbContext context, CancellationToken ct) =>
			{
				var newStudent = new StudentModel(request.Name);
				var studentAlreadyExists = await context.Students.AnyAsync(std => std.Name == request.Name);

				if (studentAlreadyExists)
					return Results.Conflict("Already exists!");


				await context.Students.AddAsync(newStudent, ct);
				await context.SaveChangesAsync(ct);

				var response = new StudentDto(newStudent.Id, newStudent.Name);
				return Results.Ok(response);
			});

			app.MapPut("students/{id:guid}", async (Guid id,UpdateStudentDto request, AppDbContext context, CancellationToken ct) =>
			{
				var studentToUpdate = await context.Students.SingleOrDefaultAsync(std => std.Id == id, ct);

				if(studentToUpdate == null)
					return Results.NotFound();

				studentToUpdate.UpdateName(request.Name);
				await context.SaveChangesAsync(ct);

				var response = new StudentDto(studentToUpdate.Id, studentToUpdate.Name);
				return Results.Ok(response);
			});

			app.MapDelete("students/{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
			{
				var studentToDelete = await context.Students.SingleOrDefaultAsync(std => std.Id == id, ct);

				if (studentToDelete == null)
					return Results.NotFound();

				studentToDelete.UpdateState(false);
				await context.SaveChangesAsync(ct);

				return Results.Ok();
			});
		}
	}
}
