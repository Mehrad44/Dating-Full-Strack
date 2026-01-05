namespace API.Intefaces
{
    public interface IUnitOfWork
    {
         IMemeberRepository MemeberRepository { get; }

         IMessageRepository MessageRepository { get; }

         ILikesRepository LikesRepository { get; }

         Task<bool> Complete();

         bool HasChanges();
    }
}