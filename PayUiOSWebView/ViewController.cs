using System;
using System.Security.Cryptography;
using System.Text;
using Foundation;
using UIKit;
using Exception = System.Exception;
using StringBuilder = System.Text.StringBuilder;

namespace PayUiOSWebView
{
    public partial class ViewController : UIViewController, IUIWebViewDelegate
    {
        private static string SUCCESS_URL = "https://www.payumoney.com/mobileapp/payumoney/success.php";
        private static string FAILED_URL = "https://www.payumoney.com/mobileapp/payumoney/failure.php";
        private static string firstname = "Logesh Palani";
        private static string email = "logesh@hakunamatata.in";
        private static string productInfo = "test";
        private static string mobile = "7200606860";
        public static string totalAmount = "100";

        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var webView = new UIWebView(this.View.Frame);

            webView.Delegate = this;

            View.AddSubview(webView);

            StringBuilder builder = new StringBuilder();
            builder.Append("https://test.payu.in/_payment");

            var urlReq = new NSMutableUrlRequest(NSUrl.FromString(builder.ToString()));
            urlReq.HttpMethod = "POST";
            NSMutableDictionary dic = new NSMutableDictionary();
            dic.Add(new NSString("Content-Type"), new NSString("application/json"));
            urlReq.Headers = dic;

            urlReq.Body = NSData.FromString(GetPostString());
            webView.LoadRequest(urlReq);
        }

        [Export("webView:shouldStartLoadWithRequest:navigationType:")]
        public bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            if (NSUrl.FromString("https://www.payumoney.com/mobileapp/payumoney/success.php") == request.Url)
            {
                //TODO Payment Success Event

                var okAlertController = UIAlertController.Create("Success", "Payment Successfully Completed", UIAlertControllerStyle.Alert);

                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                PresentViewController(okAlertController, true, null);
            }
            else if (NSUrl.FromString("https://www.payumoney.com/mobileapp/payumoney/failure.php") == request.Url)
            {
                // TODO Payment failure event

                var okAlertController = UIAlertController.Create("Failed", "Payment Failed and retry after sometime", UIAlertControllerStyle.Alert);

                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                PresentViewController(okAlertController, true, null);
            }

            return true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private string GetPostString()
        {
            string TxtStr = Generate();
            string txnid = GetHashString(TxtStr).Substring(0, 20);
            txnid = "TXN" + txnid;
            string key = "gtKFFx";  //Key 
            string salt = "eCwWELxi"; //salt
            StringBuilder post = new StringBuilder();
            post.Append("key=");
            post.Append(key);
            post.Append("&");
            post.Append("txnid=");
            post.Append(txnid);
            post.Append("&");
            post.Append("amount=");
            post.Append(totalAmount);
            post.Append("&");
            post.Append("productinfo=");
            post.Append(productInfo);
            post.Append("&");
            post.Append("firstname=");
            post.Append(firstname);
            post.Append("&");
            post.Append("email=");
            post.Append(email);
            post.Append("&");
            post.Append("phone=");
            post.Append(mobile);
            post.Append("&");
            post.Append("surl=");
            post.Append(SUCCESS_URL);
            post.Append("&");
            post.Append("furl=");
            post.Append(FAILED_URL);
            post.Append("&");

            StringBuilder checkSumStr = new StringBuilder();

            string hash;

            try
            {
                checkSumStr.Append(key);
                checkSumStr.Append("|");
                checkSumStr.Append(txnid);
                checkSumStr.Append("|");
                checkSumStr.Append(totalAmount);
                checkSumStr.Append("|");
                checkSumStr.Append(productInfo);
                checkSumStr.Append("|");
                checkSumStr.Append(firstname);
                checkSumStr.Append("|");
                checkSumStr.Append(email);
                checkSumStr.Append("|||||||||||");
                checkSumStr.Append(salt);
                hash = GetHashString(checkSumStr.ToString());
                post.Append("hash=");
                post.Append(hash.ToLower());
                post.Append("&");
            }
            catch (Exception e1)
            {
            }
            post.Append("service_provider=");
            post.Append("");

            return post.ToString();
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA512.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string Generate()
        {
            long ticks = DateTime.Now.Ticks;
            System.Threading.Thread.Sleep(200);
            Random rnd = new Random();
            string rndm = (rnd.Next()) + (DateTime.Now.Ticks - ticks / 1000).ToString();
            string txnid = GetHashString(rndm).Substring(0, 20);
            return txnid;
        }
    }
}