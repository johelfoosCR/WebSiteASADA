using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using WebAsada.Data;
using WebAsada.Helpers;
using WebAsada.Models;
using WebAsada.ViewModels;

namespace WebAsada.Repository
{
    public class SystemUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SystemUserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<SystemUserVM>> GetAll()
        {
            return await _applicationDbContext.SystemUser
                                              .Include(x => x.Password)
                                              .Include(x => x.UserName)
                                              .Select(x => new SystemUserVM() {
                                                  Id = x.Id,
                                                  FullName = x.FullName,
                                                  IsActive = x.IsActive,
                                                  IsAdministrator = x.IsAdministrator,
                                                  IsOperational = x.IsOperational,
                                                  UserName = x.UserName.Value
                                              })
                                              .ToListAsync();
        }

        public async Task Save(SystemUser entity) {
            await _applicationDbContext.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Result> Update(string id, SystemUser newSystemUser)
        {
            var entity = await ReadById(id);

            if (entity.HasNoValue) Result.Failure("No se encontró el usuario");

            SystemUser.SincronizeObject(currentSystem: entity.Value, newSystemUser);
            _applicationDbContext.Entry(entity.Value).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            return Result.Ok();
        }


        public async Task<Result> UpdatePassword(string id, Password newPassword)
        {
            var entity = await ReadById(id);

            if (entity.HasNoValue) return Result.Failure("No se encontró el usuario"); 

            entity.Value.ChangePassword(newPassword);
            _applicationDbContext.Entry(entity.Value).State = EntityState.Modified;
            return Result.Ok(await _applicationDbContext.SaveChangesAsync());
        }

        private async Task<Maybe<SystemUser>> ReadById(string id)
        {
            return await _applicationDbContext.SystemUser
                                             .Where(x => x.Id == id ) 
                                             .FirstOrDefaultAsync();
        }

        public async Task<Result<SystemUser>> ValidateUserAndPassword(SystemUserLoginVM systemUserView)
        {
            Maybe<SystemUser> existingUser = await _applicationDbContext.SystemUser
                                          .Where(x => x.UserName.Value == systemUserView.UserName)
                                         .FirstOrDefaultAsync();

            if (existingUser.HasValue) {
                
                if (!existingUser.Value.IsActive)
                {
                    return Result.Failure<SystemUser>("El usuario se encuentra inactivo");
                }

                if (existingUser.Value.Password.Value == SecurityHelper.ComputeSha256Hash(systemUserView.Password))
                {
                    return Result.Ok(existingUser.Value);
                }
                
                return Result.Failure<SystemUser>("La contraseña es incorrecta");
            }
            else
            {
                return Result.Failure<SystemUser>("No se encontró el usuario");
            }
        }

        public async Task<Maybe<SystemUserVM>> GetById(string id)
        {
            return await _applicationDbContext.SystemUser
                                             .Include(x => x.Password)
                                             .Include(x => x.UserName)
                                             .Where(x => x.Id == id)
                                             .Select(x => new SystemUserVM()
                                             {
                                                 Id = x.Id,
                                                 FullName = x.FullName,
                                                 IsActive = x.IsActive,
                                                 IsAdministrator = x.IsAdministrator,
                                                 IsOperational = x.IsOperational,
                                                 UserName = x.UserName.Value
                                             })
                                             .FirstOrDefaultAsync();
        }
            
    }
}