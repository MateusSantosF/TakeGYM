
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TakeGYM.Models.Teacher;
using TakeGYM.Services.Repository.interfaces;

namespace TakeGYM.Facades
{
    public class TeacherFacade : ITeacherFacade
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public TeacherFacade(IGenericRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> FindByIdAsync(string teacherId)
        {
            return await _teacherRepository.Find(t => t.Id.Equals(teacherId));
        }

        public async Task<List<Teacher>> ListAllAsync()
        {
            return await _teacherRepository.ListAllAsync();
        }

        public async Task<bool> InsertAsync(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid().ToString();

            return await _teacherRepository.InsertAsync(teacher);
        }

        public async Task<bool> DeleteAsync(string teacherId)
        {
            return await _teacherRepository.DeleteAsync(teacherId);
        }

        public async Task<bool> UpdateAsync(Teacher teacher)
        {
            return await _teacherRepository.UpdateAsync(teacher);
        }
    }
}
