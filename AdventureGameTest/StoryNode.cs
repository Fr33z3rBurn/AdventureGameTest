using AdventureGameTest.ItemClasses;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace AdventureGameTest
{
	public class StoryNode
	{
		public string StoryNodeName { get; set; }
		public int StoryNodeId { get; set; }

		public List<StoryNode> Parents { get; set; }

		public List<StoryNode> Children { get; set; }

		public StoryNode PreviousNode { get; set; }

		public bool Visited { get; set; }

		public bool IsMainStoryNode { get; set; }

		public bool IsCompleted { get; set; }

		public string Intro { get; set; }

		public string VisitedIntro { get; set; }
		
		public Item GoalObject { get; set; }

		public string GoalAnswer { get; set; }

		//commands

		public StoryNode()
		{
			Parents = new List<StoryNode>();
			Children = new List<StoryNode>();
		}
	}
}
