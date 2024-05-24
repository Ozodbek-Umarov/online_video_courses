using OnlineVideoCourse.Aplication.Common.Utils;
using OnlineVideoCourse.Aplication.DTOs.SubjectDTOs;

namespace OnlineVideoCourse.Aplication.Interfaces;

public interface ISubjectService
{
    Task<SubjectDto> GetByIdAsync(int id);
    Task<IEnumerable<SubjectDto>> GetAllAsync(PaginationParams @params);
    Task UpdateAsync(int id, SubjectDto categoryDto);
    Task DeleteAsync(int id);
    Task CreateAsync(SubjectDto categoryDto);
}
