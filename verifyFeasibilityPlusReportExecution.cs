[Test]
public void VerifyFeasibilityPlusReportExecution()
{
    SignInPage signInPage = Navigation.NavigateToHomePage(Browser);

    HomePage homePage = signInPage.Login(Username, Password);

    PopulationsPage populationPage = homePage.ClickAndWaitBasePage(homePage.PopulationMenuLink);

    String datetime = DateTime.Now.ToString("yy-MM-dd HH:mm:ss").Replace("-", "").Replace(" ", "").Replace(":", "");

    String Title = "AutoTitle" + datetime;
    String Description = "AutoDesc" + datetime;
    String AttributeType = "Diagnoses";
    String Attribute = "ICD Code - Diagnoses";
    String FilterCoditionOne = "in";
    String[] FilterConditionSearchText = { "070.21","070.22" };
    String FilterSearchResultsSelection = "Individual";
    String IsContract = "Yes";

    populationPage.CreateNewPopulation(Title, Description, AttributeType, Attribute, FilterCoditionOne, FilterConditionSearchText, FilterSearchResultsSelection ,IsContract);

    // Validate first population status
    Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 5, "td", " Processing"));

    // Validate Population is created with title
    Assert.That(ElemGet.Grid_CellTextFound(Browser, populationPage.PopulationDetailsTbl, 0, "td", " " + Title));
    Browser.WaitJSAndJQuery();

    Browser.WaitForElement(Bys.PopulationsPageBy.ActionsHomeBtn, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);

    // Open the created popoulation

    populationPage.ClickAndWait(populationPage.populationDetailsTblFirtRowNameColumn);

    // Retrive the Details of Visits, Population, Sites

    String[] populationVisitCountText = Browser.FindElement(Bys.PopulationsPageBy.PopulationVisitCountlabel).Text.Split(':');
    String[] populationPatientCountText = Browser.FindElement(Bys.PopulationsPageBy.PopulationPatientCountlabel).Text.Split(':');
    String[] populationSiteCountText =   Browser.FindElement(Bys.PopulationsPageBy.PopulationHospitalCountlabel).Text.Split(':');

    String populationVisitCount = populationVisitCountText[1].Trim();
    String populationPatientCount = populationPatientCountText[1].Trim();
    String populationSiteCount = populationSiteCountText[1].Trim();

    // Navigate to Report Menu
    ReportsPage reportsPage = homePage.ClickAndWaitBasePage(homePage.ReportMenuLink);
    String population = Title;

    reportsPage.SelectSpecificReport(reportsPage.FeasibilityPlusSelectPopulationBtn, "No");
    reportsPage.SearchForAPopulation(population);
    reportsPage.SelectFirstPopulationInList();

    Browser.WaitForElement(Bys.ReportsPageBy.ReportFrame, TimeSpan.FromSeconds(60));

    // Switch The Frame
    Browser.SwitchTo().Frame(0);
    Browser.WaitForElement(Bys.ReportsPageBy.SummaryTabBtn, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.SummaryTabFeasibilityPlusHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
    Browser.WaitJSAndJQuery();

    Thread.Sleep(30);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

    String reportVisitCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel).Text;
    String reportPatientCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel).Text;
    String reportSiteCount = Browser.FindElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel).Text;

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasibilityPopulationLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    // Visit , Patients, Sites Count Check

    // Visit Count Check
    if (! reportVisitCount.Contains(populationVisitCount))
        throw new Exception("Visit count doesn't match with the population " + population + " as per in the summary tab");

    // Patients Count Check
    if (!reportPatientCount.Contains(populationPatientCount))
        throw new Exception("Patient count doesn't match with the population " + population + " as per in the summary tab");

    // Sites Count Check
    if (! reportSiteCount.Contains(populationSiteCount))
        throw new Exception("Sites count doesn't match with the population " + population + " as per in the summary tab");

    // Validate in URL
    String[] currentURL = Browser.Url.Split('@');
    if (!currentURL[1].Contains("selectedPopulation.id="))
        throw new Exception("URL doesn't contains the selected population id");

    reportsPage.ClickAndWait(reportsPage.BaseProfileTabBtn);
    Browser.WaitForElement(Bys.ReportsPageBy.BaseProfileTabHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(10));
    Browser.WaitJSAndJQuery();

    Thread.Sleep(30);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasibilityPopulationLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    reportVisitCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel).Text;
    reportPatientCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel).Text;
    reportSiteCount = Browser.FindElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel).Text;

    // Visit , Patients, Sites Count Check

    // Visit Count Check
    if (! reportVisitCount.Contains(populationVisitCount))
        throw new Exception("Visit count doesn't match with the population " + population + " as per in the Base Profile tab");

    // Patients Count Check
    if (! reportPatientCount.Contains(populationPatientCount))
        throw new Exception("Patient count doesn't match with the population " + population + " as per in the Base Profile tab");

    // Sites Count Check
    if (! reportSiteCount.Contains(populationSiteCount))
        throw new Exception("Sites count doesn't match with the population " + population + " as per in the Base Profile tab");

    reportsPage.ClickAndWait(reportsPage.PatientCharacteristicsTabBtn);
    Browser.WaitForElement(Bys.ReportsPageBy.PatientCharacteristicsTabHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(10));
    Browser.WaitJSAndJQuery();

    Thread.Sleep(30);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasibilityPopulationLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    reportVisitCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel).Text;
    reportPatientCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel).Text;
    reportSiteCount = Browser.FindElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel).Text;

    // Visit , Patients, Sites Count Check

    // Visit Count Check
    if (! reportVisitCount.Contains(populationVisitCount))
        throw new Exception("Visit count doesn't match with the population " + population + " as per in the Patient Characteristics tab");

    // Patients Count Check
    if (! reportPatientCount.Contains(populationPatientCount))
        throw new Exception("Patient count doesn't match with the population " + population + " as per in the Patient Characteristics tab");

    // Sites Count Check
    if (! reportSiteCount.Contains(populationSiteCount))
        throw new Exception("Sites count doesn't match with the population " + population + " as per in the Patient Characteristics tab");

    reportsPage.ClickAndWait(reportsPage.VisitCharacteristicsTabBtn);
    Browser.WaitForElement(Bys.ReportsPageBy.VisitCharacteristicsTabHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(10));
    Browser.WaitJSAndJQuery();

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasibilityPopulationLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    reportVisitCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel).Text;
    reportPatientCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel).Text;
    reportSiteCount = Browser.FindElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel).Text;

    // Visit , Patients, Sites Count Check

    // Visit Count Check
    if (! reportVisitCount.Contains(populationVisitCount))
        throw new Exception("Visit count doesn't match with the population " + population + " as per in the Visit Characteristics tab");

    // Patients Count Check
    if (! reportPatientCount.Contains(populationPatientCount))
        throw new Exception("Patient count doesn't match with the population " + population + " as per in the Visit Characteristics tab");

    // Sites Count Check
    if (! reportSiteCount.Contains(populationSiteCount))
        throw new Exception("Sites count doesn't match with the population " + population + " as per in the Visit Characteristics tab");

    reportsPage.ClickAndWait(reportsPage.SiteCharacteristicsTabBtn);
    Browser.WaitForElement(Bys.ReportsPageBy.SiteCharacteristicsTabHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(10));
    Browser.WaitJSAndJQuery();

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

    Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasibilityPopulationLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    reportVisitCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel).Text;
    reportPatientCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel).Text;
    reportSiteCount = Browser.FindElement(Bys.ReportsPageBy.FeasibilityPlusSitesLabel).Text;

    // Visit , Patients, Sites Count Check

    // Visit Count Check
    if (! reportVisitCount.Contains(populationVisitCount))
        throw new Exception("Visit count doesn't match with the population " + population + " as per in the Site Characteristics tab");

    // Patients Count Check
    if (! reportPatientCount.Contains(populationPatientCount))
        throw new Exception("Patient count doesn't match with the population " + population + " as per in the Site Characteristics tab");

    // Sites Count Check
    if (! reportSiteCount.Contains(populationSiteCount))
        throw new Exception("Sites count doesn't match with the population " + population + " as per in the Site Characteristics tab");

    reportsPage.ClickAndWait(reportsPage.AppendicesTabBtn);
    Browser.WaitForElement(Bys.ReportsPageBy.FeasiblityPlusAppendicesTitleLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(10));
    Browser.WaitJSAndJQuery();

    Browser.WaitForElement(Bys.ReportsPageBy.AppendixACriteriaLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

    String expectedCriteria = "Beginning of Population Criteria\r\nBeginning of Group [ Untitled ]\r\n[ICD Code - Diagnoses In 070.22 - HEPAT B CHRN VIRAL W/COMA W/O DELTA\r\n070.21 - HEPAT B ACUTE VIRAL W/COMA W/DELTA]\r\nEnd of Group [ Untitled ]\r\nEnd of Population Criteria";
    String displayedCriteria = Browser.FindElement(Bys.ReportsPageBy.AppendixACriteriaLabel).Text;
    if (!expectedCriteria.Equals(displayedCriteria))
        throw new Exception("Expected Criteria " + expectedCriteria + " doesn't match with displayed Criteria " + displayedCriteria + " for the Feasibility Plus Report related to population " + population);

    Browser.WaitForElement(Bys.ReportsPageBy.AppendixCSupportPageLink, TimeSpan.FromSeconds(100));
    Browser.WaitForElement(Bys.ReportsPageBy.AppendixCFeedbackLink, TimeSpan.FromSeconds(100));

   /* ((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].scrollIntoView(true);", reportsPage.AppendixCFeedbackLink);
    Thread.Sleep(TimeSpan.FromSeconds(5));
    reportsPage.ClickAndWait(reportsPage.AppendixCSupportPageLink);
    Thread.Sleep(TimeSpan.FromSeconds(5));

    // Get all windows
    ReadOnlyCollection<string> allWindows = Browser.WindowHandles;

    String parentWindow = allWindows.ElementAt(0); String childWindow = allWindows.ElementAt(1);

    Browser.SwitchTo().Window(childWindow);
    Browser.SwitchTo().DefaultContent();
    Browser.WaitForElement(Bys.ReportsPageBy.ProductSupportRequestLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

    // Validate and Close the Window
    Browser.Close();

    Browser.SwitchTo().Window(parentWindow);

    Browser.SwitchTo().DefaultContent();
    Browser.SwitchTo().Frame(0);
    reportsPage.ClickAndWait(reportsPage.AppendixCFeedbackLink);

    allWindows = Browser.WindowHandles;

    parentWindow = allWindows.ElementAt(0); childWindow = allWindows.ElementAt(1);

    Browser.SwitchTo().Window(childWindow);
    Browser.SwitchTo().DefaultContent();
    Browser.WaitForElement(Bys.ReportsPageBy.ProductCustomerFeedbackLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

    // Validate and Close the Window
    Browser.Close();

    Browser.SwitchTo().Window(parentWindow); */

    Browser.SwitchTo().DefaultContent();
    reportsPage.ClickAndWait(reportsPage.ExportReportbtn);
    Browser.WaitForElement(Bys.ReportsPageBy.ExportReportheaderlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Browser.WaitForElement(Bys.ReportsPageBy.ExportModalCloseBtn, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
    Thread.Sleep(TimeSpan.FromSeconds(10));
    reportsPage.ClickAndWait(reportsPage.ExportModalCloseBtn);

}
