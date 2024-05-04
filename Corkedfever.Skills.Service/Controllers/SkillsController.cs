using Corkedfever.Skills.Business;
using Corkedfever.Skills.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corkedfever.Skills.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet("GetSkills")]
        [ProducesResponseType(typeof(List<SkillsModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSkills()
        {
            try
            {
                return Ok(_skillsService.GetSkills());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetSkill/{id}")]
        [ProducesResponseType(typeof(SkillsModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSkillbyId(int id)
        {
            try
            {
                return Ok(_skillsService.GetSkillbyId(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] SkillsModel skillModel)
        {
            try
            {
                _skillsService.CreateSkill(skillModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
