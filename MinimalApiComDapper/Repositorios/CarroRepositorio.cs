using Dapper;
using MinimalApiComDapper.Factory;
using MinimalApiComDapper.Interfaces;
using MinimalApiComDapper.Models;
using System.Data;

namespace MinimalApiComDapper.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly IDbConnection _connection;
        private int result = 0;
        public CarroRepositorio()
        {
            _connection = new SqlFactory().SqlConnection();
        }

        public bool CriarCarro(CarroModel carro)
        {
            var query = @"INSERT INTO [Estudos].[dbo].[Carros] 
                        VALUES
                        (@modelo,
                         @fabricante,
                         @motor,
                         @cor)";
            var parameters = new
            {
                modelo = carro.Modelo,
                fabricante = carro.Fabricante,
                motor = carro.Motor,
                cor = carro.Cor
            };
            using (_connection)
            {
                result = _connection.Execute(query, parameters);
            }
            return (result != 0 ? true : false);
        }

        public IEnumerable<CarroModel> Carros()
        {
            var query = "SELECT * FROM [Estudos].[dbo].[Carros]";
            using (_connection)
            {
                return _connection.Query<CarroModel>(query).ToList();
            }
        }

        public bool AlterarCarroCor(int id, string cor)
        {
            var query = @"UPDATE [Estudos].[dbo].[Carros] 
                          SET Cor = @carroCor
                          WHERE ID = @carroId";
            using (_connection)
            {
                result = _connection.Execute(query, new { carroCor = cor, carroId = id });
            }
            return (result != 0 ? true : false);
        }

        public bool ExcluirCarro(int id)
        {
            var query = "DELETE [Estudos].[dbo].[Carros] WHERE ID = @carroId";
            using (_connection)
            {
                result = _connection.Execute(query, new { carroId = id });
            }
            return (result != 0 ? true : false);
        }
    }
}
