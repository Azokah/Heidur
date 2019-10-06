using Heidur.Entities.Components;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Heidur.Constants.SoundEffects;

namespace Heidur.Entities.Processors
{
    public static class AudioProcessor
    {
        public static void Play()
        {
            if (AudioComponent.currentSong != null)
            {
                MediaPlayer.Play(AudioComponent.currentSong);
            }
        }

        public static void Play(Song song)
        {
            MediaPlayer.Stop();
            AudioComponent.currentSong = song;
            MediaPlayer.Play(AudioComponent.currentSong);
        }

        public static void LoadContent(Game1 game)
        {
            AudioComponent.currentSong = game.Content.Load<Song>(Constants.Music.DEFAULT_MUSIC);
            AudioComponent.soundEffects.Add(game.Content.Load<SoundEffect>(Constants.SoundEffects.FXSoundsNamesAndPaths[(int)Constants.SoundEffects.FXSounds.HIT]));
        }

        public static void LoadContentAndPlay(Game1 game)
        {
            LoadContent(game);
            Play();
        }

        public static void PlaySoundEffect(FXSounds sound)
        {
            AudioComponent.soundEffects.ToArray()[(int)sound].Play();
        }
    }
}
