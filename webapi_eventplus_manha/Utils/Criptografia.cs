namespace webapi_eventplus_manha.Utils
{

    //classe criar para criptografar as senhas e para verificar se a senha que está vindo do formulário é a mesma que a senha do banco de dados

    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaBanco, senhaForm);
        }
    }
}
