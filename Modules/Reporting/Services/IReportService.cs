using GestionCommerciale.Modules.Reporting.ViewModels;

namespace GestionCommerciale.Modules.Reporting.Services;

public interface IReportService
{
    Task<List<ReportSaleByProductRow>> GetSalesByProductAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    Task<List<ReportSaleByCustomerRow>> GetSalesByCustomerAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    Task<List<ReportRefundRow>> GetRefundsAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    Task<List<ReportDailySaleRow>> GetDailySalesAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    Task<List<ReportUnpaidRow>> GetUnpaidSalesAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    Task<List<ReportClientSoldeRow>> GetClientSoldesAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    Task<List<ReportStockMovementRow>> GetStockMovementsAsync(
        DateTime from, DateTime to, CancellationToken ct = default);

    /// <param name="asOf">
    /// When set, stock qty is reconstructed as of this date (end of day).
    /// When null, uses current <c>StockActuel</c>.
    /// </param>
    Task<(decimal ht, decimal ttc, string devise)> GetStockValuationAsync(
        DateTime? asOf = null, CancellationToken ct = default);

    Task<ReportProfitChargesResult> GetProfitChargesAsync(
        DateTime from, DateTime to, CancellationToken ct = default);
}
