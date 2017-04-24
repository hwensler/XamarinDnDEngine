using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using App11.Models;

namespace App11
{
	public class CharacterDB
	{
		readonly SQLiteAsyncConnection database;

		public CharacterDB(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Character>().Wait();
		}

		// initialization for demo purposes
		public async Task Initialize()
		{
			int rowCount = await database.Table<Character>().CountAsync();

			if (rowCount == 0){
				var _characters = new List<Character>
				{
					new Character { ID = 0, Name = "Test Character 1", StackOrder = 1,  Level= 10,
									HitPoints = 20, Strength= 16, Defense = 16, Speed = 16},
					new Character { ID = 0, Name = "Test Character 2", StackOrder = 2,  Level= 9,
									HitPoints = 20, Strength= 16, Defense = 16, Speed = 16},
					new Character { ID = 0, Name = "Test Character 3", StackOrder = 3,  Level= 8,
									HitPoints = 20, Strength= 16, Defense = 16, Speed = 16}
				};

				foreach (Character character in _characters)
				{
					await database.InsertAsync(character);
				}	
			}
		}

		public Task<List<Character>> GetCharactersAsync()
		{
			return database.Table<Character>().ToListAsync();
		}

		public Task<Character> GetCharacterAsync(int id)
		{
			return database.Table<Character>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveCharacterAsync(Character character)
		{
			if (character.ID != 0)
			{
				return database.UpdateAsync(character);
			}
			else
			{
				return database.InsertAsync(character);
			}
		}

		public Task<int> DeleteCharacterAsync(Character character)
		{
			return database.DeleteAsync(character);
		}
	}
}