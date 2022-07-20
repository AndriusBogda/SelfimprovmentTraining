using System;

namespace SeleniumTrainingCenter.PageObjects.Interfaces
{
    public interface IPage
    {
        bool DoesElementExist(string xPath);

        void TakeScreenshot(string path);

        void Load(string url);

        void RefreshPage();

        bool IsElementVisible(string locator);

        bool IsElementClickable(string locator);

        bool HasTextChanged(string originalText, string locator);

        string GetText(string locator);

        void SendKeys(string locator, string keys);

        bool WaitUntilMethodMatchesCondition(bool expected, Func<string, bool> method, string css);
        bool WaitUntilMethodMatchesCondition(bool expected, Func<string, string, bool> method, string css, string methodString);

        bool ValidateSelectDropdown(string[] expected, string locator);
        bool ValidateDropdown(string[] expected, string locator);
    }
}