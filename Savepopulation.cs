Save population
using Browser.Core.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Revelations.AppFramework;
using Google.Protobuf.Compiler;
using Microsoft.CodeAnalysis;
using System.Threading;
using OfficeOpenXml.FormulaParsing.Utilities;
using Aspose.Cells.Charts;
using Criteria = Revelations.AppFramework.Criteria;
using Revelations.AppFramework.Pages.ReportsPage;


namespace Revelations.UITest
{
    [LocalSeleniumTestFixture(BrowserNames.Chrome)]
    [LocalSeleniumTestFixture(BrowserNames.Edge)]
    [RemoteSeleniumTestFixture(BrowserNames.Chrome, "", "", "Windows")]
    [RemoteSeleniumTestFixture(BrowserNames.Edge, "", "", "Windows")]

    [TestFixture]
    public class LoginPageTest : TestBase
    {
        #region Constructors
        public LoginPageTest(string BrowserName, string emulationDevice) : base(BrowserName, emulationDevice) { }
        public LoginPageTest(string BrowserName, string emulationDevice, string version, string platform, string hubUri, string extrasUri)
                                    : base(BrowserName, emulationDevice, version, platform, hubUri, extrasUri)
        { }

        #endregion Constructors
        [Test]
        public void VerifyNewPopulationCreation()
 {
     SignInPage signInPage = Navigation.NavigateToHomePage(Browser);
     //browser exists, user name exists 
     HomePage homePage = signInPage.Login(Username, Password);

     PopulationsPage populationPage = homePage.ClickAndWaitBasePage(homePage.PopulationMenuLink);

     String datetime = DateTime.Now.ToString("yy-MM-dd HH:mm:ss").Replace("-", "").Replace(" ", "").Replace(":", "");

     String Title = "AutoTitle" + datetime;
     String Description = "AutoDesc" + datetime;
     String AttributeType = "Diagnoses";
     String Attribute = "ICD Code - Diagnoses";
     String FilterCoditionOne = "in";
     String[] FilterConditionSearchText = { "070.2" };
     String FilterSearchResultsSelection = "Select All";
     String IsContract = "Yes";

     populationPage.CreateNewPopulation(Title, Description, AttributeType, Attribute, FilterCoditionOne, FilterConditionSearchText, FilterSearchResultsSelection, IsContract);

     // Validate first population status
     Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 5, "td", " Processing"));

     // Validate Population is created with title
     Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 0, "td", " " + Title));
     Browser.WaitJSAndJQuery();

     Browser.WaitForElement(Bys.PopulationsPageBy.ActionsHomeBtn, TimeSpan.FromSeconds(120), ElementCriteria.IsVisible);

     //Browser.WaitForElement(Bys.PopulationsPageBy.ActionsHomeBtn, ElementCriteria.IsVisible);

     // Copy existing population
     String CopiedNewPopulationTitle = populationPage.CopyFirstPopulationInGridList(Title);

     if (!CopiedNewPopulationTitle.Contains(Title + " COPYid_"))
         throw new Exception("New Population Title is :" + CopiedNewPopulationTitle + " doesn't contain expected title " + Title + " COPYid_");

     // Validate first population status
     Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 5, "td", " Processing"));

     // Validate Population is created with title
     Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 0, "td", " " + CopiedNewPopulationTitle));
     Browser.WaitJSAndJQuery();
     Browser.WaitForElement(Bys.PopulationsPageBy.ActionsHomeBtn, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

     // Delete existing population
     populationPage.DeleteFirstPopulationInGridList();

     Thread.Sleep(TimeSpan.FromSeconds(30));

     // Edit
     populationPage.DeSelectDropdownOptions(2);

     // Validate first population status
     Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 5, "td", " Processing"));

     // Validate Population is created with title
     Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 0, "td", " " + Title));
     Browser.WaitJSAndJQuery();
     Browser.WaitForElement(Bys.PopulationsPageBy.ActionsHomeBtn, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);

 }
        
        }
    }
}

