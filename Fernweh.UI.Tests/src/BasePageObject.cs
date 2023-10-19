using System.ComponentModel;

namespace Fernweh.UITests;
public abstract class BasePageObject
{
    public virtual string PagePath { get; set; } = "";
    public readonly string BasePath = "";

    protected IPage Page { get; set; }
    protected AppConfig AppConfig { get; set; }

    private readonly string _loadingDataSelector = ".loading-data";
    private readonly string _tableHeaderColsSelector = "thead tr th";
    private readonly string _tableRowsSelector = "tbody tr";
    private readonly string _tableColsSelector = "td";

    public BasePageObject(IPage page, AppConfig appConfig, string pagePath)
    {
        AppConfig = appConfig;
        Page = page;
        PagePath = pagePath;
        BasePath = $"{appConfig.TestUrl}{BasePath}";

        Page.WaitForLoadStateAsync(LoadState.NetworkIdle).GetAwaiter().GetResult();
        Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded).GetAwaiter().GetResult();
        Page.WaitForLoadStateAsync(LoadState.Load).GetAwaiter().GetResult();

        //var isReady = IsReady().GetAwaiter().GetResult();

        var loadingIndicatorCheckCount = 0;
        var loadingIndicatorIsVisible = Page.IsVisibleAsync(_loadingDataSelector).GetAwaiter().GetResult();

        while (loadingIndicatorIsVisible || loadingIndicatorCheckCount > 20)
        {
            Thread.Sleep(300);
            loadingIndicatorIsVisible = Page.IsVisibleAsync(_loadingDataSelector).GetAwaiter().GetResult();
            loadingIndicatorCheckCount++;
        }
    }

    public async Task<bool> IsBlazorWasmReady()
    {
        var wasmHasLoaded = await Page.EvaluateAsync<bool>("window.wasmHasLoaded");
        var retryCount = 0;
        
        while (wasmHasLoaded != true && ++retryCount < 30)
        {
            wasmHasLoaded = await Page.EvaluateAsync<bool>("window.wasmHasLoaded");
            await Task.Delay(400);
        }

        return wasmHasLoaded;
    }

    public async Task<string> GetTitleAsync()
    {
        await Task.Yield();
        return await Page.TitleAsync();
    }

    public async Task GotoAsync(string append = "")
    {
        await Page.GotoAsync($"{BasePath}{PagePath}{append}");
        await IsBlazorWasmReady();
        await Task.Delay(1000);
    }

    public string GetURL()
    {
        return Page.Url;
    }

    protected async Task<string[]> TableGetColumnNamesAsync(ILocator table)
    {
        var tableHeaderColumns = GetTableHeaderColsLocatorAsync(table);
        await tableHeaderColumns.First.WaitForAsync();

        var headers = new List<string>();
        var cols = await tableHeaderColumns.AllAsync();
        foreach (var col in cols)
        {
            var colText = (await col.InnerTextAsync()).ToLower();
            headers.Add(colText);
        }
        return headers.ToArray();
    }

    protected async Task<int> GetColumnIndexAsync(ILocator table, string columnName)
    {
        await table.WaitForAsync();
        var names = await TableGetColumnNamesAsync(table);
        return Array.IndexOf(names, columnName.ToLower());
    }

    protected async Task<int> GetRowIndexAsync(ILocator table, int columnIndex, string value)
    {
        if (columnIndex < 0) throw new ArgumentOutOfRangeException(nameof(columnIndex));

        var rowsLocator = GetTableRowsLocatorAsync(table);
        await rowsLocator.First.WaitForAsync();

        var rows = await rowsLocator.AllAsync();
        var rowIndex = 0;
        foreach (var row in rows)
        {
            var rowText = await row.TextContentAsync();
            var rowValues = rowText.Split("\n");
            if (rowValues[columnIndex] == value) return rowIndex;
            rowIndex++;
        }
        return -1;
    }

    protected async Task<string> GetTableRowColumnValueAsync(ILocator table, int rowIndex, int columnIndex)
    {
        if (rowIndex < 0) throw new ArgumentOutOfRangeException(nameof(rowIndex));
        if (columnIndex < 0) throw new ArgumentOutOfRangeException(nameof(columnIndex));

        var tableRows = GetTableRowsLocatorAsync(table);
        await tableRows.First.WaitForAsync();

        var rows = await tableRows.AllAsync();
        var row = rows[rowIndex];
        var col = (await GetTableColsLocatorAsync(row)).Nth(columnIndex);

        var colText = await col.InnerTextAsync();

        return colText;
    }

    protected async Task<string[]> TableGetRow(ILocator table, int rowIndex)
    {
        if (rowIndex < 0) throw new ArgumentOutOfRangeException(nameof(rowIndex));

        var tableRowsLocator = GetTableRowsLocatorAsync(table);
        await tableRowsLocator.First.WaitForAsync();

        var rows = await tableRowsLocator.AllAsync();
        var rowText = await rows[rowIndex].TextContentAsync();

        return rowText.Split("\n");
    }

    private ILocator GetTableHeaderColsLocatorAsync(ILocator table) => table.Locator(_tableHeaderColsSelector);
    private ILocator GetTableRowsLocatorAsync(ILocator table) => table.Locator(_tableRowsSelector);
    private ILocator GetTableColsLocatorAsync(ILocator tableRow) => tableRow.Locator(_tableColsSelector);
}