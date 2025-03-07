using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IntlIdInputBlazor;

public class IntlIdInputJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private IJSObjectReference? _module;
    private EventCallback<IntlIdCountryData>? _onCountryChangeCallback;

    public IntlIdInputJsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/IntlIdInputBlazor/js/intlIdInputJsInterop.js").AsTask());
    }

    public async ValueTask<int> InitializeAsync(ElementReference reference, object options, EventCallback<IntlIdCountryData> onCountryChange)
    {
        _module = await _moduleTask.Value;
        _onCountryChangeCallback = onCountryChange;
        return await (await _moduleTask.Value).InvokeAsync<int>("init", reference, options, DotNetObjectReference.Create(this), nameof(this.HandleCountryChange));
    }

    [JSInvokable]
    public async Task HandleCountryChange(IntlIdCountryData countryData)
    {
        if (_onCountryChangeCallback.HasValue)
        {
            await _onCountryChangeCallback.Value.InvokeAsync(countryData);
        }
    }

    public async ValueTask<IntlId> GetData(int inputIndex)
    {
        return await _module!.InvokeAsync<IntlId>("get", inputIndex);
    }

    public async ValueTask SetNumber(int id, string number)
    {
        await _module!.InvokeVoidAsync("setNumber", id, number);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            IJSObjectReference module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}