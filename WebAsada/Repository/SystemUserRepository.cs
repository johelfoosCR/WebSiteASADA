using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
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


        public async Task<Result<SystemUser>> ValidateUserAndPassword(SystemUserVM systemUserView)
        {
            Maybe<SystemUser> existingUser = await _applicationDbContext.SystemUser
                                          .Where(x => x.UserName.Value == systemUserView.UserName)
                                         .FirstOrDefaultAsync();

            if (existingUser.HasValue) {

                if (existingUser.Value.Password.Value == SecurityHelper.ComputeSha256Hash(systemUserView.Password))
                {
                    return Result.Ok(existingUser.Value);
                }
                else { 
                    return Result.Failure<SystemUser>("La contraseña es incorrecta");
                }
            }
            else
            {
                return Result.Failure<SystemUser>("No se encontró el usuario");
            }
        }
    }
}