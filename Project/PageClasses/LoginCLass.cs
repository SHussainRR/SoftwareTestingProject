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
    public class LoginClass
    {
        public IPage _page;
        public ILocator loginLinkbtn;
        public ILocator UserName;
        public ILocator Password;
        public ILocator LoginButton;

        public ILocator actualSuccessText;
        string expectedText = "Welcome huss.raza97@gmail.com";
        string actualText = string.Empty;
        private string _dialogMessage;


        public LoginClass (IPage page)
        {
            _page = page;
            loginLinkbtn = page.Locator("#login2");
            UserName = page.Locator("#loginusername");
            Password = page.Locator("#loginpassword");
            LoginButton = page.Locator("//button[contains(text(),'Log in')]");
            actualSuccessText = page.Locator("//a[@id='nameofuser']");

            _dialogMessage = string.Empty; 
            _page.Dialog += async (_, dialog) =>
            {
                _dialogMessage = dialog.Message;
                Thread.Sleep(1000);
                await dialog.AcceptAsync();
            };



        }

        public async Task gotoURL(string home)
        {
            await _page.GotoAsync(home);
        }

        public async Task LoginSucessesful(string user, string passcode)
        {
            Thread.Sleep(1000);
            await loginLinkbtn.ClickAsync();
            await UserName.FillAsync(user);
            await Password.FillAsync(passcode);
            await LoginButton.ClickAsync();
 
            Thread.Sleep(4000);

            actualText = await actualSuccessText.InnerTextAsync();
            Thread.Sleep(4000);
            Assert.That(expectedText, Is.EqualTo(actualText));
            Thread.Sleep(1000);

        }


        public async Task LoginWithWrongPassword(string user, string passcode)
        {
            Thread.Sleep(1000);
            await loginLinkbtn.ClickAsync();
            await UserName.FillAsync(user);
            await Password.FillAsync(passcode);
            await LoginButton.ClickAsync();

            Thread.Sleep(2000);

            actualText = await actualSuccessText.InnerTextAsync();
            Thread.Sleep(2000);
            Assert.That(_dialogMessage, Is.EqualTo("Wrong password."));
            Thread.Sleep(1000);

        }


    }
}