using Foundation;
using MobileCoreServices;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UIKit;

namespace DocPicker
{
    public partial class ViewController : UIViewController
    {
        private string[] allowedUTIs =  {
                    UTType.UTF8PlainText,
                    UTType.PlainText,
                    UTType.RTF,
                    UTType.PNG,
                    UTType.Text,
                    UTType.PDF,
                    UTType.Image
                };

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnDirectPick_TouchUpInside(UIButton sender)
        {
            var picker = new UIDocumentPickerViewController(allowedUTIs, UIDocumentPickerMode.Open);
            picker.WasCancelled += Picker_WasCancelled;
            picker.DidPickDocumentAtUrls += (object s, UIDocumentPickedAtUrlsEventArgs e) =>
            {
                Console.WriteLine("url = {0}", e.Urls[0].AbsoluteString);
                //bool success = await MoveFileToApp(didPickDocArgs.Url);
                var success = true;
                string filename = e.Urls[0].LastPathComponent;
                string msg = success ? string.Format("Successfully imported file '{0}'", filename) : string.Format("Failed to import file '{0}'", filename);

                NSData data = NSData.FromUrl(e.Urls[0]);
                byte[] dataBytes = new byte[data.Length];

                System.Runtime.InteropServices.Marshal.Copy(data.Bytes, dataBytes, 0, Convert.ToInt32(data.Length));

                for (int i = 0; i < dataBytes.Length; i++)
                {
                    Console.WriteLine(dataBytes[i]);
                }

                Console.WriteLine(data + "Completed");

                var alertController = UIAlertController.Create("import", msg, UIAlertControllerStyle.Alert);
                var okButton = UIAlertAction.Create("OK", UIAlertActionStyle.Default, (obj) =>
                {
                    alertController.DismissViewController(true, null);
                });
                alertController.AddAction(okButton);
                PresentViewController(alertController, true, null);
            };



            PresentViewController(picker, true, null);
        }
        public byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private void Picker_WasCancelled(object sender, EventArgs e)
        {
            Console.WriteLine("Picker was Cancelled");
        }
    }
}