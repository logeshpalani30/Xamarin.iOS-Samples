// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using UIKit;

namespace TableViewSample
{
    public partial class SampleViewController : UIViewController
    {
        private static List<ContactModel> data = new List<ContactModel>()
        {
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." },
                new ContactModel() {  Name = "Logesh", MobileNumber = "Associate Software Developer. I am .Net Profession and Xamarin developer. C# Corner MVP." }
        };

        public SampleViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tableView.Source = new SampleTableViewSource(data);

        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
