namespace Vidazor.Types
{
    public enum Preload
    {
        /// <summary>
        /// Indicates that the whole video can be loaded.
        /// </summary>
        Auto,

        /// <summary>
        /// Indicates that only the metadata (e.g. length) of the video is loaded.
        /// </summary>
        Metadata,

        /// <summary>
        /// Indicates that the video should not be preloaded.
        /// </summary>
        None,
    }
}
