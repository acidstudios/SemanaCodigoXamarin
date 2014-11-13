using System;

namespace LSDCExample
{
	public class TodoItem
	{
		public TodoItem ()
		{
		}

		public Guid Id { get; set;}
		public string Text { get; set; }
		public bool Complete { get; set; }
	}
}

