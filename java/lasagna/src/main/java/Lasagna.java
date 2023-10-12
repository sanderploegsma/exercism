public class Lasagna {
    private static final int PREPARATION_TIME_PER_LAYER = 2;

    public int expectedMinutesInOven() {
        return 40;
    }

    public int remainingMinutesInOven(int elapsedMinutes) {
        return expectedMinutesInOven() - elapsedMinutes;
    }

    public int preparationTimeInMinutes(int numberOfLayers) {
        return numberOfLayers * PREPARATION_TIME_PER_LAYER;
    }

    public int totalTimeInMinutes(int numberOfLayers, int elapsedMinutes) {
        return preparationTimeInMinutes(numberOfLayers) + elapsedMinutes;
    }
}
