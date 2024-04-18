using Services.Models;

namespace Services.Implementation
{
    public interface IRecordsServices
    {
        Task<PatientHistoryViewModel> PatientRecords(int userid);
        Task<SearchRecordsViewModel> SearchRecords(SearchRecordsViewModel obj);
        Task<PatientHistoryViewModel> PatientHistory(PatientHistoryViewModel model);
        Task<BlockHistoryViewModel> BlockHistoryData(BlockHistoryViewModel obj);
        Task<LogsDataViewModel> EmailLogsData(LogsDataViewModel model);
        Task<LogsDataViewModel> SMSLogsData(LogsDataViewModel model);
        Task<LogsDataViewModel> EmailLogs();

        Task UnblockCase(int requestid);
    }
}