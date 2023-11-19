using System;

namespace guessing_number;

public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()) { }
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;
    public int maxAttempts = 5;
    public int currentAttempts = 0;
    public int difficultyLevel = 1;
    private int minRandomNumber;
    private int maxRandomNumber;
    public bool gameOver;

    //1 - Imprima uma mensagem de saudação
    public string Greet()
    {

        return "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
    }

    //2 - Receba a entrada da pessoa usuária e converta para Int
    //5 - Adicione um limite de tentativas
    public string ChooseNumber(string userEntry)
    {

        if (this.currentAttempts < this.maxAttempts)
        {
            currentAttempts++;
            bool success = int.TryParse(userEntry, out userValue);

            if (!success)
            {
                return "Entrada inválida! Não é um número.";
            }
            else if (userValue > 100 || userValue < -100)
            {
                userValue = 0;
                return "Entrada inválida! Valor não está no range.";
            }
            else
            {
                return "Número escolhido!";

            }
        }
        else
        {
            gameOver = true;
            return "Você excedeu o número máximo de tentativas! Tente novamente.";
        }

    }

    //3 - Gere um número aleatório
    public string RandomNumber()
    {
        randomValue = this.random.GetInt(-100, 100);
        return "A máquina escolheu um número de -100 à 100!";
    }

    //6 - Adicione níveis de dificuldade
    public string RandomNumberWithDifficult()
    {
        switch (difficultyLevel)
        {
            case 2:
                this.minRandomNumber = -500;
                this.maxRandomNumber = 500;
                break;
            case 3:
                this.minRandomNumber = -1000;
                this.maxRandomNumber = 1000;
                break;
            default:
                this.minRandomNumber = -100;
                this.maxRandomNumber = 100;
                break;
        }

        return $"A máquina escolheu um número de {this.minRandomNumber} à {this.maxRandomNumber}!";
    }

    //4 - Verifique a resposta da jogada
    public string AnalyzePlay()
    {

        if (this.userValue < this.randomValue) return "Tente um número MAIOR";
        if (this.userValue > this.randomValue) return "Tente um número MENOR";

        gameOver = false;

        return "ACERTOU!";

    }

    //7 - Adicione uma opção para reiniciar o jogo
    public void RestartGame()
    {
        this.currentAttempts = 0;
        this.maxAttempts = 5;
        this.gameOver = false;
        this.difficultyLevel = 1;
        this.userValue = 0;
        this.randomValue = 0;
    }


}