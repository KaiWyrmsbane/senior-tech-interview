using PatientBackend.Interfaces;
using System.Net.Http.Headers;

namespace PatientBackend
{
    public class GetPatientByAPI : IPatientProcessor
    {
        HttpClient httpclient = new HttpClient();
        public GetPatientByAPI()
        {
            //id tester 62421a54-0e45-4030-932c-0eeed3e08a2e
            httpclient.BaseAddress = new Uri("https://ti-patient-service.azurewebsites.net");
            httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> GetPatientById(string id)
        {
            HttpResponseMessage response = httpclient.GetAsync($"/patient/{id}").Result;
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPatients()
        {
            HttpResponseMessage response = httpclient.GetAsync("/patients").Result;
            return await response.Content.ReadAsStringAsync();

        }
    }
}
