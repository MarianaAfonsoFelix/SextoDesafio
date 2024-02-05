// Solicita a data de nascimento ao usuário
Console.Write("Olar, seja bem vinda(o)! Digite sua data de nascimento (DD/MM/AAAA): ");
string nascimentoUsuario = Console.ReadLine();

// Converte a data de nascimento do usuário para uma variavel  DateTime
if (DateTime.TryParseExact(nascimentoUsuario, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
{
    // Calcula a idade e a quantidade de dias vividos
    CalcularIdadeEQuantidadeDias(dataNascimento, out int anos, out int meses, out int dias, out int diasVividos);

    // Exibe a idade
    Console.WriteLine($"Você tem {anos} anos, {meses} meses e {dias} dias.");

    // Exibe a quantidade de dias vividos até o momento
    Console.WriteLine($"Até agora, você viveu {diasVividos} dias.");

    // Aguarda o usuário pressionar Enter antes de encerrar
    Console.ReadLine();
}
else
{
    Console.WriteLine("Formato de data inválido. Certifique-se de digitar no formato DD/MM/AAAA.");
}


    // Função para calcular a idade, meses, dias e a quantidade de dias vividos
static void CalcularIdadeEQuantidadeDias(DateTime dataNascimento, out int anos, out int meses, out int dias, out int diasVividos)
{
    DateTime hoje = DateTime.Today;

    anos = hoje.Year - dataNascimento.Year;
    meses = hoje.Month - dataNascimento.Month;
    dias = hoje.Day - dataNascimento.Day;

    //verifica casos onde o usuário ainda não tenha feito aniversario no ano atual
    if (dias < 0)
    {
        meses--;
        dias += DateTime.DaysInMonth(hoje.Year, hoje.Month - 1);
    }

    //ajusta para casos onde o mês de nascimento é maior que o mês atual
    if (meses < 0)
    {
        anos--;
        meses += 12;
    }

    //calcula a quantidade total de dias vividos
    diasVividos = (hoje - dataNascimento).Days;
}