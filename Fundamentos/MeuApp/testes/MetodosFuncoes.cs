internal class MetodosFuncoes
{
    public void MeuMetodo()
    {
        Console.WriteLine("C# é legal");
    }

    public string NomeCompleto(string name, string sobrenome, int idade)
    {
        return "Seu nome é: " + name +
         "Seu sobrenome é: " + sobrenome +
         "Sua idade é: " + idade.ToString();
    }

    public string SobreNome(string sobrenome)
    {
        return "Seu sobrenome é: " + sobrenome;
    }

    public string Dados(string nome, string sobrenome, int idade)
    {
        var nomeCompleto = NomeCompleto(nome, sobrenome, idade);
        return nomeCompleto;
    }
}