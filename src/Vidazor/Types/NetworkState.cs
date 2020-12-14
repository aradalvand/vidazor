namespace Vidazor.Types
{
    public enum NetworkState
    {
        /// <summary>
        /// No data yet, the video is not yet initialized. Also, <see cref="Videazor.ReadyState"/> is also <see cref="ReadyState.HaveNothing"/>.
        /// </summary>
        Empty,

        /// <summary>
        /// The video is active and a resource is selected, but the network is not being used.
        /// </summary>
        Idle,

        /// <summary>
        /// The browser is downloading the data.
        /// </summary>
        Loading,

        /// <summary>
        /// No video source was found.
        /// </summary>
        NoSource,
    }
}
