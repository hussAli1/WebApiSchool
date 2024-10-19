using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services.Interfaces;
using WebApiSchool.Exceptions;
using AutoMapper;
using System.Text;
using WebApiSchool.DTO.Accounts;

namespace WebApiSchool.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork,
               IAuthService authService,
               IConfiguration configuration,
                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _configuration = configuration;
            _mapper = mapper;
        }


        public async Task<LoginResponseDTO> LoginAsync(LoginDTO model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                throw new ValidationException("الرجاء قم بأدخال اسم المستخدم وكلمة المرور");
            }

            var user = await _unitOfWork.Users.LoginUserAsync(model.Username, model.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("اسم المستخدم وكلمة المرور غير موجودين");
            }

            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));
            var token = _authService.GenerateJwtToken(user);

            return new LoginResponseDTO
            {
                UserGuid = user.GUID,
                Token = token
            };
        }

        public async Task<string> RegisterUserAsync(RegisterDTO model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                throw new ValidationException("كلمات المرور غير متطابقة");
            }

            var existingUser = await _unitOfWork.Users.GetUserByUsernameAsync(model.Username);
            if (existingUser != null)
            {
                throw new ValidationException("اسم المستخدم موجود بالفعل");
            }

            var roleGuid = Guid.Parse("F9F68922-9C6D-4142-BC8C-000AB06B5AB3");
            var permissionGroup = await _unitOfWork.PermissionGroups.SelectByCondition(u => u.GUID.Equals(roleGuid), trackChanges: false);
            if (permissionGroup == null)
            {
                throw new ValidationException("Invalid role or permission group.");
            }

            var userEntity = _mapper.Map<User>(model);
            userEntity.PermissionGroup = permissionGroup;

            await _unitOfWork.Users.CreateAsync(userEntity);
            await _unitOfWork.CompleteAsync();

            return "تم انشاء الحساب بنجاح";
        }
    }
}
