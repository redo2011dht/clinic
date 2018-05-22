using System.Collections.Generic;
using ReDo;
using System;

namespace Clinic.Report
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public void Init(string clinicname, string clinicphone, string clinicaddress, string patientno, string docno, string examdate,
         string patientname, string patientbirthdate, string patientgender, string patientaddress, string patientphone, string symptom, string diagnostic,
         string advice, string doctor, List<Fee> lstfee)
        {
            pClinicName.Value = clinicname;
            pClinicPhone.Value = clinicphone;
            pClinicAddress.Value = clinicaddress;
            pPatientNo.Value = patientno;
            pDocNo.Value = docno;
            pExamDate.Value = "Ngày khám: "+examdate;
            pPatientName.Value = patientname;
            pPatientBirthdate.Value = patientbirthdate;
            pPatientGender.Value = patientgender;
            pPatientAddress.Value = patientaddress;
            pPatientPhone.Value = patientphone;
            pSymptom.Value = symptom;
            pDiagnostic.Value = diagnostic;
            pAdvice.Value = advice;
            pDoctorName.Value = doctor;
            pPrintedDate.Value = string.Format("{0}, ngày {1} tháng {2} năm {3} ", clinicaddress.Split('-')[1],
                                    DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            objectDataSource1.DataSource = lstfee;

            long total = 0;
            foreach (var item in lstfee)
            {
                total += item.sum;
            }
            pReadingNumber.Value = ReDo.Common.ReadingNumber(total);

        }

    }
}
