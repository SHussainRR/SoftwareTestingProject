using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.PageClasses
{
    public class CommonClass
    {
        IPage _page;
        public CommonClass(IPage _page) { 
        
            this._page = _page;
        }
        public async Task gotoURL(string home)
        {
            await _page.GotoAsync(home);
        }

    }
}
