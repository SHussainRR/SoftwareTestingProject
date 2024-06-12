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

        public ILocator actualSuccessText;
        string expectedText = "Welcome huss.raza97@gmail.com";
        string actualText = string.Empty;
        private string _dialogMessage;
        private JObject _jObject;

        public AddToCart(IPage page, JObject jsonLocatorData) : base(page)
        {
            _page = page;
            _jObject = jsonLocatorData;

           
            CartBtn = page.Locator(_jObject["cartBtnID"].ToString());
            CartHeading = page.Locator(_jObject["cartPageHeading"].ToString());
            PlaceOrder = page.Locator(_jObject["PlaceOrder"].ToString());
            PlaceOrderModalText = page.Locator(_jObject["PlaceOrderModalText"].ToString());
          
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
    }
}
