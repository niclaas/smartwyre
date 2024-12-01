using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data;

/// <summary>
/// Simple dictionary backed store to demonstrate and test against.
/// Can implement against database if needed.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Store<T> : IStore<T> where T : class?, IEntity
{
	Dictionary<string, T> _collection = new Dictionary<string, T>();

	public async Task<T?> Get(string identifier)
	{
		if (string.IsNullOrWhiteSpace(identifier))
		{
			return null;
		}
		else
		{
			return _collection.ContainsKey(identifier) ? _collection[identifier] : null;
		}
	}

	public async Task<IEnumerable<T>> GetAll()
	{
		return _collection.Values.ToList();
	}

	public async Task<T> Save(T entity)
	{
		if (string.IsNullOrWhiteSpace(entity.Identifier))
		{
			entity.Identifier = Guid.NewGuid().ToString();
		}

		_collection[entity.Identifier] = entity;

		return entity;
	}
}
