namespace WPR.Core.Domains.Users.Models;

public record HashedPassword(string Hash, byte[] Salt);