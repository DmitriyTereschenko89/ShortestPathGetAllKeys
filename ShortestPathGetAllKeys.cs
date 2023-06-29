namespace ShortestPathGetAllKeys
{
	internal class ShortestPathGetAllKeys
	{
		public int ShortestPathAllKeys(string[] grid)
		{
			int directions = 4;
			int[] deltaR = new int[] { 0, -1, 0, 1 };
			int[] deltaC = new int[] { -1, 0, 1, 0 };
			// row, col, key state, distance
			Queue<(int, int, int, int)> queue = new();
			Dictionary<int, HashSet<(int, int)>> seen = new();
			HashSet<char> keys = new();
			HashSet<char> lockKeys = new();
			int allKeys = 0;
			int startR = -1;
			int startC = -1;
			for (int r = 0; r < grid.Length; ++r)
			{
				for (int c = 0; c < grid[r].Length; ++c)
				{
					char ch = grid[r][c];
					if (ch >= 'a' && ch <= 'z')
					{
						allKeys += (1 << (ch - 'a'));
						keys.Add(ch);
					}
					else if (ch >= 'A' && ch <= 'Z')
					{
						lockKeys.Add(ch);
					}
					else if (ch == '@')
					{
						startR = r;
						startC = c;
					}
				}
			}
			queue.Enqueue((startR, startC, 0, 0));
			seen.Add(0,new HashSet<(int, int)>());
			seen[0].Add((startR, startC));
			while(queue.Count > 0)
			{
				(int, int, int, int) curCell = queue.Dequeue();
				int curR = curCell.Item1, curC = curCell.Item2, curKeys = curCell.Item3, distance = curCell.Item4;
				for (int i = 0; i < directions; ++i)
				{
					int newR = curR + deltaR[i];
					int newC = curC + deltaC[i];
					if (newR >= 0 && newR < grid.Length && newC >= 0 && newC < grid[newR].Length && grid[newR][newC] != '#')
					{
						char newCh = grid[newR][newC];
						if (keys.Contains(newCh))
						{
							if(((1 << (newCh - 'a')) & curKeys) != 0)
							{
								continue;
							}
							int newKeys = curKeys | (1 << (newCh - 'a'));
							if (newKeys == allKeys)
							{
								return distance + 1;
							}
							if (!seen.ContainsKey(newKeys))
							{
								seen.Add(newKeys, new HashSet<(int, int)>());
							}
							seen[newKeys].Add((newR, newC));
							queue.Enqueue((newR, newC, newKeys, distance + 1));
						}
						if (lockKeys.Contains(newCh) && (curKeys & (1 << (newCh - 'A'))) == 0)
						{
							continue;
						}
						else if (seen.ContainsKey(curKeys))
						{
							if (seen[curKeys].Add((newR, newC)))
							{
								queue.Enqueue((newR, newC, curKeys, distance + 1));
							}
						}
					}
				}
			}
			return -1;
		}
	}
}
