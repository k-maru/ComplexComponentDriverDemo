using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Pages;
using System;

namespace Scenario
{
    public class TAPTest
    {
        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://localhost:50538/";
        }

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [TestCase]
        public void イベントを追加するとカレンダーに表示される()
        {
            var indexPage = _driver.AttachIndexPage();
            indexPage.select.Edit("02");
            indexPage.input.Edit("新しいイベント");
            indexPage.addbutton.Click();

            var now = DateTime.Now;
            var eventElemnt = indexPage.calendar.GetItem(
                new PageObject.Controles.FullMonthCalendarDriver.Key(now.Year, now.Month, 2, 0));
            Assert.IsNotNull(eventElemnt);
        }

        [TestCase]
        public void イベントを選択するとイベント名がメッセージに表示される()
        {
            var indexPage = _driver.AttachIndexPage();
            indexPage.calendar.GetItem(new PageObject.Controles.FullMonthCalendarDriver.Key(2021, 1, 7, 0)).Click();
            Assert.AreEqual("Long Event", indexPage.message.Text);
        }
    }
}
