using Corkedfever.Skills.Data.Models;
using Corkedfever.Skills.Data;
namespace Corkedfever.Skills.Business
{
    public interface ISkillsService
    {
        void CreateSkill(SkillsModel skillModel);
        SkillsModel GetSkillbyId(int id);
        List<SkillsModel> GetSkills();
    }
    public class SkillsService : ISkillsService
    {
        public readonly ISillsRepository _sillsRepository;
        public SkillsService(ISillsRepository sillsRepository)
        {
            _sillsRepository = sillsRepository;
        }
        public void CreateSkill(SkillsModel skillModel)
        {
            _sillsRepository.CreateSkill(skillModel);
        }

        public SkillsModel GetSkillbyId(int id)
        {
            return _sillsRepository.GetSkillbyId(id);
        }

        public List<SkillsModel> GetSkills()
        {
            return _sillsRepository.GetSkills();
        }
    }
}
