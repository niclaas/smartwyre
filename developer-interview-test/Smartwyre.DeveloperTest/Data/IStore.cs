using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

/// <summary>
/// Implementing as async store because this should represent a real
/// database, even though our implementation uses dictionaries to store
/// cache for the running instance only.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IStore<T> where T : IEntity
{
	Task<T?> Get(string identifier);
	Task<IEnumerable<T>> GetAll();
	Task<T> Save(T entity);
}
