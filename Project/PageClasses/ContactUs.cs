using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Project.PageClasses
{
    public class ContactUs
    {
        public IPage _page;
        public ILocator contactLinkbtn;
        public ILocator contactEmail;
        public ILocator contactName;
        public ILocator message;
        public ILocator sendMsgBtn;
        private string _dialogMessage;






        public ContactUs(IPage page) {

            _page = page;
            contactLinkbtn= page.Locator("//a[contains(text(),'Contact')]");
            contactEmail = page.Locator("//input[@id='recipient-email']");
            contactName = page.Locator("//input[@id='recipient-name']");
            message = page.Locator("//textarea[@id='message-text']");
            sendMsgBtn = page.Locator("//button[contains(text(),'Send message')]");


            _dialogMessage = string.Empty; // Initialize _dialogMessage
            _page.Dialog += async (_, dialog) =>
            {
                _dialogMessage = dialog.Message;
                Thread.Sleep(1000);
                await dialog.AcceptAsync();  // You can choose to accept or dismiss the dialog
            };


        }

        public async Task ContactUsFuncCheck(string email, string name , string msg)
        {

            
            await contactLinkbtn.ClickAsync();
            await contactEmail.FillAsync(email);
            await contactName.FillAsync(name);
            Thread.Sleep(1000);
            await message.FillAsync(msg);
            await sendMsgBtn.ClickAsync();
            Thread.Sleep(2000);

            if (_dialogMessage == "Thanks for the message!!")
            {
                Console.WriteLine("Strings match");
            }

            Thread.Sleep(2000);
            Assert.That(_dialogMessage, Is.EqualTo("Thanks for the message!!"));


        }
    }
}
