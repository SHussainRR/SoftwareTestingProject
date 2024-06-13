using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.PageClasses
{
    public class AddToCart:CommonClass
    {
        public IPage _page;
        public ILocator CartBtn;
        public ILocator CartHeading;
        public ILocator PlaceOrder;
        public ILocator PlaceOrderModalText;
        public ILocator btnPurchase;

        public ILocator Formname;
        public ILocator Formcountry;
        public ILocator Formcity;
        public ILocator Formcard;
        public ILocator Formmonth;
        public ILocator Formyear;




        public ILocator actualSuccessText;
        string expectedText = "Welcome huss.raza97@gmail.com";
        string actualText = string.Empty;
        public string _dialogMessage;
        private JObject _jObject;

        public AddToCart(IPage page, JObject jsonLocatorData) : base(page)
        {
            _page = page;
            _jObject = jsonLocatorData;

           
            CartBtn = page.Locator(_jObject["cartBtnID"].ToString());
            CartHeading = page.Locator(_jObject["cartPageHeading"].ToString());
            PlaceOrder = page.Locator(_jObject["PlaceOrder"].ToString());
            PlaceOrderModalText = page.Locator(_jObject["PlaceOrderModalText"].ToString());
            btnPurchase = page.Locator(_jObject["btnPurchase"].ToString());


           

            _dialogMessage = string.Empty;
            _page.Dialog += async (_, dialog) =>
            {
                _dialogMessage = dialog.Message;
                Thread.Sleep(1000);
                await dialog.AcceptAsync();
            };



        }

        public async Task<string> TaskAddTocart() {

            //btn click
            await CartBtn.ClickAsync();
            //get text
            return await CartHeading.InnerTextAsync();
        }

        public async Task<string> PlaceOrderPage()
        {

            //btn click
            await PlaceOrder.ClickAsync();
            //get text
            return await PlaceOrderModalText.InnerTextAsync();
        }

        public async Task ClickPurchase()
        {

            await btnPurchase.ClickAsync();
            

        }

        public async Task FillForm()
        {

            Formname = _page.Locator(_jObject["Formname"].ToString());
            await Formname.FillAsync("my test name");
            Formcountry = _page.Locator(_jObject["Formcountry"].ToString());
            await Formcountry.FillAsync("my test country");
            Formcity = _page.Locator(_jObject["Formcity"].ToString());
            await Formcity.FillAsync("my test country");

            Formcard = _page.Locator(_jObject["Formcard"].ToString());
            await Formcard.FillAsync("111111222121212");

            Formmonth = _page.Locator(_jObject["Formmonth"].ToString());
            await Formmonth.FillAsync("JULY");

            Formyear = _page.Locator(_jObject["Formyear"].ToString());
            await Formyear.FillAsync("2024");


        }

        public async Task<string> ThankYouText() {

            return await _page.Locator(_jObject["thankyouTxt"].ToString()).InnerTextAsync();

            //h2[normalize-space()='Thank you for your purchase!']
        }

        public async Task<string> okCLick()
        {

            await _page.Locator(_jObject["okBTn"].ToString()).ClickAsync();

            Thread.Sleep(10000);
            return await _page.Locator(_jObject["indexCategory"].ToString()).InnerTextAsync();

            //h2[normalize-space()='Thank you for your purchase!']
        }

        public async Task ClickCLose()
        {

            await _page.Locator(_jObject["btnClose"].ToString()).ClickAsync();

            //h2[normalize-space()='Thank you for your purchase!']
        }
    }
}
