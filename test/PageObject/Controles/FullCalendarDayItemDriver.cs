using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.AdjustBrowser;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject.Controles
{
    public class FullCalendarDayItemDriver : ControlDriverBase
    {
        public FullCalendarDayItemDriver(IWebElement element) : base(element)
        {
        }

        public FullCalendarDayItemDriver(IWebElement element, DateTime targetDay) : base(element)
        {
            TargetDay = targetDay;
        }

        public FullCalendarDayItemDriver(IWebElement element, Action wait, DateTime targetDay) : base(element)
        {
            TargetDay = targetDay;
            Wait = wait;
        }

        public Action Wait { get; set; }

        [CaptureCodeGenerator]
        public string GetWebElementCaptureGenerator()
        {
            return $@"
                    element.addEventListener('click', function() {{ 
                      var name = __codeerTestAssistantPro.getElementName(this);
                      __codeerTestAssistantPro.pushCode(name + '.Click();');
                    }}, false);";
        }

        public DateTime? TargetDay { get; } = null;

        public void Click()
        {
            Element.Show();
            Element.Focus();
            Element.ClickEx();
            Wait?.Invoke();
        }
    }
}
