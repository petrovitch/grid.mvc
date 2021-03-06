﻿using System.IO;
using System.Web;
using GridMvc.Pagination;
using NUnit.Framework;
using PowerAssert;

namespace GridMvc.Tests.Pagination
{
    [TestFixture]
    public class GridPagerTests
    {
        private GridPager _pager;

        [SetUp]
        public void Init()
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
            _pager = new GridPager();
        }

        [Test]
        public void PagerPageCountTest()
        {
            _pager.ItemsCount = 1200;
            _pager.PageSize = 13;

            PAssert.IsTrue(() => _pager.PageCount == 93);
        }

        [Test]
        public void PagerDisplayingPagesTest()
        {
            _pager.ItemsCount = 1200;
            _pager.PageSize = 13;

            _pager.MaxDisplayedPages = 5;
            _pager.CurrentPage = 40;

            PAssert.IsTrue(() => _pager.TemplateName == "_GridPager");
            PAssert.IsTrue(() => _pager.StartDisplayedPage == 38);
            PAssert.IsTrue(() => _pager.EndDisplayedPage == 42);
        }

        [Test]
        public void PagerCurrentPageTest()
        {
            _pager.ItemsCount = 1200;
            _pager.PageSize = 13;
            _pager.CurrentPage = 1000;

            PAssert.IsTrue(() => _pager.PageCount == _pager.CurrentPage);
        }


    }
}
