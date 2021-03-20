using AutoMapper;
using EmployeesAPI.Infrastructure;
using EmployeesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> repository;       
        public CategoryController(IRepository<Category> repository)
        {
            this.repository = repository;            
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                List<Category> categories = repository.GetAll();                
                if (categories == null)
                    return NotFound();
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory(int? id)
        {
            if (id == null)
                return BadRequest();
            try
            {
                Category category = repository.GetById(id);                
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory(Category  category)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int num = repository.Add(category);
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
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(category);
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
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
                return NotFound();
           try
            {
                Category category = repository.GetById(id);
                int num = repository.Delete(category.Id);
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
