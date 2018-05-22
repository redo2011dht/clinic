using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using ReDo;

namespace ReDoReportForm
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public void Init(string clinicname, string clinicphone, string clinicaddress,string patientno,string docno, string examdate,
            string patientname,string patientbirthdate,string patientgender, string patientaddress, string patientphone,string symptom, string diagnostic,
            string advice,List<Fee> lstfee)
        {
            pClinicName.Value = clinicname;
            pClinicPhone.Value = clinicphone;
            pClinicAddress.Value = clinicaddress;
            pPatientNo.Value = patientno;
            pDocNo.Value = docno;
            pExamDate.Value = examdate;
            pPatientName.Value = patientname;
            pPatientBirthdate.Value = patientbirthdate;
            pPatientGender.Value = patientgender;
            pPatientAddress.Value = patientaddress;
            pPatientPhone.Value = patientphone;
            pSymptom.Value = symptom;
            pDiagnostic.Value = diagnostic;
            pAdvice.Value = advice;
            objectDataSource1.DataSource = lstfee;
            long total = 0;
            foreach(var item in lstfee)
            {
                total += item.sum;
            }
            pNumberToString.Value =  Common.ReadingNumber(total);
        }

    }
}
