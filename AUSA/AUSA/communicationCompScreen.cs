using System;
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
    class communicationCompScreen : ausaFieldsConfiguration
    {
        public static void ibCommunication()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(comLabel)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            takeScreenShot("communication.jpg");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_Title_box_data")).SendKeys("Communication"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_type_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_mean_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_motive_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_type_ori_des_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown("ctl00_ContentZone_ctrlComunication_cmb_ori_des_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_importance_cmb_dropdown");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_subject_box_data")).SendKeys("Created by Automation Script");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_comment_box_data")).SendKeys("This Communication was created by an automation script for testing purpose");
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("El Componente Comunicación ha sido creado para la Parte No. "+partText);

        }

    }
}
