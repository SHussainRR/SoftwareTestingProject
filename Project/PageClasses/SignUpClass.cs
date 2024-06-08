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
    public class SignUpClass
    {
        public IPage _page;
        public ILocator signupLinkBtn;
        public ILocator singnupUsername;
        public ILocator singupPassword;
        public ILocator singnupBtn;
        public ILocator signupBtn;
        private string _dialogMessage;

        public SignUpClass(IPage page)
        {
            _page = page;
            signupLinkBtn = page.Locator("//a[@id='signin2']");
            singnupUsername = page.Locator("//input[@id='sign-username']");
            singupPassword = page.Locator("//input[@id='sign-password']");
            singnupBtn = page.Locator("//button[contains(text(),'Sign up')]");


           



        }

        public async Task singupTask(string user, string passcode)
        {
            
            await signupLinkBtn.ClickAsync();
            await singnupUsername.FillAsync(user);
            await Task.Delay(2000);
            await singupPassword.FillAsync(passcode);

            
            await signupBtn.ClickAsync();
            await Task.Delay(2000);

           




        }

        public async Task gotoURL(string home)
        {
            await _page.GotoAsync(home);
        }




    }
}
