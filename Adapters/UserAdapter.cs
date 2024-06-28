using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using timefree_training_api.Models.EF.Training;

namespace timefree_training_api.Adapters
{
	public class UserAdapter
	{
		public UserAdapter()
		{
		}

        public async Task<string> GetTest()
        {
            return "Success!";
        }

        public async Task<List<user>> GetUsers()
        {
            using (var db = new Training())
            {
                return await db.user.ToListAsync();
            }
        }

        public async Task<List<user>> GetUser(string first_name)
        {
            using (var db = new Training())
            {
                return await db.user.Where(x=>x.first_name.Contains(first_name)&& !x._deleted).ToListAsync();
            }
        }
    }
}

