using API.Entities;
using API.Helpers;
using API.Intefaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LikesRepository(AppDbContext context) : ILikesRepository
    {
        public void AddLike(MemberLike like)
        {
            context.Likes.Add(like);
        }

        public void DeleteLike(MemberLike like)
        {
            context.Likes.Remove(like); 
        }

        public async Task<IReadOnlyList<string>> GetCurrentMemberLikeIds(string memberId)
        {
           return await  context.Likes
                .Where(x => x.SourceMemberId == memberId)
                .Select(x => x.TargetMemberId)
                .ToListAsync();
        }

        public async Task<MemberLike?> GetMemberLike(string SourceMemberId, string TargetMemberId)
        {
           return await context.Likes.FindAsync(SourceMemberId, TargetMemberId);


        }

        public async Task<PaginatedResult<Member>> GetMemberLikes(LikeParams likesParams)
        {
            var query = context.Likes.AsQueryable();
            IQueryable<Member> result;

            switch(likesParams.Predicate)
            {
                case "liked":
                    result = query
                        .Where(x => x.SourceMemberId == likesParams.MemberId)
                        .Select(x => x.TargetMember);
                    break;
                case "liekdBy":
                    result =  query
                            .Where(x => x.TargetMemberId == likesParams.MemberId)
                            .Select(x => x.SourceMember);
                        break;

                default: 
                    var likedIds = await GetCurrentMemberLikeIds(likesParams.MemberId);

                    result = query
                            .Where(x => x.TargetMemberId == likesParams.MemberId 
                                    && likedIds.Contains(x.SourceMemberId))
                            .Select( x=> x.SourceMember);
                        break;

            }

            return await PaginationHelper.CreateAsync(result ,
                    likesParams.PageNumber , likesParams.PageSize);
        }

 
    }
}