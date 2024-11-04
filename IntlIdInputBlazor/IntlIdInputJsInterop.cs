using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace IntlIdInputBlazor;

public class IntlIdInputJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private IJSObjectReference? _module;

    public IntlIdInputJsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/IntlIdInputBlazor/js/intlIdInputJsInterop.js").AsTask());
    }

    public async ValueTask<int> Init(ElementReference reference, object options)
    {
        _module = await _moduleTask.Value;
        return await (await _moduleTask.Value).InvokeAsync<int>("init", reference, options);
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
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}