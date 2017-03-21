using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;

namespace AUSA  
{
    
    [TestClass]
    public class ausaIssuesCreate : ausaFieldsConfiguration
    {
        public static string beginDate; public static string tempText1;public static string[] options1 = new string[vOption.Length];
        public static int camCount;public static string[] options = new string[dOption.Length];public static Boolean[] dOptionChecked = new Boolean[dOption.Length];
        public static IWebElement sevText; public static string sevText1;public static string parteNumber;
        public static IWebElement priorText; public static string priorText1;
        public static string typeText; public static IWebElement assignedText; public static string assignedText1;
        public static string locateText; public static IWebElement autopistaText; public static string autopistaText1;
        public static string autopistaText11; public static IWebElement bandaText; public static string bandaText1;
        public static Boolean supervT = false; public static string PkmText; public static string PkmText1;
        public static IWebElement ramalsText; public static string ramalsText1; public static string typeAcc;
        public static string observacionesText; public static IWebElement supervisorText; public static string supervisorText1;
        public static string typeImpact; public static string cAparente;public static Boolean[] cameraOpt;
        public static string infoComp;public static string obserGenerales;public static string notaCentro;
        public static IList<IWebElement> mcCamerasS;public static string[] cameraSelT;public static int i = 0;
        public static string vVolcadosT;public static Boolean[] vOptionTSel;public static IWebElement importanceC;
        public static string importanceC1;public static IWebElement newCom; public static string newComSel;
        public static IWebElement comMean; public static string comMeanSel;public static string comTitle;
        public static IWebElement motiveD; public static string motiveSel;public static IWebElement originC; public static string originSel;
        public static IWebElement originC_DestinaC; public static string originC_DestSel;
        public static string importanceSel;public static string matterCom;public static string commentCom;
        public static Boolean errorCreate = false; public static string verFile;public static string path;
        public static int volNumber;public static int[] vOptionNumber;

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
                driver.Navigate().GoToUrl(baseUrl);
                System.Threading.Thread.Sleep(500);
                if (driver.PageSource.Contains("No se puede acceder a este sitio web"))
                {
                    takeScreenShot("ausaNoDispERR.jpeg");
                    Assert.Fail("ITS NO ESTA DISPONIBLE");
                    return;
                }
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
            grabarDatosFichero();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(issueCreateBtn)).Click();
            System.Threading.Thread.Sleep(2000);
            List<string> multipleTabs = new List<string>(driver.WindowHandles);
            if (multipleTabs.Count > 2)
            {
                string errorText = driver.FindElement(By.XPath("//div[@class='toast-item toast-type-error']/p")).Text;
                errorCreate = true;
                crearFichero();
                Console.WriteLine("Ver Archivo de Datos " + verFile + " y reproducir error manualmente");
                Assert.Fail("ERROR EN CREAR PARTE: " + errorText);
                return;
            }
            else
            {
                errorCreate = false;
                /*driver.switchTo().window(multipleTabs.get(1));
                Partes1 = mPartes;
                Assert.assertEquals(mPartes, Partes1);*/
                IWebElement table = driver.FindElement(By.CssSelector("tbody tr td table#tableIssues.generalTable"));
                string buscar1 = table.FindElement(By.XPath("//table[@id='tableIssues']/tbody/tr[1]")).GetAttribute("id");
                parteNumber = buscar1.Substring(6);
                System.Threading.Thread.Sleep(1000);
                crearFichero();
                Console.WriteLine("Se ha creado parte No. " + parteNumber + " correctamente. Verificar archivo log " + verFile + "_NEW con los datos creados");
                System.Threading.Thread.Sleep(1500);
            }
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
            System.Threading.Thread.Sleep(400);
            driver.FindElement(By.Id(cameraSel)).Click();
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
        public static void grabarDatosFichero() {
            beginDate = driver.FindElement(By.Id("ctl00_ContentZone_dt_opentime_box_date")).GetAttribute("value");
            tempText1 = driver.FindElement(By.Id("ctl00_ContentZone_txt_template_box_data")).GetAttribute("value");
            sevText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_severity_cmb_dropdown"))).SelectedOption;
                sevText1 = sevText.Text;
			priorText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_priority_cmb_dropdown"))).SelectedOption;
                priorText1 = priorText.Text;
			typeText = driver.FindElement(By.Id("ctl00_ContentZone_txt_type_box_data")).GetAttribute("value");
            assignedText = new SelectElement(driver.FindElement(By.Id(asignadoT))).SelectedOption;
                assignedText1 = assignedText.Text;
			locateText = driver.FindElement(By.Id("ctl00_ContentZone_txt_location_box_data")).GetAttribute("value");
            autopistaText = new SelectElement(driver.FindElement(By.Id(tValoresT))).SelectedOption;
                autopistaText1 = autopistaText.Text;
			bandaText = new SelectElement(driver.FindElement(By.Id(direcT))).SelectedOption;
                bandaText1 = bandaText.Text;
			PkmText = driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).GetAttribute("value");
            PkmText1 = driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).GetAttribute("value");
            ramalsText = new SelectElement(driver.FindElement(By.Id(ramalsT))).SelectedOption;
                ramalsText1 = ramalsText.Text;
			observacionesText = driver.FindElement(By.Id("ctl00_ContentZone_txt_comments_box_data")).GetAttribute("value");
			if (driver.FindElements(By.Id(supervisorT)).Count!=0){
				supervisorText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_assigned_cmb_dropdown"))).SelectedOption;
                    supervisorText1 = supervisorText.Text;
				        supervT = true;
          }
        System.Threading.Thread.Sleep(1000);	  					
			if (typeText.Equals("Incidente") || typeText.Equals("Accidente")){
				    typeAcc = driver.FindElement(By.Id("ctl00_ContentZone_mc_typeOfAccident_txt_selected")).GetAttribute("value");
                    typeImpact = driver.FindElement(By.Id("ctl00_ContentZone_mc_causal_txt_selected")).GetAttribute("value");
                }
            cAparente = driver.FindElement(By.Id("ctl00_ContentZone_txt_causes_box_data")).GetAttribute("value");
						if (cAparente == null){
								cAparente = "";
						}
			infoComp = driver.FindElement(By.Id("ctl00_ContentZone_txt_information_box_data")).GetAttribute("value");
					if (infoComp == null){
								infoComp = "";
					}
			obserGenerales = driver.FindElement(By.Id("ctl00_ContentZone_txt_observations_box_data")).GetAttribute("value");
					if (obserGenerales == null){
							obserGenerales = "";
					}
			notaCentro = driver.FindElement(By.Id("ctl00_ContentZone_txt_note_box_data")).GetAttribute("value");
					if (notaCentro == null){
						notaCentro = "";
					}
					mcCamerasS = driver.FindElements(By.XPath("//*[contains(@id, 'ctl00_ContentZone_mcCameras_ctl')]"));
					cameraOpt  = new Boolean[mcCamerasS.Count];
					cameraSelT = new string[mcCamerasS.Count];
					string[] del2 = new string[mcCamerasS.Count];
                    driver.FindElement(By.Id(cameraSel)).Click();
		            	for (i = 0; i<= mcCamerasS.Count-1;i++){		            		
		            		del2[i] = mcCamerasS.ElementAt(i).GetAttribute("id");
                    cameraOpt[i] = driver.FindElement(By.XPath("//*[@id="+"'"+del2[i]+"'"+"]")).Selected;
		            		if (cameraOpt[i]){
		            			camCount = camCount + 1;
		            			cameraSelT[i]=driver.FindElement(By.XPath("//label[@for="+"'"+del2[i]+"'"+"]")).Text;
		            		}
		            	}
		            	System.Threading.Thread.Sleep(1000);
		            	driver.FindElement(By.Id(cameraSel)).Click();
			                for (i = 1; i<dOption.Length;i++){
					            options[i] = driver.FindElement(By.XPath("//label[@for="+"'"+dOption[i]+"'"+"]")).Text;
                                    dOptionChecked[i] = driver.FindElement(By.Id(dOption[i])).Selected;
					                    if (options[i].Equals("Vehículos volcados")){	  									  								
						                        vVolcadosT = "Vehiculos volcados";
					                    }
				                    }
			
			                if (typeText.Equals("Incidente") || typeText.Equals("Accidente")){
				                for (int i = 1; i<vOption.Length;i++){
					                options1[i] = driver.FindElement(By.XPath("//label[@for="+"'"+vOption[i]+"'"+"]")).Text;
                                    vOptionTSel[i] = driver.FindElement(By.Id(vOption[i])).Selected;					
					            }
				comTitle = driver.FindElement(By.Id(communicationField)).GetAttribute("value");
                newCom = new SelectElement(driver.FindElement(By.Id(newCommunication))).SelectedOption;
                    newComSel = newCom.Text;
				 if (newComSel.Equals(null)){
					 newComSel = "";
				 }
				 comMean = new SelectElement(driver.FindElement(By.Id(medioField))).SelectedOption;
                    comMeanSel = comMean.Text;
					 if (comMeanSel.Equals(null)){
						 comMeanSel = "";
					 }
					 motiveD = new SelectElement(driver.FindElement(By.Id(motiveField))).SelectedOption;
                        motiveSel = comMean.Text;
						     if (motiveSel.Equals(null)){
							        motiveSel = "";
						    } 
				    originC = new SelectElement(driver.FindElement(By.Id(originDestination))).SelectedOption;
                        originSel = originC.Text;
					 	if (originSel.Equals(null)){
					 		originSel = "";
					 	}
					 if (originSel!=null){	
					 	originC_DestinaC = new SelectElement(driver.FindElement(By.Id(originDest))).SelectedOption;
                            originC_DestSel = originC_DestinaC.Text;
					 		    if (originC_DestSel.Equals(null)){
					 			    originC_DestSel = "";
					 		    }
					 	}else{
					 		originC_DestSel = "";
					 	}
					 	importanceC = new SelectElement(driver.FindElement(By.Id(importanceField))).SelectedOption;
                            importanceSel = importanceC.Text;
					 			if (importanceSel.Equals(null)){
					 				importanceSel = "";
					 			}
					 	matterCom = driver.FindElement(By.Id(subjectField)).GetAttribute("value");
                        commentCom = driver.FindElement(By.Id(commentField)).GetAttribute("value");
					 	
					}
			
	}
		public static void crearFichero() {
			if (errorCreate){
                verFile = "crearPartesResultdosErrFile";
            } else{
                verFile = "crearPartesResultadosSuccess";
            }
            path = "C:\\Selenium\\";
            FileStream oldFile = new FileStream (path+verFile+"_OLD.txt", FileMode.Create);
			    if (File.Exists(path+verFile+"_OLD.txt")){
                        File.Delete(path + verFile + "_OLD.txt");
                }
			FileStream result = new FileStream("C:\\Selenium\\" + verFile + "_NEW.txt", FileMode.Create);
			if (File.Exists(path + verFile + "_NEW.txt")){
                File.Copy(path + verFile + "_NEW.txt", path + verFile + "_OLD.txt");
                }
						
			StreamWriter fis = new StreamWriter(result);
           

			if (parteNumber!=null){
				Console.WriteLine("#Parte: "+parteNumber);
			}									
			    Console.WriteLine("Fecha Inicio: "+beginDate);
                Console.WriteLine("Plantilla: "+tempText1);
                Console.WriteLine("Gravedad: "+sevText1);
                Console.WriteLine("Prioridad: "+priorText1);
                Console.WriteLine("Tipo: "+typeText);
                Console.WriteLine("Asignado: "+assignedText1);
			if (supervT){
                Console.WriteLine("Supervisor: "+supervisorText1);
			}
            Console.WriteLine("Autopista: "+autopistaText1);
            Console.WriteLine("Banda: "+bandaText1);
            Console.WriteLine("PKM(Km+m): "+PkmText+"+"+PkmText1);
            Console.WriteLine("Ramales: "+ramalsText1);
            Console.WriteLine("Localización: "+locateText);
            Console.WriteLine("Observaciones: "+observacionesText);
            System.Threading.Thread.Sleep(1000);	  					
			if (typeText.Equals("Incidente") || typeText.Equals("Accidente")){
                Console.WriteLine("Tipo de Accidentes: "+ typeAcc);
                Console.WriteLine("Tipo de Impacto: "+typeImpact);
			}
            Console.WriteLine("Causas Aparentes del Hecho: "+cAparente);
            Console.WriteLine("Información complementaria: "+infoComp);
            Console.WriteLine("Observaciones Generales: "+obserGenerales);
            Console.WriteLine("Nota del centro de operaciones: "+notaCentro);
    			if (camCount > 1){
                    Console.WriteLine("Camara/s Seleccionada/s: ");
    			}else{
                    Console.WriteLine("Camara Seleccionada: ");
    			}
			for (i = 0; i<= mcCamerasS.Count-1;i++){
				if (cameraOpt[i]){
						if (camCount > 1){
                            Console.Write(cameraSelT[i]+"; ");
						}else{
                            Console.Write(cameraSelT[i]);
						}
        			}
			}
            Console.WriteLine("");
            Console.WriteLine("");
			for (i = 1; i<dOption.Length;i++){
				if (dOptionChecked[i]){
					if (!options[i].Equals("Vehículos volcados")){
                        Console.Write("x"+options[i]+"    ");
					}
						if (options[i].Equals("Vehículos volcados")){
                            Console.Write("xVehículos volcados"+ ": "+ volNumber);
						}
						}else{
                            Console.Write(options[i]+"    ");
					}
				}
                Console.WriteLine("");
			if (typeText.Equals("Incidente") || typeText.Equals("Accidente")){
				for (int i = 1; i<vOption.Length;i++){
					if (vOptionTSel[i]){
                            Console.Write("x"+options1[i]+": "+vOptionNumber[i]+"    ");  			  							  			  							
							}else{
                            Console.Write(options1[i]+"    ");
						}  			  				
				}
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Titulo de Comunicación: "+comTitle);
                Console.WriteLine("Tipo de Comunicación: "+newComSel);
                Console.WriteLine("Medio de Comunicación: "+comMeanSel);
                Console.WriteLine("Motivo de Comunicación: "+motiveSel);
                Console.WriteLine("Tipo Origen Destion: "+originSel);
                Console.WriteLine("Origen/Destino: "+originC_DestSel);
                Console.WriteLine("Importancia: "+importanceSel);
                Console.WriteLine("Asunto: "+matterCom);
                Console.WriteLine("Observaciones: "+commentCom);
					}
                fis.Close();
                fis.Dispose();
				Console.Out.Flush();
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