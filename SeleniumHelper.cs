using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

public static class SeleniumHelper
{
    public static void Click(IWebElement element)
    {
        element.Click();
    }

    public static void Submit(IWebElement element)
    {
        element.Submit();
    }

    public static void EnterText(IWebElement element, string text)
    {
        element.Clear();
        element.SendKeys(text);
    }

    public static void SelectDropDownByText(IWebElement element, string text)
    {
        new SelectElement(element).SelectByText(text);
    }

    public static void SelectDropDownByValue(IWebElement element, string value)
    {
        new SelectElement(element).SelectByValue(value);
    }

    public static void MultiSelectElements(IWebElement element, string[] values)
    {
        SelectElement multiSelect = new SelectElement(element);
        foreach (var value in values)
        {
            multiSelect.SelectByValue(value);
        }
    }

    public static List<string> GetAllSelectedLists(IWebElement element)
    {
        List<string> options = new List<string>();
        foreach (var option in new SelectElement(element).AllSelectedOptions)
        {
            options.Add(option.Text);
        }
        return options;
    }

    public static List<string> GetAllCheckedCheckboxes(IWebDriver driver, By locator)
    {
        List<string> selectedValues = new List<string>();
        var checkboxes = driver.FindElements(locator);
        foreach (var checkbox in checkboxes)
        {
            if (checkbox.Selected)
            {
                selectedValues.Add(checkbox.GetAttribute("value"));
            }
        }
        return selectedValues;
    }
}