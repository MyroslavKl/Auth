namespace Lab2.Additional
{
    public interface IHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashPassword, string rawPassword);
    }
}
