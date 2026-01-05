using System;
using API.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IMemeberRepository? _memeberRepository;

     private IMessageRepository? _messageRepository;

    private ILikesRepository? _likesRepository;

    public IMemeberRepository MemeberRepository => _memeberRepository 
        ??= new MemberRepository(context); 

    public IMessageRepository MessageRepository => _messageRepository 
        ??= new MessageRepository(context);

    public ILikesRepository LikesRepository => _likesRepository 
        ??= new LikesRepository(context);

    public async Task<bool> Complete()
    {
        try
        {
            return await context.SaveChangesAsync() > 0;
        }catch(DbUpdateException ex)
        {
            throw new Exception("Error occured while saving changes",ex);
        }
    }

    public bool HasChanges()
    {
       return context.ChangeTracker.HasChanges();
    }
}
