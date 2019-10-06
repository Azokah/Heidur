using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Heidur.Entities.Components
{
    public static class AudioComponent
    {
        public static Song currentSong;
        public static HashSet<SoundEffect> soundEffects;

        static AudioComponent()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = Constants.Music.DEFAULT_VOLUMEN_AUDIO;
            soundEffects = new HashSet<SoundEffect>();
        }
    }
}
