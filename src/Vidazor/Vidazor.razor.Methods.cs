using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using Vidazor.Types;

namespace Vidazor
{
    public partial class Vidazor
    {
        /// <summary>
        /// Plays the video playback.
        /// </summary>
        public void Play() => InvokeFunctionVoid();

        /// <summary>
        /// Pauses the video playback.
        /// </summary>
        public void Pause() => InvokeFunctionVoid();

        /// <summary>
        /// Reloads the video.
        /// </summary>
        public void Load() => InvokeFunctionVoid();

        /// <summary>
        /// Checks if the browser can play a video with the specified MIME media type.
        /// </summary>
        public MediaPlayableStatus CanPlayType(string mediaType)
        {
            string resultAsString = InvokeFunction<string>(arguments: mediaType);
            if (Enum.TryParse(resultAsString, true, out MediaPlayableStatus result))
                return result;
            return MediaPlayableStatus.No;
        }

        // Private Helper Methods:
        private void InvokeFunctionVoid([CallerMemberName] string functionName = null)
        {
            functionsModule.InvokeVoid("invokeFunction", VideoElement, ToCamelCase(functionName));
        }

        private T InvokeFunction<T>([CallerMemberName] string functionName = null, params object[] arguments)
        {
            return functionsModule.Invoke<T>("invokeFunction", VideoElement, ToCamelCase(functionName), arguments);
        }
    }
}
