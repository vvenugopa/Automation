        [Test]
        public void VerifyMultiPopulationReportExecution()
        {
            SignInPage signInPage = Navigation.NavigateToHomePage(Browser);

            HomePage homePage = signInPage.Login(Username, Password);

            String Title = "Multi pop Auto_Check _one";
            String Title2 = "Multi pop Report-Auto_ Check two";

            // Navigate to Report Menu
            ReportsPage reportsPage = homePage.ClickAndWaitBasePage(homePage.ReportMenuLink);

            reportsPage.SelectSpecificReport(reportsPage.MultiplePopulationsSelectPopulationBtn, "Yes");

            Thread.Sleep(TimeSpan.FromSeconds(50));


            /* Search and Select the Specific Population*/
            //reportsPage.SearchForAPopulation(Title);
            //Browser.WaitJSAndJQuery();
            //reportsPage.CheckFirstPopulationInList();
            // Browser.WaitJSAndJQuery();
            // reportsPage.SearchForAPopulation(Title2);
            // Browser.WaitJSAndJQuery();
            // reportsPage.CheckFirstPopulationInList();
            //Browser.WaitJSAndJQuery();

            /* Select the Population */
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Browser.WaitForElement(Bys.ReportsPageBy.TableSixthRowCheckBox, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            reportsPage.ClickAndWait(reportsPage.TableSixthRowCheckBox);
            
            Thread.Sleep(TimeSpan.FromSeconds(3));

            Browser.WaitForElement(Bys.ReportsPageBy.TableFifthRowCheckBox, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            reportsPage.ClickAndWait(reportsPage.TableFifthRowCheckBox);

            reportsPage.RunReport();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Browser.WaitForElement(Bys.ReportsPageBy.ReportFrame, TimeSpan.FromSeconds(300));

            // Switch The Frame
            Browser.SwitchTo().Frame(0);
            Browser.WaitForElement(Bys.ReportsPageBy.OverviewTabBtn, TimeSpan.FromSeconds(300), ElementCriteria.IsVisible);

            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.OverviewTabHeaderlabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");


            // Validate in URL
            String[] currentURL = Browser.Url.Split('@');
            if (!currentURL[1].Contains("population.id="))
                throw new Exception("URL doesn't contains the selected population id");

            reportsPage.ClickAndWait(reportsPage.PatientDemographicsTabBtn);
            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.PatientDemoraphicsTabHeaderlabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");


            reportsPage.ClickAndWait(reportsPage.VisitCharacteristicsTabBtn);
            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.VisitCharacteristicsTabHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            reportsPage.ClickAndWait(reportsPage.SiteCharacteristicsTabBtn);
            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.SiteCharacteristicsTabHeaderLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");


            reportsPage.ClickAndWait(reportsPage.ComorbiditiesTabBtn);
            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.ComorbiditiesTabHeaderlabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            reportsPage.ClickAndWait(reportsPage.OutcomeTabBtn);
            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.OutcomesTabHeaderlabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            reportsPage.ClickAndWait(reportsPage.PanelTabBtn);
            Browser.WaitJSAndJQuery();
            Browser.WaitForElement(Bys.ReportsPageBy.PanelTabHeaderlabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Validatoins on visits, sites and patients
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);

            Browser.WaitForElement(Bys.ReportsPageBy.NumberOfPopulationlabel, TimeSpan.FromSeconds(180), ElementCriteria.IsVisible);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Visit , Patients, Sites Count Check

            // Visit Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowVisits).Text.Contains("1,213"))
                throw new Exception("Visit count doesn't match with the population " + Title + " as per in the Overview tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowVisits).Text.Contains("1,319"))
                throw new Exception("Visit count doesn't match with the population " + Title2 + " as per in the Overview tab");

            // Patients Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowPatient).Text.Contains("1,138"))
                throw new Exception("Patient count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowPatient).Text.Contains("1,224"))
                throw new Exception("Patient count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            // Sites Count Check
            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableFirstRowSites).Text.Contains("194"))
                throw new Exception("Sites count doesn't match with the population " + Title + " as per in the Summary Table tab");

            if (!Browser.FindElement(Bys.ReportsPageBy.MultiPopulationTableSecondRowSites).Text.Contains("221"))
                throw new Exception("Sites count doesn't match with the population " + Title2 + " as per in the Summary Table tab");

            reportsPage.ClickAndWait(reportsPage.AppendicesTabBtn);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPopulationAppendicesTitleLabel, TimeSpan.FromSeconds(60), ElementCriteria.IsVisible);
            Browser.WaitJSAndJQuery();

            Browser.WaitForElement(Bys.ReportsPageBy.MultiPoppulationAppendixACriteriaFirstLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);
            Browser.WaitForElement(Bys.ReportsPageBy.MultiPoppulationAppendixACriteriaSecondLabel, TimeSpan.FromSeconds(100), ElementCriteria.IsVisible);

            String expectedCriteriaPopulationOne = "Beginning of Population Criteria\r\nBeginning of Group [ Untitled ]\r\n[ICD Code - Diagnoses In 001 - CHOLERA*\r\n001.0 - CHOLERA D/T VIBRIO CHOLERAE]\r\nEnd of Group [ Untitled ]\r\nEnd of Population Criteria";
            String displayedCriteriaOne = Browser.FindElement(Bys.ReportsPageBy.MultiPoppulationAppendixACriteriaFirstLabel).Text;
            if (!expectedCriteriaPopulationOne.Equals(displayedCriteriaOne))
                throw new Exception("First Expected Criteria " + expectedCriteriaPopulationOne + " doesn't match with displayed Criteria " + displayedCriteriaOne + " for the Multi Population Report related to First population " + Title);

            String expectedCriteriaPopulationTwo = "Beginning of Population Criteria\r\nBeginning of Group [ Untitled ]\r\n[ICD Code - Diagnoses In 001 - CHOLERA*\r\n001.0 - CHOLERA D/T VIBRIO CHOLERAE\r\n001.1 - CHOLERA D/T VIBRIO CHOLERAE EL TOR]\r\nEnd of Group [ Untitled ]\r\nEnd of Population Criteria";
            String displayedCriteriaTwo = Browser.FindElement(Bys.ReportsPageBy.MultiPoppulationAppendixACriteriaSecondLabel).Text;
            if (!expectedCriteriaPopulationTwo.Equals(displayedCriteriaTwo))
                throw new Exception("Second Expected Criteria " + expectedCriteriaPopulationTwo + " doesn't match with displayed Criteria " + displayedCriteriaTwo + " for the Multi Population Report related to Second  population " + Title2);

            Browser.WaitForElement(Bys.ReportsPageBy.AppendixCSupportPageLink, TimeSpan.FromSeconds(100));
            Browser.WaitForElement(Bys.ReportsPageBy.AppendixCFeedbackLink, TimeSpan.FromSeconds(100));

            ((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].scrollIntoView(true);", reportsPage.AppendixCFeedbackLink);
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
            Thread.Sleep(TimeSpan.FromSeconds(5));
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

        }

    }
}


