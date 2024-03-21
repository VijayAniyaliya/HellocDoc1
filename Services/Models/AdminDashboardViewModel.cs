using Data.Entity;

namespace Services.Models
{
    public class AdminDashboardViewModel
    {

        public List<RequestClient> requestClients {  get; set; }

        public List<Region> regions { get; set; }

        public int region { get; set; }

        public int status { get; set; }

        public string url { get; set; }

        public string patientname { get; set; }

        public int requesttype { get; set; } 
        public string TransferNotes { get; set; }
        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }

        public int TotalPage { get; set; }
        public int newCount { get; set; }

        public int pendingCount { get; set; }

        public int activeCount { get; set; }

        public int concludeCount { get; set; }

        public int tocloseCount { get; set; }

        public int unpaidCount { get; set; }


    }
}
