using MinimalApiComDapper.Models;

namespace MinimalApiComDapper.Interfaces
{
    public interface ICarroRepositorio
    {
        IEnumerable<CarroModel> Carros();
        bool CriarCarro(CarroModel carro);
        bool AlterarCarroCor(int id, string cor);
        bool ExcluirCarro(int id);
    }
}
