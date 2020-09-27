using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureGameTest
{
	public class Game
	{
		List<StoryNode> StoryNodes { get; set; }
		Player Player { get; set; }

		public Game()
		{
			CreateNewPlayer();

			CreateTestDataForGame();

			var startNode = StoryNodes.Where(x => x.Parents == null).FirstOrDefault();

			EvaluateNode(startNode);
		}

		private void CreateNewPlayer()
		{

		}

		private List<StoryNode> CreateTestDataForGame()
		{
			//eventually get this data from a central location
			var createdNodes = new List<StoryNode>();

			//1
			var one = new StoryNode()
			{
				Parents = null,
				Intro = "Welcome to node 1. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "Welcome",
				VisitedIntro = "This looks like where you started"
			};

			//2
			var two = new StoryNode()
			{
				
			};

			//3

			//4

			//5

			//6

			//7

			//create family

			//add to created list

			return createdNodes;
		}

		private void SaveGame()
		{
			throw new NotImplementedException();
		}

		private void EvaluateNode(StoryNode node)
		{
			Console.WriteLine(node.Intro);
			StoryNode newNode;
			string input = "";

			if(Console.ReadLine().Contains(node.GoalAnswer) || node.Visited && node.IsCompleted) //test this
			{
				Console.Write("Choose your next path");
				foreach (var child in node.Children)
				{
					Console.WriteLine(child.StoryNodeName);
				}

				do
				{
					input = Console.ReadLine();
				} while (node.Children.Where(x => x.StoryNodeName == input).Count() == 0 || input != "back");
			}

			if (input == "back")
			{
				node.Visited = true;
				newNode = node.PreviousNode;
			}
			else
			{
				node.IsCompleted = true;
				node.Visited = true;
				newNode = StoryNodes.Where(x => x.StoryNodeName == input).FirstOrDefault();
			}

			EvaluateNode(newNode);
		}
	}
}
