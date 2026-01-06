using API.Entities;
using API.Helpers;

namespace API.Intefaces
{
    public interface IMemeberRepository
    {
        void Update(Member member);


        Task<PaginatedResult<Member>> GetMembersAsync(MemberParams memberParams);

        Task<Member?> GetMemberByIdAsync(string id);


        Task<IEnumerable<Photo>> GetPhotosForMemberAsync(string userId, bool isCurrentUser);
        

        Task<Member?> GetMemberForUpdate(string id);
         
    }
}