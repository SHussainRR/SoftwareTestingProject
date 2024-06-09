using System.Security.Principal;
using System;
using System.Threading;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using Project.PageClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class Tests
    {

        IPlaywright playwright;
        IPage page;
        LoginClass logincLass = null;
        SignUpClass signupclass = null;
        AboutUsCLass aboutusclass = null;
        OpenUrl openurl = null;

        public JObject jsonLocatorData = JObject.Parse(File.ReadAllText("E:\\Working Repositories\\SQA\\Project\\Project\\Json\\data.json"));


        [Test]
        public async Task LoginInTest()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();
                logincLass = new LoginClass(page);

                openurl = new OpenUrl(page);
                await openurl.gotoURL(jsonLocatorData["url"].ToString());
                await logincLass.LoginSucessesful(jsonLocatorData["username"].ToString(), jsonLocatorData["password"].ToString());
                Thread.Sleep(1000);
                await page.CloseAsync();



            }
            Assert.Pass();
            
        }


        [Test]
        public async Task SignupTest1()
        {
            playwright = await Playwright.CreateAsync();
            {


                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {

                    Headless = false,

                });
                page = await browse.NewPageAsync();

                signupclass = new SignUpClass(page);

                openurl = new OpenUrl(page);
                await openurl.gotoURL(jsonLocatorData["url"].ToString());
                await signupclass.singupSuccessfull(jsonLocatorData["username"].ToString(), jsonLocatorData["password"].ToString());

                Thread.Sleep(2000);
                await page.CloseAsync();

            }
            Assert.Pass();
        }



        [Test]
        public async Task SignupTestFail()
        {
            playwright = await Playwright.CreateAsync();
            {


                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {

                    Headless = false,

                });
                page = await browse.NewPageAsync();

                signupclass = new SignUpClass(page);

                openurl = new OpenUrl(page);
                await openurl.gotoURL(jsonLocatorData["url"].ToString());
                await signupclass.singupSuccessFail(jsonLocatorData["username"].ToString(), jsonLocatorData["password"].ToString());

                Thread.Sleep(2000);
                await page.CloseAsync();

            }
            Assert.Pass();
        }



        [Test]
        public async Task AboutusPageExists()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,

                });
                page = await browse.NewPageAsync();

                openurl = new OpenUrl(page);
                await openurl.gotoURL(jsonLocatorData["url"].ToString());

                aboutusclass = new AboutUsCLass(page);

                await aboutusclass.aboutUsPageExists(jsonLocatorData["aboutUsExpectText"].ToString());

                Thread.Sleep(2000);
                await page.CloseAsync();

            }
            Assert.Pass();
        }


    }
}
