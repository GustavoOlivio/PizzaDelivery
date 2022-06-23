namespace PizzaDelivery.Repository.Interfaces
{
    public interface IMasterRepository
    {
        Task<int> InserirAsync(string query, object obj);
        Task UpdateOrDeleteAsync(string query, object obj);
        Task<IEnumerable<T>> ObterListaAsync<T>(string query, object obj);
        Task<T> ObterUnicoResultadoAsync<T>(string query, object obj);
    }
}