namespace TestAuthMacOSNET6;

public partial class ViewController : NSViewController {
	public ViewController (IntPtr handle) : base (handle)
	{
	}

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		try {
			AuthTester.RunTest ();
		} catch (Exception ex) {
			ShowError (ex.Message);
		}
	}

	public override NSObject RepresentedObject {
		get => base.RepresentedObject;
		set {
			base.RepresentedObject = value;

			// Update the view, if already loaded.
		}
	}

	static void ShowError (string message)
	{
		using (var alert = new NSAlert ()) {
			alert.MessageText = message;
			alert.RunModal ();
		}
	}
}
