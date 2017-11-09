using System;

public class InvalidSongException : Exception
{
    private string exMessage = "Invalid song.";

    public override string Message => exMessage;
}