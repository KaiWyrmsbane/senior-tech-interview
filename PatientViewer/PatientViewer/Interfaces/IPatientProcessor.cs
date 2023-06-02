using PatientViewer.Models;

namespace PatientViewer.Interfaces
{
    public interface IPatientProcessor
    {
        Task<string> GetPatients();
        Task<string> GetPatientById(string id);
    }
}
