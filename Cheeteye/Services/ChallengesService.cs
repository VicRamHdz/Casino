using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cheeteye.Models;

namespace Cheeteye.Services
{
	public class ChallengesService : BaseProvider
	{
		public async Task<ResponseResult<List<ChallengesModel>>> GetChallenges()
		{
			var endpoint = "ChallengesCatalog?code=nUn8a1KBiSRpKokpHHTC0h9xkaotNwe2mpV7FrF3WF4xYK3HjqUBJg==";
			var result = await GetAsync<List<ChallengesModel>>(endpoint);
			return result;
		}
	}
}
