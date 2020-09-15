using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGameTest.ItemClasses
{
	public class Item
	{
		public float Height { get; set; }

		public float Weight { get; set; }

		public virtual bool CanBePickedUp { get; set; }
	}
}
