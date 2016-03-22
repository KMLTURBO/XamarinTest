using System;

namespace Acquaint.Util
{
	/// <summary>
	/// Messaging service alert.
	/// </summary>
	public class MessagingServiceAlert
	{
		/// <summary>
		/// Init this instance.
		/// </summary>
		public static void Init()
		{
			var time = DateTime.UtcNow;
		}

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {get;set;}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance cancel/OK text.
		/// </summary>
		/// <value><c>true</c> if this instance cancel; otherwise, <c>false</c>.</value>
		public string Cancel { get; set; }

		/// <summary>
		/// Gets or sets the OnCompleted Action.
		/// </summary>
		/// <value>The OnCompleted Action.</value>
		public Action OnCompleted { get; set; }
	}

	/// <summary>
	/// Messaging service choice.
	/// </summary>
	public class MessagingServiceChoice
	{
		/// <summary>
		/// Init this instance.
		/// </summary>
		public static void Init()
		{
			var time = DateTime.UtcNow;
		}

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {get;set;}

		/// <summary>
		/// Gets or sets a value indicating whether this instance cancel. can be null
		/// </summary>
		/// <value><c>true</c> if this instance cancel; otherwise, <c>false</c>.</value>
		public string Cancel { get; set;}

		/// <summary>
		/// Gets or sets the destruction. can be null
		/// </summary>
		/// <value>The destruction.</value>
		public string Destruction { get; set;}

		/// <summary>
		/// Gets or sets the items to display in the list
		/// </summary>
		/// <value>The items.</value>
		public string[] Items { get; set; }

		/// <summary>
		/// Gets or sets the on completed action
		/// </summary>
		/// <value>The on completed.</value>
		public Action<string> OnCompleted { get; set; }
	}

	/// <summary>
	/// Messaging service question.
	/// </summary>
	public class MessagingServiceQuestion
	{
		/// <summary>
		/// Init this instance.
		/// </summary>
		public static void Init()
		{
			var time = DateTime.UtcNow;
		}

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {get;set;}

		/// <summary>
		/// Gets or sets the question.
		/// </summary>
		/// <value>The question.</value>
		public string Question { get; set; }

		/// <summary>
		/// Gets or sets the positive button text.
		/// </summary>
		/// <value>The positive.</value>
		public string Positive { get; set; }

		/// <summary>
		/// Gets or sets the negative button text
		/// </summary>
		/// <value>The negative.</value>
		public string Negative { get; set; }

		/// <summary>
		/// Gets or sets the OnCompleted Action&lt;bool&gt;.
		/// </summary>
		/// <value>The OnCompleted Action&lt;bool&gt;.</value>
		public Action<bool> OnCompleted { get; set; }
	}
}

