using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientViewer.Interfaces;
using PatientViewer.Models;
using System.Net.Http.Headers;

namespace PatientViewer
{
    public class GetPatientByAPI : IPatientProcessor
    {
        HttpClient httpclient = new HttpClient();
        public GetPatientByAPI()
        {
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
