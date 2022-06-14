using escolaNc.Modelos;

namespace escolaNc.Interfaces
{
    public interface ILoginService
    {
        public Registro Registrar(Registro cadastro);
        public bool Logar(Login dados);
    }
}
