using Microsoft.AspNetCore.Mvc;
using ProjectManagementOffice.Models;
using ProjectManagementOffice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IRepository repository;

        public MemberController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<DataController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> MemberList()
        {
            return await repository.SelectAll<Members>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMember(long id)
        {
            var model = await repository.SelectById<Members>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(long id, Members model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await repository.UpdateAsync<Members>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Members>> InsertMember([FromBody] Members model)
        {
            await repository.CreateAsync<Members>(model);
            return CreatedAtAction("GetMember", new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Members>> DeleteMember(long id)
        {
            var model = await repository.SelectById<Members>(id);

            if (model == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync<Members>(model);

            return model;
        }
    }
}
