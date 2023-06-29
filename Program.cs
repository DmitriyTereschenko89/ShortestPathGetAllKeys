namespace ShortestPathGetAllKeys
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ShortestPathGetAllKeys shortestPathGetAllKeys = new();
            Console.WriteLine(shortestPathGetAllKeys.ShortestPathAllKeys(new string[] { "@.a..", "###.#", "b.A.B" }));
			Console.WriteLine(shortestPathGetAllKeys.ShortestPathAllKeys(new string[] { "@..aA", "..B#.", "....b" }));
			Console.WriteLine(shortestPathGetAllKeys.ShortestPathAllKeys(new string[] { "@Aa" }));
		}
	}
}