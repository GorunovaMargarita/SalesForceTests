

using BusinessObject.SalesForce.Model;
using Core;
using Core.Elements;
using Core.Helpers;
using OpenQA.Selenium;

namespace BusinessObject.SalesForce.UI.Pages
{
    public abstract class ActionsWithEntity : BasePage
    {
        internal Button actionButton { get; set; } = new(By.XPath("//td//a"));
       // internal Button actionSpanButton { get; set; } = new(By.XPath("//td//span[text() = 'Show more actions']"));
        //internal Button actionButton { get; set; } = new(By.CssSelector("div.forceVirtualActionMarker.forceVirtualAction"));
        //internal Button actionButton { get; set; } = new(By.XPath("//tbody/tr/td[6]"));
        internal Button deleteButton { get; set; } = new(By.XPath("//div[@role='menu']//a[@title='Delete']"));
        internal Button editButton { get; set; } = new(By.XPath("//div[@role='menu']//a[@title='Edit']"));
        internal Button confirmDeleteButton { get; set; } = new(By.XPath("//button[@title='Delete']//span"));

        internal BaseElement messageElement = new(By.XPath("//div[@role='alertdialog']//..//span[contains(@class, 'Message')]"));
        internal BaseElement tableRow = new(By.XPath("//tbody/tr"));

        /// <summary>
        /// Get message text about actions with entity
        /// </summary>
        /// <param name="element">Message element</param>
        /// <returns>Message text</returns>
        internal string GetMessageText(BaseElement element)
        {
            WaitHelper.WaitElementDisplayed(driver, element.Locator, 100);
            var text = driver.FindElement(element.Locator).Text;
            return text;
        }

        /// <summary>
        /// Change value input text attributes
        /// </summary>
        /// <typeparam name="T">Account or Contact</typeparam>
        /// <param name="entity">Account or contact with property new values</param>
        /// <param name="propertyName">Property name for change</param>
        /// <param name="input">Element Input</param>
        internal void ChangeTextValue<T>(T entity, string propertyName, Input input) where T : class
        {
            var valueMustBe = ReflectionHelper.GetPropertyValue(propertyName, entity);
            if (valueMustBe == input.GetElement().Text || valueMustBe == null)
                return;
            input.GetElement().Clear();
            input.EnterText(valueMustBe.ToString());
            Log.Instance.Logger.Info($"Property {propertyName} value changed to {valueMustBe}");
        }

        /// <summary>
        /// Change dropDown selected value
        /// </summary>
        /// <typeparam name="T">Account or Contact</typeparam>
        /// <param name="entity">Account or contact with property new values</param>
        /// <param name="propertyName">Property name for change</param>
        /// <param name="dropDown">Element DropDown</param>
        internal void ChangeDropDown<T>(T entity, string propertyName, DropDown dropDown) where T : class
        {
            var valueMustBe = ReflectionHelper.GetPropertyValue(propertyName, entity);
            if (valueMustBe == dropDown.GetElement().Text || valueMustBe == null)
                return;
            dropDown.Select(valueMustBe.ToString());
            Log.Instance.Logger.Info($"Property {propertyName} value changed to {valueMustBe}");
        }

        /// <summary>
        /// Change partialTextDropDown selected value
        /// </summary>
        /// <typeparam name="T">Account or Contact</typeparam>
        /// <param name="entity">Account or contact with property new values</param>
        /// <param name="propertyName">Property name for change</param>
        /// <param name="partialTextDropDown">Element PartialTextDropDown</param>
        internal void ChangePartDropDown<T>(T entity, string propertyName, PartialTextDropDown partialTextDropDown) where T : class
        {
            var valueMustBe = ReflectionHelper.GetPropertyValue(propertyName, entity);
            if (valueMustBe == partialTextDropDown.GetElement().Text || valueMustBe == null)
                return;
            if (propertyName.Equals("ParentAccount") && !String.IsNullOrEmpty(partialTextDropDown.GetElement().GetAttribute("value")))
                partialTextDropDown.Clear();
            partialTextDropDown.Select(valueMustBe.ToString());
            Log.Instance.Logger.Info($"Property {propertyName} value changed to {valueMustBe}");
        }
    }
}
