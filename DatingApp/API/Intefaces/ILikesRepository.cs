using API.Entities;
using API.Helpers;

namespace API.Intefaces
{
    public interface ILikesRepository
    {
        Task<MemberLike?> GetMemberLike(string SourceMemberId, string TargetMemberId);   

        Task<PaginatedResult<Member>> GetMemberLikes(LikeParams likesparams); 

        Task<IReadOnlyList<string>> GetCurrentMemberLikeIds(string memberId);

        void DeleteLike(MemberLike like);

        void AddLike(MemberLike like);  

    }
}