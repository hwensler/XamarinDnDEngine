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

			if (rowCount == 0)
			{
				// use this to create different test characters
				//var _characters = new List<Character>
				//{
				//	new Character { Name = "Character 1", StackOrder = 1,  Level= 0,
				//					HitPoints = 10, Strength= 2, Defense = 2, Speed = 2},
				//	new Character { Name = "Character 2", StackOrder = 2,  Level= 0,
				//					HitPoints = 10, Strength= 2, Defense = 2, Speed = 2},
				//	new Character { Name = "Character 3", StackOrder = 3,  Level= 0,
				//					HitPoints = 10, Strength= 2, Defense = 2, Speed = 2},
				//	new Character { Name = "Character 4", StackOrder = 4,  Level= 0,
				//					HitPoints = 10, Strength= 2, Defense = 2, Speed = 2}
				//};

				// use this to create same test characters
				var _characters = new List<Character>();
				for(int i = 0; i < 4; i++)
				{
				    _characters.Add(new Character(2, 2, 2, i + 1, 10, 0, "Character " + (i+1)));
				}

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