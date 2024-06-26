using System.Security.Principal;
using System;
using System.Threading;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using Project.PageClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Allure.NUnit;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {

        IPlaywright playwright;
        IPage page;
        LoginClass logincLass = null;
        SignUpClass signupclass = null;
        AboutUsCLass aboutusclass = null;
        OpenUrl openurl = null;
        ContactUs contactus = null;
        FooterClass footerclass = null;


        

        public JObject jsonLocatorData = JObject.Parse(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json\\data.json")));

        [Test]
        public async Task Test0_WebPageExists()
        {

            
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,

                });
                page = await browse.NewPageAsync();

                openurl = new OpenUrl(page);
                await openurl.PageExists(jsonLocatorData["url"].ToString());

                await page.CloseAsync();

            }
            Assert.Pass();
        }





        [Test]
        public async Task Test1_LoginInTest()
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
        public async Task Test2_SignupTest1()
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
        public async Task test3_SignupTestFail()
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
        public async Task Test4_AboutusPageExists()
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


        [Test]
        public async Task Test5_ContactusFormSubmission()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,

                });
                page = await browse.NewPageAsync();

                openurl = new OpenUrl(page);
                await openurl.PageExists(jsonLocatorData["url"].ToString());

                contactus = new ContactUs(page);

                await contactus.ContactUsFuncCheck(jsonLocatorData["username"].ToString(), jsonLocatorData["password"].ToString(), jsonLocatorData["contactMessage"].ToString());
                await page.CloseAsync();

            }
            Assert.Pass();
        }

        [Test]
        public async Task Test6_LoginWithWrongPass()
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
                await logincLass.LoginWithWrongPassword(jsonLocatorData["username"].ToString(), jsonLocatorData["wrongPassword"].ToString());
                Thread.Sleep(1000);
                await page.CloseAsync();
            }
            Assert.Pass();

        }

        [Test]
        public async Task Test7_FooterExists()
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
                
                footerclass= new FooterClass(page);

                await footerclass.FooterExists();
                Thread.Sleep(1000);
                await page.CloseAsync();
            }
            Assert.Pass();

        }


        [Test]
        public async Task Test8_AddCart()
        {


            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                var response = await addCart.TaskAddTocart();



                Assert.AreEqual(response, "Products");

                Thread.Sleep(1000);
                await page.CloseAsync();


            }
        }

        [Test]
        public async Task Test9_PlaceOrderClick()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                //for clicking cart
                _= await addCart.TaskAddTocart();
                var response = await addCart.PlaceOrderPage();
                Assert.AreEqual(response, "Place order");
                await page.CloseAsync();


            }

        }
        [Test]
        public async Task Test10_EnterValidValue()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                //for clicking cart
                _ = await addCart.TaskAddTocart();
                var response = await addCart.PlaceOrderPage();
                Assert.AreEqual(response, "Place order");
                await page.CloseAsync();


            }

        }

        [Test]
        public async Task Test11_EmptyBox()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                //for clicking cart
                _ = await addCart.TaskAddTocart();
                await addCart.PlaceOrderPage();
                await addCart.ClickPurchase();
                Assert.AreEqual(addCart._dialogMessage, "Please fill out Name and Creditcard.");
                await page.CloseAsync();


            }

        }
        [Test]
        public async Task Test12_FillBox()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                //for clicking cart
                _ = await addCart.TaskAddTocart();
                await addCart.PlaceOrderPage();
                await addCart.FillForm();
                await addCart.ClickPurchase();
                var reponse=await addCart.ThankYouText();
                Assert.AreEqual(reponse, "Thank you for your purchase!");
                await page.CloseAsync();


            }

        }
        [Test]
        public async Task Test13_RedirecttoHome()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                //for clicking cart
                _ = await addCart.TaskAddTocart();
                await addCart.PlaceOrderPage();
                await addCart.FillForm();
                await addCart.ClickPurchase();
                //await addCart.ThankYouText();
                var response= await addCart.okCLick();
                Assert.AreEqual(response, "CATEGORIES");
                await page.CloseAsync();


            }

        }

        [Test]
        public async Task Test14_ClickCLose()
        {
            playwright = await Playwright.CreateAsync();
            {
                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });
                page = await browse.NewPageAsync();

                var addCart = new AddToCart(page, jsonLocatorData);
                await addCart.gotoURL(jsonLocatorData["url"].ToString());
                //for clicking cart
                _ = await addCart.TaskAddTocart();
                await addCart.PlaceOrderPage();
                await addCart.FillForm();
                await addCart.ClickCLose();
                
                Assert.Pass();


            }

        }

    }
}
