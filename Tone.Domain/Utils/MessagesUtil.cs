﻿namespace Tone.Domain.Utils
{
    public static class MessagesUtil
    {
        // Validation messages.
        public static string MinLength = "O campo {0} deve ter pelo menos {1} caracteres";
        public static string MaxLength = "O campo {0} deve ter no máximo {1} caracteres";
        public static string InvalidField = "O campo {0} está inválido";
        public static string DocumentNumberInvalid = "Número de documento inválido";
        public static string RequiredField = "O campo {0} é obrigatório";
        public static string FormFail = "Por favor, verifique se todos os campos estão preenchidos corretamente!";

        // Confirmation messages.
        public static string CreatedSuccess = "Cadastro realizado com sucesso!";
        public static string UpdatedSuccess = "Cadastro modificado com sucesso!";
        public static string DeletedSuccess = "Cadastro deletado com sucesso!";

        // Error messages.
        public static string CreateError = "Ocorreu um erro ao cadastrar entidade!";
        public static string UpdateError = "Ocorreu um erro ao modificar entidade!";
        public static string DeleteError = "Ocorreu um erro ao deletar entidade!";

        // Upload messages.
        public static string InvalidFileType = "Tipo de arquivo inválido";
    }
}
