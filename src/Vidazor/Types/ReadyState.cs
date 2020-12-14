namespace Vidazor.Types
{
    public enum ReadyState
    {
        /// <summary>
        /// No information is available about the video resource.
        /// </summary>
        HaveNothing,

        /// <summary>
        /// Metadata about the video resource is available.
        /// </summary>
        HaveMetadata,

        /// <summary>
        /// Data for the current time is available, but not enough to play more than one frame.
        /// </summary>
        HaveCurrentData,

        /// <summary>
        /// Data for the current time is available, in addition to at least another frame.
        /// </summary>
        HaveFutureData,

        /// <summary>
        /// Enough data is available that the video can be played without interruption.
        /// </summary>
        HaveEnoughData,
    }
}
