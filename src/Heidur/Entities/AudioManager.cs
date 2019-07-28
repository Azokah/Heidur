using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public class AudioManager
    {
        public Song currentSong;

        public AudioManager()
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = Constants.Music.DEFAULT_VOLUMEN_AUDIO;
        }

        public void Play()
        {
            if (currentSong != null)
            {
                MediaPlayer.Play(currentSong);
            }
        }

        public void Play(Song song)
        {
            MediaPlayer.Stop();
            currentSong = song;
            MediaPlayer.Play(currentSong);
        }

        public void LoadContent(Game1 game)
        {
            currentSong = game.Content.Load<Song>(Constants.Music.DEFAULT_MUSIC);
        }

        public void LoadContentAndPlay(Game1 game)
        {
            currentSong = game.Content.Load<Song>(Constants.Music.DEFAULT_MUSIC);
            this.Play();
        }
    }
}
