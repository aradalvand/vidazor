using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using Vidazor.Types;

namespace Vidazor
{
    public partial class Vidazor
    {
        /// <summary>
        /// Gets or sets a Boolean indicating whether playback automatically begins as soon as enough of the video is available to do so without interruption.
        /// </summary>
        public bool Autoplay
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets an array of <see cref="TimeRange"/> objects representing the parts of the video that the browser has buffered (i.e. loaded).
        /// </summary>
        public TimeRange[] Buffered
        {
            get => GetValue<TimeRange[]>();
        }

        /// <summary>
        /// Gets or sets a Boolean reflecting the "controls" HTML attribute, indicating whether browser's default UI controls are displayed for the video.
        /// </summary>
        public bool Controls
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the CORS settings of the video.
        /// </summary>
        public string CrossOrigin
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets the source URL of the current video.
        /// </summary>
        /// <remarks>
        /// Tip: To set the source URL, use the <see cref="Src"/> property.
        /// </remarks>
        public string CurrentSrc
        {
            get => GetValue<string>();
        }

        /// <summary>
        /// Gets or sets a double indicating the current playback time in seconds.
        /// </summary>
        public double CurrentTime
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets a Boolean reflecting the "muted" HTML attribute, indicating whether the video is muted by default.
        /// </summary>
        public bool DefaultMuted
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets a double indicating the default playback rate (i.e. speed) for the video.
        /// </summary>
        public double DefaultPlaybackRate
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets a double indicating the total length of the video in seconds.
        /// </summary>
        public double Duration
        {
            get => GetValue<double>();
        }

        /// <summary>
        /// Gets a Boolean indicating whether the video has ended.
        /// </summary>
        public bool Ended
        {
            get => GetValue<bool>();
        }

        /// <summary>
        /// Gets or sets a Boolean reflecting the "loop" HTML attribute, indicating whether the video should start over again after it has ended.
        /// </summary>
        public bool Loop
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the name of the media group that the video belongs to.
        /// </summary>
        public bool MediaGroup
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets a Boolean indicating whether the video is muted or not.
        /// </summary>
        public bool Muted
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets a <see cref="Types.NetworkState" /> enum indicating the current state of fetching the media over the network.
        /// </summary>
        public NetworkState NetworkState
        {
            get => GetValue<NetworkState>();
        }

        /// <summary>
        /// Gets a Boolean indicating whether the video is paused or not.
        /// </summary>
        public bool Paused
        {
            get => GetValue<bool>();
        }

        /// <summary>
        /// Gets or sets a double indicating the current playback rate (i.e. speed) of the video. Can be a negative number, which indicates backward playback.
        /// </summary>
        public double PlaybackRate
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets an array of <see cref="TimeRange"/> objects representing the parts of the video that has been played by the user.
        /// </summary>
        public TimeRange[] Played
        {
            get => GetValue<TimeRange[]>();
        }

        /// <summary>
        /// Gets or sets a <see cref="Types.Preload"/> enum reflecting the "preload" HTML attribute, indicating what content should be loaded before the video is played by the user.
        /// </summary>
        public Preload Preload
        {
            get => Enum.Parse<Preload>(GetValue<string>(), true);
            set => SetValue(value.ToString().ToLower());
        }

        /// <summary>
        /// Gets a <see cref="Types.ReadyState"/> enum indicating the readiness state of the video (e.g. whether enough of the video has been downloaded to be able to play the video, etc.)
        /// </summary>
        public ReadyState ReadyState
        {
            get => GetValue<ReadyState>();
        }

        /// <summary>
        /// Gets an array of <see cref="TimeRange"/> objects representing the parts of the video that the user can seek to (i.e. move the playback position to).
        /// </summary>
        public TimeRange[] Seekable
        {
            get => GetValue<TimeRange[]>();
        }

        /// <summary>
        /// Gets a Boolean indicating whether the user is currently seeking in the video.
        /// </summary>
        public bool Seeking
        {
            get => GetValue<bool>();
        }

        /// <summary>
        /// Gets or sets a URL reflecting the "src" HTML attribute, indicating the source URL of the video.
        /// </summary>
        public string Src
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets a double indicating the volume level, from 0.0 (silent) to 1.0 (loudest).
        /// </summary>
        public double Volume
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        // Properties not included above:
        // - "textTracks" (Reason: Difficult to implement, no real use at the moment)
        // - "controller" (Reason: Poor browser support)
        // - "startDate" (Reason: Poor browser support)
        // - "videoTracks" (Reason: Poor browser support)
        // - "audioTracks" (Reason: Poor browser support)

        // Private Helper Methods:
        private T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            return functionsModule.Invoke<T>("getProperty", VideoElement, ToCamelCase(propertyName));
        }

        private void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            functionsModule.InvokeVoid("setProperty", VideoElement, ToCamelCase(propertyName), value);
        }
    }
}
