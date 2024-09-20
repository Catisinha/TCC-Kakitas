namespace MAContabilidade.Helpers;

public static class TranslateIdentityErrors
{
    public static string TranslateErrorMessage(string codeError)
    {
        string message = codeError switch
        {
            "DefaultError" => "Ocorreu um erro desconhecido.",
            "ConcurrencyFailure" => "Falha de concorrência otimista, o objeto foi modificado.",
        }
    }
}
