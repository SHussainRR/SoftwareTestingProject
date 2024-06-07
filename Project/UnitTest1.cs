using System.Security.Principal;
using System;
using System.Threading;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PomModelPlaywright.PageClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class Tests
    {

        IPlaywright playwright;
        IPage page;
        LoginClass logincLass = null;
        public JObject jsonLocatorData = JObject.Parse(File.ReadAllText("E:\\Working Repositories\\SQA\\Project\\Project\\Json\\data.json"));

        [Test]
        public async Task Test1()
        {


            playwright = await Playwright.CreateAsync();
            {


                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {

                    Headless = false,

                });
                page = await browse.NewPageAsync();                
                logincLass = new LoginClass(page);

                await logincLass.gotoURL(jsonLocatorData["url"].ToString());
                await logincLass.LoginSucessesful(jsonLocatorData["username"].ToString(), jsonLocatorData["password"].ToString());
                Thread.Sleep(1000);

            }
            Assert.Pass();

        }
        /*    [Test]
            public async Task Test2()
            {
                playwright = await Playwright.CreateAsync();
                {


                    var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {

                        Headless = false,

                    });
                    page = await browse.NewPageAsync();

                    CheckoutAsync = new CheckoutClass(page);
                    await CheckoutAsync.gotoURL(jsonLocatorData["url"].ToString());
                    await CheckoutAsync.CheckoutFunction();
                    //await logincLass.("standard_user", "secret_sauce");

                }
                Assert.Pass();
            }
        }*/
    }
}