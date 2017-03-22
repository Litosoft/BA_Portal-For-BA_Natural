using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace BA_Portal.Models
{
    public class SOAPForm
    {

        [Key]
        public int ID { get; set; }
        public int GroupingID { get; set; }

        public string PractionerName { get; set; }
        public string PractionerLicenseNumber { get; set; }
        public string PatientName { get; set; }

        public int BP { get; set; }
        public string BodyTemperature { get; set; }
        public string SubjectiveObjectiveNotes { get; set; }
        public DateTime DateFilledIn { get; set; }


        public DateTime TimeTreatmentStarted { get; set; }
        //public string TimeTreatmentStarted { get; set; }
        public DateTime TimeTreatmentEnded { get; set; }
        //public string TimeTreatmentEnded { get; set; }

        public string SymptomsGeneral { get; set; }
        public string PresentingProblems { get; set; }
        //there are three options here. So int between 1 and 3 will determine the option.
        //with a string for descriptions
        //public int SymptomsChillsFever { get; set; }
        public string SymptomsChillsFeverNotes { get; set; }
        public bool SymptomsChillsFeverNone { get; set; }
        public bool SymptomsChillsFeverSubjective { get; set; }
        public bool SymptomsChillsFeverObjective { get; set; }

        //public int SymptomsPerspiraton { get; set; }
        public string SymptomsPerspiratonNotes { get; set; }
        public bool SymptomsPerspiratonNone { get; set; }
        public bool SymptomsPerspiratonSubjective { get; set; }
        public bool SymptomsPerspiratonObjective { get; set; }

        //public int SymptomsUrination { get; set; }
        public string SymptomsUrinationNotes { get; set; }
        public bool SymptomsUrinationNormal { get; set; }
        public bool SymptomsUrinationSubjective { get; set; }
        public bool SymptomsUrinationObjective { get; set; }

        //public int SymptomsHeadacheBodyache { get; set; }
        public string SymptomsHeadacheBodyacheNotes { get; set; }
        public bool SymptomsHeadacheBodyacheNone { get; set; }


        //public int SymptomsRespiration { get; set; }
        public string SymptomsRespirationNotes { get; set; }
        public bool SymptomsRespirationNormal { get; set; }
        public bool SymptomsRespirationSubjective { get; set; }
        public bool SymptomsRespirationObjective { get; set; }

        //public int SymptomsSleepEnergy { get; set; }
        public string SymptomsSleepEnergyNotes { get; set; }
        public bool SymptomsSleepEnergyNormal { get; set; }
        public bool SymptomsSleepEnergySubjective { get; set; }
        public bool SymptomsSleepEnergyObjective { get; set; }

        //public int SymptomsReproductive { get; set; }
        public string SymptomsReproductiveNotes { get; set; }
        public bool SymptomsReproductiveNormal { get; set; }



        //public int SymptomsMentalEmotional { get; set; }
        public string SymptomsMentalEmotionalNotes { get; set; }
        public bool SymptomsMentalEmotionalNormal { get; set; }
        public bool SymptomsMentalEmotionalSubjective { get; set; }
        public bool SymptomsMentalEmotionalObjective { get; set; }


        //public int SymptomsEarsEyesTeethGums { get; set; }
        public string SymptomsEarsEyesTeethGumsNotes { get; set; }
        public bool SymptomsEarsEyesTeethGumsNormal { get; set; }
        public bool SymptomsEarsEyesTeethGumsSubjective { get; set; }
        public bool SymptomsEarsEyesTeethGumsObjective { get; set; }

        //public int SymptomsAppetiteDigestionDefecation { get; set; }
        public string SymptomsAppetiteDigestionDefecationNotes { get; set; }
        public bool SymptomsAppetiteDigestionDefecationNormal { get; set; }
        public bool SymptomsAppetiteDigestionDefecationSubjective { get; set; }
        public bool SymptomsAppetiteDigestionDefecationObjective { get; set; }

        //public int SymptomsPalpitationDizzinessNumbness { get; set; }
        public string SymptomsPalpitationDizzinessNumbnessNotes { get; set; }
        public bool SymptomsPalpitationDizzinessNumbnessNone { get; set; }
        public bool SymptomsPalpitationDizzinessNumbnessSubjective { get; set; }
        public bool SymptomsPalpitationDizzinessNumbnessObjective { get; set; }

        public string TongueBodyColor { get; set; }
        //public string TongueBodyShape { get; set; } //add
        public string TongueCoating { get; set; }
        public string CoatColoration { get; set; }
        public string CoatRooting { get; set; }

        //otherphyiscal exams. what goes here?

        public int PulseRight { get; set; }
        public int PulseLeft { get; set; }

        public string AssessmentandDiagnosis { get; set; }
        public string PlanofTreatment { get; set; }

        public bool CleanNeedSet { get; set; }
        public string[] NeedlingSet1 { get; set; }
        public string NeedlingSet1asString { get; set; }
        public bool NeedlingSet1ElectricalStimulation { get; set; }
        public bool NeedlingSet1TuiNa { get; set; }
        public bool NeedlingSet1CuppingTherapy { get; set; }

        public string[] NeedlingSet2 { get; set; }
        public string NeedlingSet2asString { get; set; }
        public bool NeedlingSet2ElectricalStimulation { get; set; }
        public bool NeedlingSet2TuiNa { get; set; }
        public bool NeedlingSet2CuppingTherapy { get; set; }

        public string[] NeedlingSet3 { get; set; }
        public string NeedlingSet3asString { get; set; }
        public bool NeedlingSet3ElectricalStimulation { get; set; }
        public bool NeedlingSet3TuiNa { get; set; }
        public bool NeedlingSet3CuppingTherapy { get; set; }

        public string[] NeedlingSet4 { get; set; }
        public string NeedlingSet4asString { get; set; }
        public bool NeedlingSet4ElectricalStimulation { get; set; }
        public bool NeedlingSet4TuiNa { get; set; }
        public bool NeedlingSet4CuppingTherapy { get; set; }

        public string[] NeedlingSet5 { get; set; }
        public string NeedlingSet5asString { get; set; }
        public bool NeedlingSet5ElectricalStimulation { get; set; }
        public bool NeedlingSet5TuiNa { get; set; }
        public bool NeedlingSet5CuppingTherapy { get; set; }

        public string[] NeedlingSet6 { get; set; }
        public string NeedlingSet6asString { get; set; }
        public bool NeedlingSet6ElectricalStimulation { get; set; }
        public bool NeedlingSet6TuiNa { get; set; }
        public bool NeedlingSet6CuppingTherapy { get; set; }

        public string HerbalFormulaId1 { get; set; }
        public string HerbalFormulaId1Directions { get; set; }
        public string HerbalFormulaId2 { get; set; }
        public string HerbalFormulaId2Directions { get; set; }
        public string HerbalFormulaId3 { get; set; }
        public string HerbalFormulaId3Directions { get; set; }

        public string PostTreatmentAssessment { get; set; }
        public string Recomendations { get; set; }



    }



    public class SOAPFormDbContext : DbContext
    {
        public DbSet<SOAPForm> SOAPFormDatabase { get; set; }
    }

}
