using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Playwright;

namespace Project.PageClasses
{
    public class OpenUrl: CommonClass
    {

        public IPage _page;
        public ILocator aboutUsLinkBtn;
        public ILocator aboutUsTitleText;

        public OpenUrl(IPage page):base(page)
        {
            _page = page;
        }


        public async Task PageExists(string home)
        {
            var response = await _page.GotoAsync(home);
            Thread.Sleep(1000);
            // Check if the response status is 200
            Assert.That(response.Status, Is.EqualTo(200));
        }




    }
}
