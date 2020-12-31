using OpenQA.Selenium;
using PageObject.Controles;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject.Pages
{
    public class IndexPage : PageBase
    {
        // public SpanDriver year => ByCssSelector("span[class='year']").Wait();
        // public FullMonthCalendarDriver calendar => ById("calendar").Wait();
        // public SpanDriver month => ByCssSelector("span[class='month']").Wait();
        public DropDownListDriver select => ByTagName("select").Wait();
        public TextBoxDriver input => ByTagName("input").Wait();
        public ButtonDriver addbutton => ById("addbutton").Wait();

        public IndexPage(IWebDriver driver) : base(driver) { }
    }

    public static class IndexPageExtensions
    {
        [PageObjectIdentify(TitleComapreType.Equals, "Calendar")]
        public static IndexPage AttachIndexPage(this IWebDriver driver)
        {
            driver.WaitForTitle(TitleComapreType.Equals, "Calendar");
            return new IndexPage(driver);
        }
    }
}