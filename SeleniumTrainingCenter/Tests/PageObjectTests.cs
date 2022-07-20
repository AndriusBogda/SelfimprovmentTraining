using SeleniumTrainingCenter.InfoObjects;
using SeleniumTrainingCenter.InfoObjects.Enums;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTrainingCenter.Tests.Bases;
using SeleniumTrainingCenter.Providers;
using System.Threading;

namespace SeleniumTrainingCenter.Tests
{
    [TestFixture(Description = "Additional project update tests")]
    [AllureNUnit]
    [AllureLink("https://github.com/AndriusBogda/SelfimprovmentTraining")]
    [TestClass]
    public class PageObjectTests : BaseTest
    {
        private readonly string _githubURL = @"https://github.com/";

        private readonly string _continueButton = "input.btn.btn-primary";
        // --
        private readonly string _tutorialspointURL = @"https://www.tutorialspoint.com/html/html_frames.htm";

        private readonly string _firstFrame = "iframe.result:first-of-type";
        private readonly string _nextPageButton = "div.nxt-btn a";
        // --
        private readonly string _inputPageURL = @"https://www.youtube.com/";

        private readonly string _inputField = "input#search";
        // --
        private readonly string _dropdownUlURL = @"https://getbootstrap.com/";
        private readonly string _dropdownListURL = @"https://demo.guru99.com/test/newtours/register.php";

        private readonly string _dropdownUl = ".dropdown-menu.dropdown-menu-end";
        private readonly string _selectDropdown = "select[name=country]";

        [Test]
        public void TestAssertLocation()
        {
            var githubPage = PageProvider.BasePage;
            githubPage.Load(_githubURL);

            AssertLocation(_githubURL);
        }

        [Test]
        public void TestElementStatus()
        {
            var framePage = PageProvider.BasePage;
            framePage.Load(_tutorialspointURL);

            var nextButtonOrgText = framePage.GetText(_nextPageButton);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(framePage.IsElementVisible(_nextPageButton), $"Element {_nextPageButton} is not visible");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(framePage.IsElementClickable(_nextPageButton), $"Element {_nextPageButton} is not Clickable");
            // Should test on a different element aswell
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(framePage.HasTextChanged(nextButtonOrgText, _nextPageButton), $"Element {_nextPageButton}'s text has not changed");
        }

        [Test]
        public void TestWaitUntil()
        {
            var inputPage = PageProvider.BasePage;
            inputPage.Load(_inputPageURL);

            var originalInput = inputPage.GetText(_inputField);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(inputPage.WaitUntilMethodMatchesCondition(false, inputPage.HasTextChanged, _inputField, originalInput), "Params method did not meet expected condition");

            inputPage.SendKeys(_inputField, "changed");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(inputPage.WaitUntilMethodMatchesCondition(true, inputPage.HasTextChanged, _inputField, originalInput), "Params method did not meet expected condition");

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(inputPage.WaitUntilMethodMatchesCondition(true, inputPage.HasTextChanged, "incorrect css", originalInput), "Params method did not meet expected condition");
        }

        [Test]
        public void TestSelectDropdown()
        {
            string[] expectedDropdownElements = 
            { 
                "ANGOLA",
                "ARuba"
            };

            var dropdownPage = PageProvider.BasePage;
            dropdownPage.Load(_dropdownListURL);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dropdownPage.ValidateSelectDropdown(expectedDropdownElements, _selectDropdown), $"Expected element is not present in {_selectDropdown} select element");
        }

        [Test]
        public void TestUlDropdown()
        {
            string[] expectedDropdownElements =
            {
                "v5",
                "v4"
            };

            var dropdownPage = PageProvider.BasePage;
            dropdownPage.Load(_dropdownUlURL);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(dropdownPage.ValidateDropdown(expectedDropdownElements, _dropdownUl), $"Expected element is not present in {_dropdownUl} select element");
        }
    }
}
