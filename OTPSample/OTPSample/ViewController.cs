using Foundation;
using System;
using UIKit;

namespace OTPSample
{
    public partial class ViewController : UIViewController, IUITextFieldDelegate
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            fieldOne.Delegate = this;
            fieldTwo.Delegate = this;
            fieldThree.Delegate = this;
            fieldFour.Delegate = this;

            fieldOne.BackgroundColor = UIColor.Clear;
            fieldTwo.BackgroundColor = UIColor.Clear;
            fieldThree.BackgroundColor = UIColor.Clear;
            fieldFour.BackgroundColor = UIColor.Clear;

        }

        [Export("textField:shouldChangeCharactersInRange:replacementString:")]
        public bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
        {
            if (textField.Text?.Length < 1 && replacementString.Length > 0)
            {
                if (textField == fieldOne)
                    fieldTwo.BecomeFirstResponder();
                else if (textField == fieldTwo)
                    fieldThree.BecomeFirstResponder();
                else if (textField == fieldThree)
                    fieldFour.BecomeFirstResponder();
                else if (textField == fieldFour)
                    fieldFour.ResignFirstResponder();

                textField.Text = replacementString;
                return false;
            }
            else if (textField.Text?.Length >= 1 && replacementString.Length == 0)
            {
                if (textField == fieldTwo)
                    fieldOne.BecomeFirstResponder();
                else if (textField == fieldThree)
                    fieldTwo.BecomeFirstResponder();
                else if (textField == fieldFour)
                    fieldThree.BecomeFirstResponder();
                else if (textField == fieldOne)
                    fieldOne.BecomeFirstResponder();

                textField.Text = "";
                return false;
            }
            else if (textField.Text?.Length >= 1)
            {
                textField.Text = replacementString;
                return false;
            }
            return true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}