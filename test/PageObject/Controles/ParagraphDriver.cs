using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Controles
{
    public class ParagraphDriver : ControlDriverBase
    {
        public ParagraphDriver(IWebElement element) : base(element) { }

        public string Text => Element.Text;

        public static implicit operator ParagraphDriver(ElementFinder finder) => finder.Find<ParagraphDriver>();

        [TargetElementInfo]
        public static TargetElementInfo TargetElement => new TargetElementInfo("p");
    }
}
