namespace Tone.Domain.Utils
{
    public static class MessagesUtil
    {
        // Validation messages.
        public static string MinLength = "O campo {0} deve ter pelo menos {1} caracteres";
        public static string MaxLength = "O campo {0} deve ter no máximo {1} caracteres";
        public static string InvalidField = "O campo {0} está inválido";
        public static string DocumentNumberInvalid = "Número de documento inválido";
        public static string RequiredField = "O campo {0} é obrigatório";

        // Upload messages.
        public static string InvalidFileType = "Tipo de arquivo inválido";
    }
}
