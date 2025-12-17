using API.Dtos;
using API.Entities;
using API.Helpers;

namespace API.Intefaces
{
    public interface IMessageRepository
    {
         void AddMessage(Message message);

         void DeleteMessage(Message message);

         Task<Message?> GetMessages(string messageId);

         Task<PaginatedResult<MessageDto>> GetMessagesForMember(MessageParams messageParams);

         Task<IReadOnlyList<MessageDto>> GetMessageThread(string currentMemberId , string recipientId);

         Task<bool> SaveAllAsync();
    }
}