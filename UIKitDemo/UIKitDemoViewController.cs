using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UIKitDemo
{
	public partial class UIKitDemoViewController : UIViewController
	{
	

		public UIKitDemoViewController () : base ("UIKitDemoViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			
			View.BackgroundColor = UIColor.DarkGray;

			var animation = new UIDynamicAnimator (this.View);

			UIView rec = new UIView (new RectangleF (new PointF (20f, 10f), new SizeF (25f, 25f))) {

				BackgroundColor = UIColor.Red

			};

			View.Add (rec);

			UIPushBehavior push = new UIPushBehavior (UIPushBehaviorMode.Continuous, rec);
			push.PushDirection = new MonoTouch.CoreGraphics.CGVector (0f, 1f);


			var collide = new UICollisionBehavior (rec) {

				TranslatesReferenceBoundsIntoBoundary = true

			};

			var elastic = new UIDynamicItemBehavior (rec) {

				Elasticity = 0.7f

			};

			collide.BeganBoundaryContact += (sender, e) => {

				rec.BackgroundColor = UIColor.Yellow;

			};

			animation.AddBehaviors (push, collide, elastic);

		}
	}
}

