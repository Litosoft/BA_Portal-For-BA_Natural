using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BA_Portal.Models
{
    public class SOAP
    {
        public int ID { get; set; }
        public string PractionerName { get; set; }
        public string PractionerLicenseNumber { get; set; }

        public int BP { get; set; }
        public string BodyTemperature { get; set; }
        public string SubjectiveObjectiveNotes { get; set; }
        public DateTime DateFilledIn { get; set; }
        public DateTime TimeTreatmentStarted { get; set; }
        public DateTime TimeTreatmentEnded { get; set; }

        public string SymptomsGeneral { get; set; }
        //there are three options here. So int between 1 and 3 will determine the option.
        //with a string for descriptions
        public int SymptomsChillsFever { get; set; }
        public string SymptomsChillsFeverNotes { get; set; }
        public int SymptomsPerspiraton { get; set; }
        public string SymptomsPerspiratonNotes { get; set; }
        public int SymptomsUrination { get; set; }
        public string SymptomsUrinationNotes { get; set; }
        public int SymptomsHeadacheBodyache { get; set; }
        public string SymptomsHeadacheBodyacheNotes { get; set; }
        public int SymptomsRespiration { get; set; }
        public string SymptomsRespirationNotes { get; set; }
        public int SymptomsSleepEnergy { get; set; }
        public string SymptomsSleepEnergyNotes { get; set; }
        public int SymptomsReproductive { get; set; }
        public string SymptomsReproductiveNotes { get; set; }
        public int SymptomsMentalEmotional { get; set; }
        public string SymptomsMentalEmotionalNotes { get; set; }
        public int SymptomsEarsEyesTeethGums { get; set; }
        public string SymptomsEarsEyesTeethGumsNotes { get; set; }
        public int SymptomsAppetiteDigestionDefecation { get; set; }
        public string SymptomsAppetiteDigestionDefecationNotes { get; set; }
        public int SymptomsPalpitationDizzinessNumbness { get; set; }
        public string SymptomsPalpitationDizzinessNumbnessNotes { get; set; }




    }
}