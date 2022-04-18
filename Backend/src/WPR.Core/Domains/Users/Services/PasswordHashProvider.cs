using System.Security.Cryptography;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Core.Domains.Users.Models;

namespace WPR.Core.Domains.Users.Services;

public class PasswordHashProvider : IPasswordHashProvider
{
    private const int HashSize = 50;
    private const int Iterations = 256;

    public string GetHash(string password, byte[] salt)
    {
        var hash = new byte[HashSize];
        Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA512,
            destination: hash);
        return Convert.ToBase64String(hash);
    }

    public HashedPassword CreateHash(string password)
    {
        var hash = new byte[HashSize];
        var saltSize = Random.Shared.Next(50, 100);
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA512,
            destination: hash);
        return new HashedPassword(Convert.ToBase64String(hash), salt);
    }
}