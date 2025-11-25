using API.Entities;

namespace API.Intefaces
{
    public interface IMemeberRepository
    {
        void Update(Member member);

        Task<bool> SaveAllAsyn();

        Task<IReadOnlyList<Member>> GetMembersAsync();

        Task<Member?> GetMemberByIdAsync(string id);

        Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId);

         
    }
}