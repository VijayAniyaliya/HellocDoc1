using Data.Entity;

namespace Services.Models
{
    public class AdminDashboardViewModel
    {

        public List<RequestClient> requestClients {  get; set; }

        public string TransferNotes { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }
        public int newCount { get; set; }

        public int pendingCount { get; set; }

        public int activeCount { get; set; }

        public int concludeCount { get; set; }

        public int tocloseCount { get; set; }

        public int unpaidCount { get; set; }


    }
}
