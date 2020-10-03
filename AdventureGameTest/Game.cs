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
				Intro = "Welcome to node 1. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "Welcome",
				VisitedIntro = "This looks like where you started"
			};

			//2
			var two = new StoryNode()
			{
				Intro = "Welcome to node 2. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "two",
				VisitedIntro = "Looks like you have been here before"
			};

			//3
			var three = new StoryNode()
			{
				Intro = "Welcome to node 3. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "three",
				VisitedIntro = "Looks like you have been here before"
			};

			//4
			var four = new StoryNode()
			{
				Intro = "Welcome to node 4. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "four",
				VisitedIntro = "Looks like you have been here before",
				IsMainStoryNode = true
			};

			//5
			var five = new StoryNode()
			{
				Intro = "Welcome to node 5. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "five",
				VisitedIntro = "Looks like you have been here before"
			};

			//6
			var six = new StoryNode()
			{
				Intro = "Welcome to node 6. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "six",
				VisitedIntro = "Looks like you have been here before"
			};

			//7
			var seven = new StoryNode()
			{
				Intro = "Welcome to node 7. Would you like to continue?",
				GoalAnswer = "yes",
				StoryNodeName = "End",
				VisitedIntro = "Looks like you have been here before"
			};

			//create node layout
			one.Parents = null;
			one.Children.AddRange(new List<StoryNode>() { two, three });
			two.Parents.Add(one);
			three.Parents.Add(one);
			two.Children.Add(four);
			three.Children.Add(four);
			four.Parents.AddRange(new List<StoryNode>() { two, three });
			four.Children.AddRange(new List<StoryNode>() { five, six });
			five.Parents.Add(four);
			six.Parents.Add(four);
			six.Children.Add(seven);
			seven.Parents.Add(six);


			//add to created list
			createdNodes.AddRange(new List<StoryNode>() { one, two, three, four, five, six, seven });

			foreach (var node in createdNodes.Skip(1))
			{
				node.Children.Add(new StoryNode() { StoryNodeName = "back" });
			}

			StoryNodes = createdNodes;

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

			if(Console.ReadLine().Contains(node.GoalAnswer) || node.Visited && node.IsCompleted) //TODO: test this
			{
				Console.WriteLine("Choose your next path");
				foreach (var child in node.Children)
				{
					Console.WriteLine(child.StoryNodeName);
				}

				do
				{
					input = Console.ReadLine();
				} while (node.Children.Where(x => x.StoryNodeName == input).Count() == 0 );
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
				newNode.PreviousNode = node;
			}

			EvaluateNode(newNode);
		}
	}
}
