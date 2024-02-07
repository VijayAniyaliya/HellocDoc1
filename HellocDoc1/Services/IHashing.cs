namespace HellocDoc1.Services
{
    public interface IHashing
    {
        string Decrypt(string cipherText);
        string encrypt(string encryptString);
    }
}