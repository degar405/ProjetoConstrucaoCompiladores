namespace FrontEndCompilador
{
    public class TratamentoDeErro
    {
        public bool ExisteErro { get; private set; } = false;

        public void AcusarErro(string mensagem)
        {
            ExisteErro = true;
            Console.WriteLine(mensagem);
        }
    }
}
