using FluentValidation;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Core.Domains.Users.Models;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Users.Services;

public class UserManager : IUserManager
{
    private readonly PasswordValidator _passwordValidator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly UserValidator _userValidator;

    public UserManager(IUserRepository userRepository, IUnitOfWork unitOfWork, UserValidator userValidator,
        PasswordValidator passwordValidator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _userValidator = userValidator;
        _passwordValidator = passwordValidator;
    }

    public User GetById(Guid id)
    {
        return _userRepository.GetById(id);
    }

    public User GetByTag(string tag)
    {
        return _userRepository.GetByTag(tag);
    }

    public User[] GetManyById(Guid[] ids, int startIndex = 0, int quantity = -1)
    {
        return _userRepository.GetManyById(ids, startIndex, quantity);
    }

    public Guid Create(User user, string password)
    {
        _userValidator.ValidateAndThrow(user);
        _passwordValidator.ValidateAndThrow(password);
        var id = _userRepository.Create(user, password);
        _unitOfWork.SaveChanges();
        return id;
    }

    public void Update(User user)
    {
        _userValidator.ValidateAndThrow(user);
        _userRepository.Update(user);
        _unitOfWork.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        _userRepository.DeleteById(id);
        _unitOfWork.SaveChanges();
    }
}