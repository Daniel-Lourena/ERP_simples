namespace ModuloConfiguracoes
{
    public static class ConfiguracoesGerais
    {
        public static string stringConexaoDB =>
        Environment.GetEnvironmentVariable("DB_CONNECTION")
        ?? throw new Exception("Variável de ambiente DB_CONNECTION não definida");
    }
}