using AutoMapper;
using EmployeesAPI.Infrastructure;
using EmployeesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IRepository<Course> repository;
        
        public CourseController(IRepository<Course> repository)
        {
            this.repository = repository;
            
        }

        [HttpGet]
        [Route("GetCourses")]
        public IActionResult GetCourses()
        {
            try
            {
                List<Course> courses = repository.GetAll();
                
                if (courses == null)
                    return NotFound();
                return Ok(courses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCourse")]
        public IActionResult GetCourse(int? id)
        {
            if (id == null)
                return BadRequest();
            try
            {
                Course course = repository.GetById(id);                
                if (course == null)
                    return NotFound();
                return Ok(course);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddCourse")]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int num = repository.Add(course);
                    if (num > 0)
                        return Ok(num);
                    else
                        return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("UpdateCourse")]
        public IActionResult UpdateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(course);
                    return Ok();
                }
                catch (Exception e)
                {
                    if (e.GetType().FullName == "DbUpdateConcurrencyException")
                        return NotFound();
                    return BadRequest();                    
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("DeleteCourse")]
        public IActionResult DeleteCourse(int? id)
        {
            if (id == null)
                return NotFound();
            try
            {
                Course course = repository.GetById(id);
                int num = repository.Delete(course.Id);
                if (num == 0)
                    return NotFound();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
