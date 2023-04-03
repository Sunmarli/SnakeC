using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Collections.Generic;

    namespace SnakeC
    {
        public class Sounds
        {
            private WindowsMediaPlayer backgroundPlayer;
            private WindowsMediaPlayer effectPlayer;
            private string pathToMedia;
            private string currentSoundName;
            private Dictionary<string, WindowsMediaPlayer> players = new Dictionary<string, WindowsMediaPlayer>();

            public Sounds(string pathToResources)
            {
                pathToMedia = pathToResources;
                backgroundPlayer = new WindowsMediaPlayer();
                backgroundPlayer.settings.volume = 30;
                effectPlayer = new WindowsMediaPlayer();
                effectPlayer.settings.volume = 100;
                players.Add("background", backgroundPlayer);
                players.Add("effect", effectPlayer);
            }

            public void PlayBackground()
            {
                StopAll();
                currentSoundName = "background";
                backgroundPlayer.URL = pathToMedia + "Wallpaper.mp3";
                backgroundPlayer.controls.play();
                backgroundPlayer.settings.setMode("loop", true);
            }

            public void PlayGameOver()
            {
                StopAll();
                currentSoundName = "effect";
                effectPlayer.URL = pathToMedia + "gameover.mp3";
                effectPlayer.controls.play();
            }

            public void PlayEat()
            {
                effectPlayer.URL = pathToMedia + "chew.mp3";
                effectPlayer.controls.play();
            }

            private void Stop(WindowsMediaPlayer player)
            {
                player.controls.stop();
                player.URL = null;
            }

            public void StopAll()
            {
                foreach (var item in players)
                {
                    if (item.Key != currentSoundName)
                    {
                        Stop(item.Value);
                    }
                }
            }
        }
    }

