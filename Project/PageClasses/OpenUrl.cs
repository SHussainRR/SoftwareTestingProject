using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Project.PageClasses
{
    public class OpenUrl
    {

        public IPage _page;
        public ILocator aboutUsLinkBtn;
        public ILocator aboutUsTitleText;

        public OpenUrl(IPage page)
        {
            _page = page;
        }


        public async Task gotoURL(string home)
        {
            await _page.GotoAsync(home);
        }




    }
}
