using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Controles
{
    public class SpanDriver : ControlDriverBase
    {
        public SpanDriver(IWebElement element) : base(element) { }

        public string Text => Element.Text;

        public static implicit operator SpanDriver(ElementFinder finder) => finder.Find<SpanDriver>();

        [TargetElementInfo]
        public static TargetElementInfo TargetElement => new TargetElementInfo("span");
    }
}
