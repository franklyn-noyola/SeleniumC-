using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace AUSA  
{
    
    [TestClass]
    public class ausaIssuesCreate : ausaFieldsConfiguration
    {

        [TestInitialize]
        public void seTup()
        {
            driver = new ChromeDriver("C:\\Selenium");            
            driver.Manage().Window.Maximize();
        }       
        [TestMethod]
        public void ausaCreatePartes()
        {
            try
            {
                Actions action = new Actions(driver);
                if (driver.PageSource.Contains("No se puede acceder a este sitio web"))
                {                    
                    Console.WriteLine("ITS NO ESTA DISPONIBLE");
                    return;
                }
                
                driver.Navigate().GoToUrl(baseUrl);
                driver.FindElement(By.Id("BoxLogin")).SendKeys("00001");
                driver.FindElement(By.Id("BoxPassword")).SendKeys("00001");
                driver.FindElement(By.Id("BtnLogin")).Click();
                System.Threading.Thread.Sleep(3000);
                string lPartes = driver.FindElement(By.XPath("//div[7] / div / ul / li[5] / a")).Text;                
                IWebElement Partes = driver.FindElement(By.LinkText(lPartes));
                action.ClickAndHold(Partes).Perform();
                System.Threading.Thread.Sleep(1000);
                mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                driver.FindElement(By.LinkText(mPartes)).Click();                
                System.Threading.Thread.Sleep(4000);
                string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
                var newTab = driver.SwitchTo().Window(newHandle);
                var tabExpected = mPartes;
                Assert.AreEqual(tabExpected, newTab.Title);    // termina logica para enfocarse en otrotab            
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_ContentZone_BtnCreate")).Click();
                System.Threading.Thread.Sleep(3000);
                selectDropDownClick("ctl00_ContentZone_cmb_template_cmb_dropdown");
                driver.FindElement(By.Id("ctl00_ContentZone_BtnConfirmTemplate")).Click();
                System.Threading.Thread.Sleep(4000);
                createPartes();
                System.Threading.Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void createPartes()
        {
            System.Threading.Thread.Sleep(1000);
            string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
            var newTab = driver.SwitchTo().Window(newHandle);
            var tabExpected = "#Parte";
            Assert.AreEqual(tabExpected, newTab.Title);
            selectDropDownClick("ctl00_ContentZone_cmb_priority_cmb_dropdown");
            System.Threading.Thread.Sleep(4000);
            tipoSel = driver.FindElement(By.Id("ctl00_ContentZone_txt_type_box_data")).GetAttribute("value");
            //Filling out all data
            selectDropDownClick("ctl00_ContentZone_cmb_severity_cmb_dropdown");//Gravedad
                selectDropDownClick("ctl00_ContentZone_cmb_assigned_cmb_dropdown");//Asignado
            if (driver.FindElements(By.Id(supervisorT)).Count!= 0)
            {
                selectDropDownClick(supervisorT);//Supervisor            	
            }           
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick(tValoresT);
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown(direcT);
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).SendKeys(ranNumbr(10, 900) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).SendKeys(ranNumbr(1, 900) + "");
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown(ramalsT);
            driver.FindElement(By.Id(locationT)).SendKeys("Buenos Aires");
            driver.FindElement(By.Id(observaT)).SendKeys("QA issue created by Automation Script");
            System.Threading.Thread.Sleep(2000);
            datosSection();
            System.Threading.Thread.Sleep(1000);
            ranclickOption(dOption, 1, dOption.Length);
            System.Threading.Thread.Sleep(3000);
            if (driver.FindElement(By.Id(dOption[4])).Selected)
            {
                driver.FindElement(By.Id(vVolcado)).SendKeys(ranNumbr(1, 99) + "");
            }
            System.Threading.Thread.Sleep(2000);
            if (tipoSel.Equals("Incidente") || tipoSel.Equals("Accidente"))
            {
                ranclickOption(vOption, 1, vOption.Length);
                for (int i = 1; i < vOption.Length; i++)
                {
                    if (driver.FindElement(By.Id(vOption[i])).Selected)
                    {
                        System.Threading.Thread.Sleep(1000);
                        driver.FindElement(By.Id(vOptionT[i])).SendKeys(ranNumbr(1, 99) + ""); ;
                    }
                }
            }
            System.Threading.Thread.Sleep(500);
            if (driver.FindElements(By.Id(communicationField)).Count!=0)
            {
                communicationSection();
            }
            
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id(issueCreateBtn)).Click();
            System.Threading.Thread.Sleep(2500);
        }

      
     
        public static void datosSection()
        {
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id(datoBtn)).Click();
            System.Threading.Thread.Sleep(1000);
            if (tipoSel.Equals("Incidente") || tipoSel.Equals("Accidente"))
            {
                driver.FindElement(By.Id(typeAccidentes)).Click();
                System.Threading.Thread.Sleep(500);
                ranClick("ctl00_ContentZone_mc_typeOfAccident_ctl", 19, 23);
                System.Threading.Thread.Sleep(400);
                driver.FindElement(By.Id(typeImpacto)).Click();
                System.Threading.Thread.Sleep(500);
                ranClick("ctl00_ContentZone_mc_causal_ctl", 19, 23);
                System.Threading.Thread.Sleep(500);
            }
            driver.FindElement(By.Id("ctl00_ContentZone_txt_causes_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_information_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_observations_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_note_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id(cameraSel)).Click();
            System.Threading.Thread.Sleep(500);
            ranClick("ctl00_ContentZone_mcCameras_ctl", 105, 119);

        }
        public void communicationSection()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(communicationField)).Clear();
            driver.FindElement(By.Id(communicationField)).SendKeys("Communication"+" - "+ranNumbr(1,99)+" QA Automation" );
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(newCommunication);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(medioField);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(motiveField);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(originDestination);
            System.Threading.Thread.Sleep(2000);
            notEmptyDropDown(originDest);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(importanceField);
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id(subjectField)).SendKeys("Created by Automation Script");
            driver.FindElement(By.Id(commentField)).SendKeys("This Communication was created by an automation script for testing purpose");
            System.Threading.Thread.Sleep(1000);
        }
        
        private Boolean isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }catch (NoSuchElementException e)
            {
                return false;
            }

        }
      
       

[TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

    }
}