  public void VerifyFeasibilityFreeReportExecution()

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
      String[] FilterConditionSearchText = { "001", "001.0" };
      String FilterSearchResultsSelection = "Individual";
      String IsContract = "Yes";

      populationPage.CreateNewPopulation(Title, Description, AttributeType, Attribute, FilterCoditionOne, FilterConditionSearchText , FilterSearchResultsSelection, IsContract);

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
      String[] populationSiteCountText = Browser.FindElement(Bys.PopulationsPageBy.PopulationHospitalCountlabel).Text.Split(':');

      String populationVisitCount = populationVisitCountText[1].Trim();
      String populationPatientCount = populationPatientCountText[1].Trim();
      String populationSiteCount = populationSiteCountText[1].Trim();

      // Navigate to Report Menu
      ReportsPage reportsPage = homePage.ClickAndWaitBasePage(homePage.ReportMenuLink);
      
      reportsPage.SelectSpecificReport(reportsPage.FeasibilityFreeSelectPopulationBtn, "No");

      String population = Title;

      reportsPage.SearchForAPopulation(population);
      Thread.Sleep(5000);
      reportsPage.SelectFirstPopulationInList();
      Thread.Sleep(5000);
      Browser.WaitForElement(Bys.ReportsPageBy.ReportFrame, TimeSpan.FromSeconds(60));
      // Switch The Frame
      Browser.SwitchTo().Frame(0);
      Browser.WaitForElement(Bys.ReportsPageBy.ReportTabBtn, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
      Browser.WaitForElement(Bys.ReportsPageBy.ReporttabPopulationLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
      
      Thread.Sleep(TimeSpan.FromSeconds(5));

      Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityVisitsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
      Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblityPatientsLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
      Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasiblitySitesLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

      Browser.WaitForElement(Bys.ReportsPageBy.FreeFeasibilityPopulationLabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
      Thread.Sleep(TimeSpan.FromSeconds(5));


      String reportVisitCount = Browser.FindElement(Bys.ReportsPageBy.NavigationalVisitsLabel).Text;
      String reportPatientCount = Browser.FindElement(Bys.ReportsPageBy.FeasiblityPlusPatientsLabel).Text;
      String reportSiteCount = Browser.FindElement(Bys.ReportsPageBy.FreeFeasiblitySitesLabel).Text;

      // Visit Count Check
      if (! reportVisitCount.Contains(populationVisitCount))
          throw new Exception("Visit count doesn't match with the population " + population + " as per in the report tab");

      // Patients Count Check
      if(! reportPatientCount.Contains(populationPatientCount))
          throw new Exception("Patient count doesn't match with the population " + population + " as per in the report tab");

      // Sites Count Check
      if(! reportSiteCount.Contains(populationSiteCount) )
          throw new Exception("Sites count doesn't match with the population " + population + " as per in the report tab");

      // Validate in URL
      String[] currentURL = Browser.Url.Split('@');
      if (!currentURL[1].Contains("selectedPopulation.id="))
          throw new Exception("URL doesn't contains the selected population id");

      reportsPage.ClickAndWait(reportsPage.AppendicesTabBtn);
      Browser.WaitForElement(Bys.ReportsPageBy.AppendicesTitleLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
      Browser.WaitJSAndJQuery();

      Browser.WaitForElement(Bys.ReportsPageBy.AppendixACriteriaLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

      String expectedCriteria = "Beginning of Population Criteria\r\nBeginning of Group [ Untitled ]\r\n[ICD Code - Diagnoses In 001.0 - CHOLERA D/T VIBRIO CHOLERAE\r\n001 - CHOLERA*]\r\nEnd of Group [ Untitled ]\r\nEnd of Population Criteria";
      String displayedCriteria = Browser.FindElement(Bys.ReportsPageBy.AppendixACriteriaLabel).Text;
      if (! expectedCriteria.Equals(displayedCriteria))
          throw new Exception("Expected Criteria "+expectedCriteria+" doesn't match with displayed Criteria "+displayedCriteria+" for the Feasibility Free Report related to population "+population);

      Browser.WaitForElement(Bys.ReportsPageBy.AppendixCSupportPageLink, TimeSpan.FromSeconds(100));
      Browser.WaitForElement(Bys.ReportsPageBy.AppendixCFeedbackLink, TimeSpan.FromSeconds(100));

      //((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].scrollIntoView(true);", reportsPage.AppendixCFeedbackLink);
      //Thread.Sleep(TimeSpan.FromSeconds(5));
      //reportsPage.ClickAndWait(reportsPage.AppendixCSupportPageLink);
      //Thread.Sleep(TimeSpan.FromSeconds(5));

      // Get all windows
     // ReadOnlyCollection<string> allWindows = Browser.WindowHandles;

      //String parentWindow = allWindows.ElementAt(0); String childWindow = allWindows.ElementAt(1);

      //Browser.SwitchTo().Window(childWindow);
      //Browser.SwitchTo().DefaultContent();
      //Browser.WaitForElement(Bys.ReportsPageBy.ProductSupportRequestLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

      // Validate and Close the Window
     /* Browser.Close();

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

      Browser.SwitchTo().Window(parentWindow);

      Browser.SwitchTo().DefaultContent();
      Browser.SwitchTo().Frame(0);

      reportsPage.ClickAndWait(reportsPage.FeasibilityPlusPreviewTabBtn);
      Browser.WaitJSAndJQuery();*/

      // Image content cannot be verified.

      Browser.SwitchTo().DefaultContent();
      reportsPage.ClickAndWait(reportsPage.ExportReportbtn);
      Browser.WaitForElement(Bys.ReportsPageBy.ExportReportheaderlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
      Browser.WaitForElement(Bys.ReportsPageBy.ExportModalCloseBtn, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
      Thread.Sleep(TimeSpan.FromSeconds(60));
      reportsPage.ClickAndWait(reportsPage.ExportModalCloseBtn);
  }
