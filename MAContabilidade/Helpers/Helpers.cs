using System.Net.Mail;

namespace MAContabilidade.Helpers;

public static class Helper
{
    public static bool IsValidEmail(string email)
    {
        try
        {
            MailAddress m = new(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
