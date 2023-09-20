namespace webapi_eventplus_manha.Utils
{

    //classe criar para criptografar as senhas e para verificar se a senha que está vindo do formulário é a mesma que a senha do banco de dados

    public static class Criptografia
    {
               /// <summary>
        /// Gera uma hash a partir de uma nova senha
        /// </summary>
        /// <param name="senha">senha que receberá a hash </param>
        /// <returns>Senha criptografada</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada é igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha Informada pelo Usuário</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>trul or false (senha é verdadeira?
        /// 0</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
