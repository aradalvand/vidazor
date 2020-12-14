using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Vidazor
{
    public partial class Vidazor
    {
        /// <summary>
        /// Fires when the loading of an video is aborted.
        /// </summary>
        [Parameter]
        public EventCallback OnAbort { get; set; }

        /// <summary>
        /// Fires when the browser can start playing the video, but estimates that it will have to stop for further buffering (i.e. loading).
        /// </summary>
        [Parameter]
        public EventCallback OnCanPlay { get; set; }

        /// <summary>
        /// Fires when the browser can play through the video without stopping for buffering (i.e. loading).
        /// </summary>
        [Parameter]
        public EventCallback OnCanPlayThrough { get; set; }

        /// <summary>
        /// Fires when the duration of the video is updated.
        /// </summary>
        /// <remarks>
        /// Tip: When a video is initially loaded, the duration changes from "NaN" to the actual duration of the video, therefore, this event fires.
        /// </remarks>
        [Parameter]
        public EventCallback OnDurationChange { get; set; }

        /// <summary>
        /// Fires when the current playlist is empty.
        /// </summary>
        [Parameter]
        public EventCallback OnEmptied { get; set; }

        /// <summary>
        /// Fires when the video has finished, and no further data is available.
        /// </summary>
        [Parameter]
        public EventCallback OnEnded { get; set; }

        /// <summary>
        /// Fires when the video could not be loaded due to an error.
        /// </summary>
        [Parameter]
        public EventCallback OnError { get; set; }

        /// <summary>
        /// Fires when the browser has loaded the current frame of the video.
        /// </summary>
        [Parameter]
        public EventCallback OnLoadedData { get; set; }

        /// <summary>
        /// Fires when the browser has loaded the video's metadata (e.g. length, etc.)
        /// </summary>
        [Parameter]
        public EventCallback OnLoadedMetadata { get; set; }

        /// <summary>
        /// Fires when the browser has started to load the video.
        /// </summary>
        [Parameter]
        public EventCallback OnLoadStart { get; set; }

        /// <summary>
        /// Fires when the video has been paused.
        /// </summary>
        [Parameter]
        public EventCallback OnPause { get; set; }

        /// <summary>
        /// Fires when the video has been started or is no longer paused.
        /// </summary>
        [Parameter]
        public EventCallback OnPlay { get; set; }

        /// <summary>
        /// Fires when the video has been started to play after having been paused OR stopped for buffering (i.e. loading).
        /// </summary>
        [Parameter]
        public EventCallback OnPlaying { get; set; }

        /// <summary>
        /// Fires preiodically when the browser loads the video.
        /// </summary>
        [Parameter]
        public EventCallback OnProgress { get; set; }

        /// <summary>
        /// Fires when the playback rate (i.e. speed) of the video has changed.
        /// </summary>
        [Parameter]
        public EventCallback OnRateChanged { get; set; }

        /// <summary>
        /// Fires when the user has finished moving/skipping to a new position in the video.
        /// </summary>
        [Parameter]
        public EventCallback OnSeeked { get; set; }

        /// <summary>
        /// Fires when the user begins moving/skipping to a new position in the video.
        /// </summary>
        [Parameter]
        public EventCallback OnSeeking { get; set; }

        /// <summary>
        /// Fires when the browser is trying to get media data, but data is unexpectedly not forthcoming.
        /// </summary>
        [Parameter]
        public EventCallback OnStalled { get; set; }

        /// <summary>
        /// Fires when the browser is intentionally not getting media data.
        /// </summary>
        [Parameter]
        public EventCallback OnSuspend { get; set; }

        /// <summary>
        /// Fires when the current time has changed.
        /// </summary>
        [Parameter]
        public EventCallback OnTimeUpdate { get; set; }

        /// <summary>
        /// Fires when the volume level has been changed.
        /// </summary>
        [Parameter]
        public EventCallback OnVolumeChange { get; set; }

        /// <summary>
        /// Fires when the video stops because it needs to buffer (i.e. load) the next frame.
        /// </summary>
        [Parameter]
        public EventCallback OnWaiting { get; set; }

        // The Generic Event Handler:
        // This method gets called for every event, it then looks up the passed "eventName" in the "events" Dictionary and finds the event callback, and invokes it.
        [JSInvokable]
        public async Task EventFired(string eventName)
        {
            await events[eventName].InvokeAsync();
        }

        // Private Helper Methods:
        private void SubscribeToEvent(string eventName)
        {
            functionsModule.InvokeVoid("subscribeToEvent", VideoElement, objRef, eventName);
        }

        private static string ToJavaScriptEventName(string eventName)
        {
            // Removes the "On" prefix from the event name, and makes all the letters lowercase.
            return eventName[2..].ToLower();
        }
    }
}
