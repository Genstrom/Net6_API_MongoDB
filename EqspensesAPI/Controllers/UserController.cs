using System.Net.Http.Headers;
using EqspensesAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Firebase.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EqspensesAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AuthController : Controller
{
    // private IUserService _userService;
    //
    //
    // public AuthController(IUserService userService)
    // {
    //     _userService = userService;
    // }
    //
    // [HttpGet]
    //     public async Task<IActionResult> GetStudents()
    //     {
    //         var result = await _userService.Students.GetStudentsAsync();
    //         if (result == null) return NotFound();
    //         var students = _studentViewModelMapper.Map(result);
    //
    //         return Ok(students);
    //     }
    //
    //     [HttpGet("{courseNo}")]
    //     public async Task<IActionResult> GetStudentsByCourseNo(string courseNo)
    //     {
    //         var course = await _userService.Courses.GetCourseByCourseNoAsync(courseNo);
    //         var students = await _userService.Students.GetStudentsByCourseIdAsync(course.Id);
    //         var studentsVM = _studentViewModelMapper.Map(students);
    //
    //         return Ok(studentsVM);
    //     }
    //
    //     [HttpPost("add")]
    //
    //     public async Task<IActionResult> AddCoursesToStudent(AddCourseToStudentViewModel model)
    //     {
    //         var student = await _userService.Students.GetStudentByEmail(model.Email);
    //         var course = await _userService.Courses.GetCourseByIdAsync(model.Id);
    //         var course_Student = new Course_Student()
    //         {
    //             CourseId = course.Id,
    //             StudentId = student.Id,
    //         };
    //         var courseStudent = await _unitOfWork.CourseStudents.CheckIfCourseStudentExists(course_Student);
    //         if (courseStudent == null)
    //         {
    //             await _unitOfWork.CourseStudents.AddAsync(course_Student);
    //             if (await _unitOfWork.Complete()) return StatusCode(201);
    //         }
    //         
    //         return StatusCode(500, "That user is already registered on that course");
    //     }
    //
    //     [HttpPost]
    //     public async Task<IActionResult> AddStudent(AddStudentViewModel model)
    //     {
    //          if (_unitOfWork.Students.CheckForDuplicate(model.Email)) return StatusCode(409, " A user with that email already exists!");
    //
    //         var student = _studentMapper.Map(model);
    //         await _unitOfWork.Students.AddAsync(student);
    //         if (await _unitOfWork.Complete()) return StatusCode(201);
    //         return StatusCode(409, "The Student was not added");
    //     }
    //
    //     [HttpPut("{id}")]
    //     public async Task<IActionResult> UpdateStudentAsync(int id, StudentViewModel model)
    //     {
    //         var student = await _unitOfWork.Students.GetStudentByStudentIdAsync(id);
    //         student = _studentMapper.Map(model, student);
    //
    //         _unitOfWork.Students.Update(student);
    //
    //         var result = await _unitOfWork.Complete();
    //
    //         return NoContent();
    //     }
    //
    //     [HttpGet("find/{email}")]
    //     public async Task<IActionResult> GetStudentByEmail(string email)
    //     {
    //         var student = await _unitOfWork.Students.GetStudentByEmail(email);
    //
    //         if (student == null) return NotFound();
    //         var model = _studentViewModelMapper.Map(student);
    //
    //
    //         return Ok(model);
    //     }
    //
    //     [HttpDelete("{studentId}")]
    //     public async Task<IActionResult> DeleteStudenAsync(int studentId)
    //     {
    //         var student = await _unitOfWork.Students.GetStudentByStudentIdAsync(studentId);
    //         if (student == null) return NotFound();
    //
    //         _unitOfWork.Students.Delete(student);
    //         var result = _unitOfWork.Complete();
    //         return NoContent();
    //     }
    // }
    
}
