using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidazor
{
    public partial class Vidazor
    {
        // Parameters:
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        // Injected Services:
        [Inject]
        IJSRuntime JS { get; set; }

        // Public Properties:
        public ElementReference VideoElement { get; set; }

        // Private Fields:
        IJSInProcessObjectReference functionsModule;
        DotNetObjectReference<Vidazor> objRef;
        Dictionary<string, EventCallback> events;

        // Lifecycle Methods:
        protected override void OnInitialized()
        {
            objRef = DotNetObjectReference.Create(this);
            events = GetType().GetProperties().Where(p => p.PropertyType == typeof(EventCallback) && ((EventCallback)p.GetValue(this)).HasDelegate)
                     .ToDictionary(keySelector: p => ToJavaScriptEventName(p.Name),
                                   elementSelector: p => (EventCallback)p.GetValue(this));
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // TODO: If this problem (https://github.com/dotnet/aspnetcore/issues/28627) gets solved, make the following line synchronous, and move it to the OnInitialized method: (also see if you can receieve JSInProcessRuntime instead of JSRuntime as a service.)
                functionsModule = await JS.InvokeAsync<IJSInProcessObjectReference>("import", "./_content/Vidazor/functions.js");

                foreach (var e in events)
                    SubscribeToEvent(e.Key);
            }
        }

        // Private Helper Methods:
        private static string ToCamelCase(string str)
        {
            return char.ToLower(str[0]) + str[1..];
        }

        // Dispose:
        public void Dispose()
        {
            objRef?.Dispose();
            functionsModule?.Dispose();
        }
    }
}
