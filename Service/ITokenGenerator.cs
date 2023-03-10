namespace Airline_Reservation_System.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(int userId, string userName);
        bool IsTokenValid(string userSecretKey, string userIssuer, string userAudience, string userToken);
    }
}
