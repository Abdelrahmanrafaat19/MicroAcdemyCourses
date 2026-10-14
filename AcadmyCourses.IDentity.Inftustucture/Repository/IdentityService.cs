using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.CreateUserDto;
using AcadmyCourses.IDentity.Application.Dtos.LoginDto;
using AcadmyCourses.IDentity.Application.Dtos.UserEntityDto;
using AcadmyCourses.IDentity.Inftustucture.Entities;
using Microsoft.AspNetCore.Identity;
using StockManagment.Application.common;


namespace AcadmyCourses.IDentity.Inftustucture.Repository
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtCreator _jwtCreator;
        public IdentityService(UserManager<UserEntity> userManager, IJwtCreator jwtCreator)
        {
            this._userManager = userManager;
            this._jwtCreator = jwtCreator;
        }
        public async Task<Result<ReturnedUserCreation>> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken)
        {
            if (dto.email == null)
            {
                return Result<ReturnedUserCreation>.Failure(Error.Validation("ErrorType.Validation", "Must Be Enter Your Email"));
            }
            var ExistsUser = await _userManager.FindByEmailAsync(dto.email);

            if (ExistsUser != null)
            {
                return Result<ReturnedUserCreation>.Failure(Error.Validation("ErrorType.Validation", "This Email Already Exist"));
            }

            var NewUser = new UserEntity()
            {
                UserName = dto.userName,
                LastName = dto.lastName,
                FirstName = dto.firstName,
                Email = dto.email,
                UserGroupId=dto.UserGroupId

            };
            var result = await _userManager.CreateAsync(NewUser, dto.password);
            var token = _jwtCreator.CreateToken(NewUser.Email, NewUser.FirstName, NewUser.Id, Array.Empty<string>(), cancellationToken);

            if (result.Succeeded)
            {
                var returnedUser = new ReturnedUserCreation()
                {
                    fullName = $"{dto.firstName} {dto.lastName}",
                    email = dto.email,
                    userName = dto.userName,
                    Token = token
                };
                return Result<ReturnedUserCreation>.Success(returnedUser);
            }
            else
            {
                var errors = string.Join(
                                          ", ",
                                          result.Errors.Select(e => e.Description)
                                      );
                return Result<ReturnedUserCreation>.Failure(Error.Validation("ErrorType.Failure", errors));
            }
        }

        public async Task<Result<bool>> UpdateDataUser(string email,UpdateUserData data, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<bool>.Failure(
                    Error.Unauthorized(
                        "ErrorType.Unauthorized",
                        "Must Be Login"));
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return Result<bool>.Failure(
                    Error.Failure(
                        "ErrorType.Failure",
                        "User does not exist"));
            }


            UpdateUserData(user, data);
            if (!string.IsNullOrWhiteSpace(data.Password))
            {
                var passwordResult = await ChangeUserPassword(user, data);

                if (!passwordResult.IsSuccess)
                {
                    return passwordResult;
                }
            }

      
            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return Result<bool>.Failure(
                    Error.Failure(
                        "ErrorType.UpdateUser",
                        GetIdentityErrors(updateResult.Errors)));
            }

            return Result<bool>.Success(true);
        }
        private void UpdateUserData(UserEntity user,UpdateUserData data)
        {
            if (!string.IsNullOrWhiteSpace(data.UserName))
                user.UserName = data.UserName;

            if (!string.IsNullOrWhiteSpace(data.FirstName))
                user.FirstName = data.FirstName;

            if (!string.IsNullOrWhiteSpace(data.LastName))
                user.LastName = data.LastName;
        }
        private async Task<Result<bool>> ChangeUserPassword(UserEntity user, UpdateUserData data)
        {
            if (string.IsNullOrWhiteSpace(data.CurrentPassword))
            {
                return Result<bool>.Failure(
                    Error.Failure(
                        "ErrorType.CurrentPasswordRequired",
                        "Current password is required"));
            }

            var result = await _userManager.ChangePasswordAsync(
                user,
                data.CurrentPassword,
                data.Password!);

            if (!result.Succeeded)
            {
                return Result<bool>.Failure(
                    Error.Failure(
                        "ErrorType.Password",
                        GetIdentityErrors(result.Errors)));
            }

            return Result<bool>.Success(true);
        }
        private static string GetIdentityErrors(IEnumerable<IdentityError> errors)
        {
            return string.Join(
                ", ",
                errors.Select(e => e.Description));
        }

        public async Task<Result<ProfileDataDto>> ProfileDataAsync(string userID, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(userID))
            {
                return Result<ProfileDataDto>.Failure(
                    Error.Unauthorized(
                        "ErrorType.Unauthorized",
                        "User ID is required"));
            }
            var userData = await _userManager.FindByIdAsync(userID);

            if (userData is null)
            {
                return Result<ProfileDataDto>.Failure(
                    Error.Failure(
                        "ErrorType.UserNotFound",
                        "User does not exist"));
            }
            var profileData = new ProfileDataDto()
            {
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Email = userData.Email!,
                UserName = userData.UserName!
            };


            return Result<ProfileDataDto>.Success(profileData);
        }

        public async Task<Result<string>> ActiveAndDeactineAsync(string userID, CancellationToken ct)
        {

            if (string.IsNullOrWhiteSpace(userID))
            {
                return Result<string>.Failure(
                    Error.Unauthorized(
                        "ErrorType.Unauthorized",
                        "User ID is required"));
            }
            var userData = await _userManager.FindByIdAsync(userID);

            if (userData is null)
            {
                return Result<string>.Failure(
                    Error.Failure(
                        "ErrorType.UserNotFound",
                        "User does not exist"));
            }

            if (userData.isActive)
            {
                userData.isActive = false;
                var result = await _userManager.UpdateAsync(userData);
                if (result.Succeeded)
                {
                    return Result<string>.Success("The User DeActive");
                }
                else
                {
                    return Result<string>.Failure(Error.Failure("ErrorType.Failure", "The Status Not Changes"));
                }
            }
            else
            {

                userData.isActive = true;
                var result = await _userManager.UpdateAsync(userData);
                if (result.Succeeded)
                {
                    return Result<string>.Success("The User Active");
                }
                else
                {
                    return Result<string>.Failure(Error.Failure("ErrorType.Failure", "The Status Not Changes"));
                }
            }


        }

        public async Task<Result<ReturnedLoginDto>> LoginAsync(InPutLoginDto data, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(data.Email))
            {
                return Result<ReturnedLoginDto>.Failure(Error.Failure("ErrorType.Failure", "Must Be Enter Your Email"));
            }


            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user is null)
            {
                return Result<ReturnedLoginDto>.Failure(
                    Error.Failure(
                        "ErrorType.InvalidCredentials",
                        "Invalid email or password")); 
            }
            var passwordValid = await _userManager.CheckPasswordAsync(
                 user,
                data.password);
            if (!passwordValid)
            {
                return Result<ReturnedLoginDto>.Failure(
                    Error.Failure(
                        "ErrorType.InvalidCredentials",
                        "Invalid email or password"));
            }
            var token = _jwtCreator.CreateToken(user.Email, user.FirstName, user.Id, Array.Empty<string>(), ct);

            return Result<ReturnedLoginDto>.Success(new ReturnedLoginDto()
            {
                Token = token,
                FullName = $"{user.FirstName}{user.LastName}",
                Email=user.Email!
            });

        }

        public async Task<Result<bool>> UpdateUserGroupAsync(Guid UserID, Guid GroupID, CancellationToken ct)
        {
            var useExsit = await _userManager.FindByIdAsync(UserID.ToString());
            if(useExsit is null)
            {
                return Result<bool>.Failure(Error.NotFound("ErrorType.NotFound", "User Not Exist"));
            }


            if(useExsit.UserGroupId==GroupID)
            {
                return Result<bool>.Failure(Error.Validation("ErrorType.Validation", "User is Already Exist in This Group"));
            }
            useExsit.UserGroupId=GroupID;

            var updateResult= await _userManager.UpdateAsync(useExsit);

            if (!updateResult.Succeeded)
            {
                var ErrorsMessage = string.Join(" / ", updateResult.Errors);
                return Result<bool>.Failure(Error.Failure("ErrorType.Failure", ErrorsMessage));
            }


            return Result<bool>.Success(true);


            
        }
    }
}
