using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGameTest
{
	public class Game
	{
		List<StoryNode> StoryNodes { get; set; } //something other than list

		public Game()
		{
			StoryNodes = new List<StoryNode>();
		}
	}
}
