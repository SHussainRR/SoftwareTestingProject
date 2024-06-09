using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Project.PageClasses
{
    internal class FooterClass
    {


        public IPage _page;
        public ILocator address;
        public ILocator aboutUsTitleText;
        public string actualText;

        public FooterClass(IPage page)
        {
            _page = page;
            address = page.Locator("//p[contains(text(),'Address: 2390 El Camino Real')]");
        }

        public async Task FooterExists()
        {
            Thread.Sleep(2000);
            actualText = await address.InnerTextAsync();
            Assert.That(actualText, Is.EqualTo("Address: 2390 El Camino Real"));

        }
    }
}
