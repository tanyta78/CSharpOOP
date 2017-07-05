using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numberOfSongs = int.Parse(Console.ReadLine());
        var playlist = new List<Song>();

        for (int i = 0; i < numberOfSongs; i++)
        {
            string[] info = Console.ReadLine().Split(';');
            Song song = null;
            try
            {
                var author = info[0];
            var songName = info[1];
            var time = info[2].Split(':');
            var minutes = int.Parse(time[0]);
            var seconds = int.Parse(time[1]);
            

                song = new Song(songName, author, seconds, minutes);
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (song != null)
            {
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
        }
        if (playlist.Count > 0)
        {
            Console.WriteLine($"Songs added: {playlist.Count}");
            var durationInSeconds = playlist.Sum(s => s.Seconds) + playlist.Sum(s => s.Minutes) * 60;

            var minutes = durationInSeconds / 60;
            var seconds = durationInSeconds % 60;
            var hours = minutes / 60;
            minutes %= 60;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }
}