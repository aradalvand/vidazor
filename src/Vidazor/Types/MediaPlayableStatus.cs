namespace Vidazor.Types
{
    public enum MediaPlayableStatus
    {
        /// <summary>
        /// Indicates that the media type is probably playable.
        /// </summary>
        Probably,

        /// <summary>
        /// Indicates that there's not enough information to determine whether the media type will be playable or not.
        /// </summary>
        Maybe,

        /// <summary>
        /// Indicates that the media type is not playable.
        /// </summary>
        No,
    }
}
