namespace PatientBackend.Interfaces
{
    public interface IPatientProcessor
    {
        Task<string> GetPatients();
        Task<string> GetPatientById(string id);
    }
}
