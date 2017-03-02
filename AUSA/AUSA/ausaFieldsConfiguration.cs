﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUSA
{
    public class ausaFieldsConfiguration
    {
        public static IWebDriver driver;
        public static string baseUrl = "http://172.18.133.105/12263/web/forms/core/login.aspx?mode=login";
        public static string mPartes;
        public Boolean acceptNextAlert = true;
        public static int numbering;
        public static string tipoSel;
        public static string linkPartes;
        public static string Types;
        public static string issueCreateBtn = "ctl00_ButtonsZone_BtnSave_IB_Label";
        public static string communicationField = "ctl00_ContentZone_ctrl_newComunication_txt_Title_box_data";
        public static string medioField = "ctl00_ContentZone_ctrl_newComunication_cmb_mean_cmb_dropdown";
        public static string motiveField = "ctl00_ContentZone_ctrl_newComunication_cmb_motive_cmb_dropdown";
        public static string originDestination = "ctl00_ContentZone_ctrl_newComunication_cmb_type_ori_des_cmb_dropdown";
        public static string originDest = "ctl00_ContentZone_ctrl_newComunication_cmb_ori_des_cmb_dropdown";
        public static string importanceField = "ctl00_ContentZone_ctrl_newComunication_cmb_importance_cmb_dropdown";
        public static string subjectField = "ctl00_ContentZone_ctrl_newComunication_txt_subject_box_data";
        public static string commentField = "ctl00_ContentZone_ctrl_newComunication_txt_comment_box_data";
        public static string cameraSel = "ctl00_ContentZone_mcCameras_txt_selected";
        public static string typeAccidentes = "ctl00_ContentZone_mc_typeOfAccident_img_expand";
        public static string newCommunication = "ctl00_ContentZone_ctrl_newComunication_cmb_type_cmb_dropdown";
        public static string typeImpacto = "ctl00_ContentZone_mc_causal_img_expand";
        public static string templateBtn = "ctl00_ContentZone_BtnConfirmTemplate";
        public static string templateSel = "ctl00_ContentZone_cmb_template_cmb_dropdown";
        public static string createBtn = "ctl00_ContentZone_BtnCreate";
        public static string prioritySel = "ctl00_ContentZone_cmb_priority_cmb_dropdown";
        public static string cPartesBtn = "ctl00_ButtonsZone_BtnSave_IB_Label";
        public static string[] dOption = new string[] { "", "ctl00_ContentZone_check_has_torched", "ctl00_ContentZone_check_has_disp_hard_shouleder", "ctl00_ContentZone_check_has_damages_ins", "ctl00_ContentZone_check_has_overturned" };
        public static string[] TipoS = new string[] { "ctl00_ContentZone_mc_type_ctl43", "ctl00_ContentZone_mc_type_ctl45", "ctl00_ContentZone_mc_type_ctl47", "ctl00_ContentZone_mc_type_ctl49", "ctl00_ContentZone_mc_type_ctl51" };
        public static string[] gravedadS = new string[] { "ctl00_ContentZone_mc_severity_ctl31", "ctl00_ContentZone_mc_severity_ctl33", };
        public static string datoBtn = "ctl00_ContentZone_showCausesInfoObservations";
        public static string[] vOption = new string[] { "", "ctl00_ContentZone_check_has_motorcycle", "ctl00_ContentZone_check_has_car", "ctl00_ContentZone_check_has_truck", "ctl00_ContentZone_check_has_bus", "ctl00_ContentZone_check_has_charter" };
        public static string vVolcado = "ctl00_ContentZone_txt_number_overturned_box_data";
        public static string[] vOptionT = new string[] { "", "ctl00_ContentZone_txt_number_motorcycle_box_data", "ctl00_ContentZone_txt_number_car_box_data", "ctl00_ContentZone_txt_number_truck_box_data", "ctl00_ContentZone_txt_number_bus_box_data", "ctl00_ContentZone_txt_number_charter_box_data" };
        public static string gravedadT = "ctl00_ContentZone_cmb_severity_cmb_dropdown";
        public static string asignadoT = "ctl00_ContentZone_cmb_assigned_cmb_dropdown";
        public static string supervisorT = "ctl00_ContentZone_cmb_supervisor_cmb_dropdown";
        public static string tValoresT = "ctl00_ContentZone_cmb_highway_branch_cmb_dropdown";
        public static string direcT = "ctl00_ContentZone_cmb_list_direction_cmb_dropdown";
        public static string locationT = "ctl00_ContentZone_txt_location_box_data";
        public static string observaT = "ctl00_ContentZone_txt_comments_box_data";
        public static string ramalsT = "ctl00_ContentZone_cmb_branch_cmb_dropdown";
        //Start Edit buttons icons configuration:
        public static string BtnAddCommunication = "ctl00_ContentZone_BtnAddComunication_IB_Label";
        public static string BtnAddVehicle = "ctl00_ContentZone_BtnAddVehicle_IB_Label";
        public static string BtnAddPerson = "ctl00_ContentZone_BtnAddPerson_IB_Label";
        public static string BtnAddAmbulance = "ctl00_ContentZone_BtnAddAmbulance_IB_Label";
        public static string BtnAddPatrol = "ctl00_ContentZone_BtnAddPatrol_div_label";
        public static string BtnAddSecurity = "ctl00_ContentZone_BtnAddSecurity_div_label";
        public static string BtnAddCrane = "ctl00_ContentZone_BtnAddCrane_div_label";
        public static string BtnAddWeather = "ctl00_ContentZone_BtnAddWeather_div_label";
        public static string BtnAddTraffic = "ctl00_ContentZone_BtnAddTraffic_div_label";
        public static string BtnAddRoadway = "ctl00_ContentZone_BtnAddRoadway_div_label";
        public static string BtnAddOther = "ctl00_ContentZone_BtnAddOther_div_label";
        public static string BtnAddJobOrder = "ctl00_ContentZone_BtnAddJobOrder_IB_Label";
        public static string BtnAddInformation = "ctl00_ContentZone_BtnAddInsideInformation_IB_Label";
        public static string BtnAddInconvenient = "ctl00_ContentZone_BtnAddInconvenientSchedule_IB_Label";

        public void clickAll(string id, int camp1, int camp2)
        {

            for (int i = camp1; i <= camp2; i = i + 2)
            {
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id(id + i)).Click();
            }


        }

        public static void selectDropDownClick(string by)
        {

            var vDropdown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> dd = vDropdown.Options;
            Random rand = new Random();
            int vdd = rand.Next(dd.Count);
            if (vdd < 0) { vdd = vdd + 1; }
            if (vdd >= dd.Count) { vdd = vdd - 1; }
            new SelectElement(driver.FindElement(By.Id(by))).SelectByIndex(vdd);

        }

        public static void ranclickOption(string[] id, int min, int max)
        {

            Random rand = new Random();
            int selOp = rand.Next(max - min) + 1;
            if (selOp >= id.Length)
            {
                selOp = selOp - 1;
            }
            for (int i = 1; i <= selOp; i++)
            {

                if (selOp == id.Length - 1)
                {
                    if (!driver.FindElement(By.Id(id[i])).Selected)
                    {
                        driver.FindElement(By.Id(id[i])).Click();
                        System.Threading.Thread.Sleep(300);
                    }
                }
                else
                {
                    int selc = rand.Next(max - min) + 1;
                    if (selc == id.Length)
                    {
                        selc = selc - 1;
                    }
                    if (!driver.FindElement(By.Id(id[i])).Selected)
                    {
                        driver.FindElement(By.Id(id[selc])).Click();
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

        }

        public void elementClick(string byID)
        {
            driver.FindElement(By.Id(byID)).Click();

        }
               
        public void notEmptyDropDown(string by)
        {
            SelectElement fDropDown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> fDsel = fDropDown.Options;
            if (fDsel.Count > 1)
            {
                selectDropDownClick(by);
            }
            System.Threading.Thread.Sleep(1000);
        }

        public static int ranNumbr(int min, int max)
        {
            Random rand = new Random();
            numbering = min + rand.Next((max - min) + 1);
            return numbering;

        }
        public static void takeScreenShot(string fname)   {
            ITakesScreenshot scrFile = driver as ITakesScreenshot;
            scrFile.GetScreenshot().SaveAsFile("C:\\Selenium\\"+fname, System.Drawing.Imaging.ImageFormat.Jpeg);
	  }

    public static void ranClick(string ranSel, int min, int max)
        {// Elegir elemento al azar
            Random rand = new Random();

            int d = rand.Next(min, max);
            if (d < min) { d = d + 1; }
            if (d > max) { d = d - 1; }
            if ((d % 2) == 0)
            {
                d = d - 1;
            }
            driver.FindElement(By.Id(ranSel + d)).Click();

        }

    }

    }
