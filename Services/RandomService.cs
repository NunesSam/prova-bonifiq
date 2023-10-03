namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
		Random num;

		public RandomService()
		{
			seed = Guid.NewGuid().GetHashCode();
			num = new Random(seed);
		}
		public int GetRandom()
		{
			return num.Next(100);			
		}

	}
}
