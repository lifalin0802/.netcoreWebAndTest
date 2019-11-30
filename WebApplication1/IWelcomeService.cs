namespace WebApplication1
{
    public interface IWelcomeService
    {
        string GetMessage();
    }

    public class WelcomeService : IWelcomeService
    {
        public string GetMessage() {
            return "Welcome Service!";
         }
    }


}