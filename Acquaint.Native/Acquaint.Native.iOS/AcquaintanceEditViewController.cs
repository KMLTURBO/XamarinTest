using System;
using Acquaint.Data;
using UIKit;

namespace Acquaint.Native.iOS
{
	public partial class AcquaintanceEditViewController : UIViewController
	{
		/// <summary>
		/// Gets or sets the acquaintance.
		/// </summary>
		/// <value>The acquaintance.</value>
		public Acquaintance Acquaintance { get; set; }

		public AcquaintanceEditViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


