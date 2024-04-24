using Corkedfever.Common.Data;
using Corkedfever.Common.Data.DBModels;
using Corkedfever.Skills.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Corkedfever.Skills.Data
{
    public interface ISillsRepository
    {
        void CreateSkill(SkillsModel skillModel);
        SkillsModel GetSkillbyId(int id);
        List<SkillsModel> GetSkills();
    }
    public class SillsRepository : ISillsRepository
    {
        public readonly IDbContextFactory<CorkedFeverDataContext> _context;
        public SillsRepository(IDbContextFactory<CorkedFeverDataContext> context)
        {
            _context = context;
        }

        public void CreateSkill(SkillsModel skillModel)
        {
            using (var context = _context.CreateDbContext())
            {
                var newSkill = new Skill
                {
                    SkillName = skillModel.SkillName,
                    SkillDescription = skillModel.SkillDescription,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                context.Certification.Where(Certification => Certification.Id == 1).FirstOrDefault();
                context.Email.Where(Email => Email.Id == 1).FirstOrDefault();
                context.Message.Where(Message => Message.Id == 1).FirstOrDefault();
                context.Job.Where(Job => Job.Id == 1).FirstOrDefault();
                context.Education.Where(Education => Education.Id == 1).FirstOrDefault();
        

                context.Skill.Add(newSkill);
                context.SaveChanges();
            }
        }

        public SkillsModel GetSkillbyId(int id)
        {
            using (var context = _context.CreateDbContext())
            {
                var skill = context.Skill.Where(x => x.Id == id).FirstOrDefault();
                return new SkillsModel
                {
                    SkillName = skill.SkillName,
                    SkillDescription = skill.SkillDescription
                };
            }
        }

        public List<SkillsModel> GetSkills()
        {
            using (var context = _context.CreateDbContext())
            {
                var skills = context.Skill.Select(skill=> new SkillsModel
                {
                    SkillName = skill.SkillName,
                    SkillDescription = skill.SkillDescription
                }).ToList();

                return skills;
            }
        }
    }
}
