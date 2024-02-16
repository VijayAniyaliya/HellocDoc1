namespace Services.Contracts
{
    public interface IHashing
    {
        string Decrypt(string cipherText);
        string encrypt(string encryptString);
    }
}