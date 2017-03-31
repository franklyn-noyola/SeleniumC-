﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AUSA
{
    class ambulanceCompScreen : ausaFieldsConfiguration
    {
        private static String nameLast = "_txt_name_box_data";
        private static String typeT = "_cmb_occupant_type_cmb_dropdown";
        private static String phone = "_txt_phone_box_data";
        private static String home = "_txt_address_box_data";
        private static String DNI = "_txt_dni_box_data";
        private static String other = "_txt_others_box_data";

        public static void ibAmbulance()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(ambLabel)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            takeScreenShot("ambulancia.jpg");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_txt_Title_box_data")).SendKeys("Ambulance" + " - " + ranNumbr(1, 99) + " QA");
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_txt_legajo_box_data")).SendKeys(+ranNumbr(10000, 90000000) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_txt_vehid_box_data")).SendKeys(+ranNumbr(600000000, 699999999) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_txt_phone_box_data")).SendKeys(ranYearNumbr(910000000, 980000000) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_txt_driver_box_data")).SendKeys(personsT[ranYearNumbr(0, personsT.Length - 1)] + "");
            selectDropDownClick2("ctl00_ContentZone_ctrlAmbulance_cmb_movedTo_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlAmbulance_cmb_company_cmb_dropdown");
            ocupantesSection();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("El Componente Ambulancia ha sido creado para la Parte No. " + partText);

        }
        public static void ocupantesSection()
        {
            int ocuPant = ranYearNumbr(1, 4);
	  		for (int ocu = 1; ocu<= ocuPant; ocu++){
	  			driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_BtnAddOccupants")).Click();
                System.Threading.Thread.Sleep(500);
	  		}
                string ocuPants = driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ContentZone_ctrlAmbulance_Ambulance')]")).GetAttribute("id");
                int ocuPantNumber = Int32.Parse(ocuPants.Substring(41, 43));
                int totalOcupant = ocuPantNumber + ocuPant;	
	  		            if (ocuPant == 1){
	  			            int nameGender = ranYearNumbr(0, personsT.Length - 1);
                              selectDropDownClick("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocuPantNumber+typeT);
                            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocuPantNumber+phone)).SendKeys(ranYearNumbr(900000000,980000000)+"");
	  			            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocuPantNumber+DNI)).SendKeys(dniLetra(ranYearNumbr(10000000,40000000)));	  			
	  			            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocuPantNumber+nameLast)).SendKeys(personsT[nameGender]);
                            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocuPantNumber+home)).SendKeys("ESPAÑA");
                            driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocuPantNumber+other)).SendKeys("QA TESTER TECSIDEL");
                            System.Threading.Thread.Sleep(2500);

	  		}else{
	  		for (int ocup = ocuPantNumber; ocup<totalOcupant; ocup++){	  			
	  			int nameGender = ranYearNumbr(0, personsT.Length - 1);

                  selectDropDownClick("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocup+typeT);
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocup+phone)).SendKeys(ranYearNumbr(900000000,980000000)+"");
	  			    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocup+DNI)).SendKeys(dniLetra(ranYearNumbr(10000000,40000000)));	  			
	  			    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocup+nameLast)).SendKeys(personsT[nameGender]);
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocup+home)).SendKeys("ESPAÑA");
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAmbulance_Ambulance"+ocup+other)).SendKeys("QA TESTER TECSIDEL");
                    System.Threading.Thread.Sleep(2500);
	  			}
	  		}
            System.Threading.Thread.Sleep(1000);	  		
			driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(3000);	
        }
    }
}
