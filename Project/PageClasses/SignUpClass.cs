using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Project.PageClasses
{
    public class SignUpClass: CommonClass
    {
        public IPage _page;
        public ILocator signupLinkBtn;
        public ILocator singnupUsername;
        public ILocator singupPassword;
        public ILocator singnupBtn;
        public ILocator signupBtn;
        private string _dialogMessage;

        public SignUpClass(IPage page) : base(page)
        {
            _page = page;
            signupLinkBtn = page.Locator("//a[@id='signin2']");
            singnupUsername = page.Locator("//input[@id='sign-username']");
            singupPassword = page.Locator("//input[@id='sign-password']");
            signupBtn = page.Locator("//button[contains(text(),'Sign up')]");


            _dialogMessage = string.Empty; // Initialize _dialogMessage
            _page.Dialog += async (_, dialog) =>
            {
                _dialogMessage = dialog.Message;
                Thread.Sleep(1000);
                await dialog.AcceptAsync();  // You can choose to accept or dismiss the dialog
            };

        }

        public async Task singupSuccessfull(string user, string passcode)
        {
            
            await signupLinkBtn.ClickAsync();
            await singnupUsername.FillAsync(user);
            await Task.Delay(2000);
            await singupPassword.FillAsync(passcode);

            
            await signupBtn.ClickAsync();
            await Task.Delay(1000);

            if (_dialogMessage == "Expected dialog message")
            {
                Console.WriteLine("Strings match");
            }

            Assert.That(_dialogMessage, Is.EqualTo("This user already exist."));

        }


        public async Task singupSuccessFail(string user, string passcode)
        {

            await signupLinkBtn.ClickAsync();
            await singnupUsername.FillAsync(user);
            await Task.Delay(2000);
            await singupPassword.FillAsync(passcode);


            await signupBtn.ClickAsync();
            await Task.Delay(1000);

            if (_dialogMessage == "Expected dialog message")
            {
                Console.WriteLine("Strings match");
            }

            Assert.That(_dialogMessage, Is.EqualTo("Sign up successful."));

        }


       



    }
}
