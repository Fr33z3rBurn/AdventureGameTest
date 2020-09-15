using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AdventureGameTest
{
	public class StoryNode
	{
		public int StoryNodeId { get; set; }

		public List<StoryNode> Parent { get; set; }

		public List<StoryNode> Children { get; set; }

		public bool Visited { get; set; }

		//people

		//goal

		//intro
	}
}
