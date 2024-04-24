using Services.Model;

namespace Services.Contracts
{
    public interface IPatientServices
    {
        void DeleteRecord(int PatientId);
        PatientTableViewModel PatientData(PatientTableViewModel model);
        PatientFormViewModel EditPatientForm(int PatientId);
        void SubmitPatientForm(PatientFormViewModel model, int gender);
        void EditPatientData(PatientFormViewModel model, int gender);
    }
}