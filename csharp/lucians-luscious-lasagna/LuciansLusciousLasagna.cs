class Lasagna
{
    private const int MinutesInOven = 40;
    private const int MinutesToPrepareOneLayer = 2;

    public int ExpectedMinutesInOven() => MinutesInOven;

    public int RemainingMinutesInOven(int minutesInOven) =>
        ExpectedMinutesInOven() - minutesInOven;

    public int PreparationTimeInMinutes(int numberOfLayers) =>
        MinutesToPrepareOneLayer * numberOfLayers;

    public int ElapsedTimeInMinutes(int numberOfLayers, int minutesInOven) =>
        PreparationTimeInMinutes(numberOfLayers) + minutesInOven;
}
