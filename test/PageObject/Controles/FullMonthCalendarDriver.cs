using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PageObject.Controles
{
    public class FullMonthCalendarDriver: 
        ControlDriverBase, 
        IKeyAccessItemsControlDriver<FullMonthCalendarDriver.Key, FullCalendarDayItemDriver>
    {
        TimeSpan? _timeout;

        public FullMonthCalendarDriver(IWebElement element) : base(element)
        {
        }

        public FullMonthCalendarDriver(IWebElement element, TimeSpan? timeout) : base(element)
        {
            _timeout = timeout;
        }

        private IWebElement TraverseRoot
        {
            get
            {
                return this.Element.FindElement(By.CssSelector(".fc-dayGridMonth-view"));
            }
        }

        public Key[] VisibleItemKeys
        {
            get
            {
                var result = JS.ExecuteScript(@"
const root = arguments[0];
const events = [...root.querySelectorAll('.fc-daygrid-day')].map(el => {
    const date = el.dataset.date + '';
    if(!date) return [];
    const dateParts = date.split('-');
    const evs = el.querySelectorAll('.fc-daygrid-day-events > .fc-daygrid-event-harness');
    return [...Array(evs.length).keys()].map(i => {
        return {
            Year: Number.parseInt(dateParts[0], 10),
            Month: Number.parseInt(dateParts[1], 10),
            Day: Number.parseInt(dateParts[2], 10),
            Index: i
        };
    });
}).flat();
return events;
", this.TraverseRoot);
                var data = ((ReadOnlyCollection<object>)result).Cast<Dictionary<string, object>>().Select(v =>
                    new Key(Convert.ToInt32(v["Year"]),
                            Convert.ToInt32(v["Month"]),
                            Convert.ToInt32(v["Day"]),
                            Convert.ToInt32(v["Index"])));

                return data.ToArray();
            }
        }

        public FullCalendarDayItemDriver GetItem(Key key)
        {
            throw new NotImplementedException();
        }

        public string ToArgumentCode(Key key)
        {
            throw new NotImplementedException();
        }

        public static implicit operator FullMonthCalendarDriver(ElementFinder finder)
        {
            var element = finder.Find();
            return new FullMonthCalendarDriver(element, finder.Timeout);
        }

        public class Key
        {
            public Key(int year, int month, int day, int index)
            {
                Year = year;
                Month = month;
                Day = day;
                Index = index;
            }

            public int Year { get; }
            public int Month { get; }
            public int Day { get; }
            public int Index { get; }
        }
    }
}
