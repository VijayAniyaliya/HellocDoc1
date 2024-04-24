using Services.Models;

namespace Services.Contracts
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
        Task<byte[]> DownloadExcle(SearchRecordsViewModel model);
        Task DeleteRecord(int RequestId);
        Task<byte[]> DownloadFilesForRequest(int request_id);
    }
}