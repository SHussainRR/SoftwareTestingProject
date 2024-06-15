using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Project.PageClasses
{
    public class AboutUsCLass:CommonClass
    {

        public IPage _page;
        public ILocator aboutUsLinkBtn;
        public ILocator aboutUsTitleText;

        public AboutUsCLass(IPage page):base(page)  
        {
            _page = page;
            aboutUsLinkBtn = page.Locator("//a[contains(text(),'About us')]");
            aboutUsTitleText = page.Locator("//h5[contains(text(),'About us')]");
        }

        public async Task aboutUsPageExists(string expText)
        {

            await aboutUsLinkBtn.ClickAsync();
            Thread.Sleep(2000);
            Assert.That(expText, Is.EqualTo("About Us"));

        }








    }
    }


