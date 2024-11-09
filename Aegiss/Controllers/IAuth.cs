namespace Aegiss.Controllers
{
    public interface IAuth
    {
        string username { get; set; }
        string password { get; set; }
    }

    public class Auth : IAuth
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
