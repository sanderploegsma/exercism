class NeedForSpeed {
    private static final int NITRO_SPEED = 50;
    private static final int NITRO_BATTERY_DRAIN = 4;

    private final int speed;
    private final int batteryDrain;
    private int batteryPercentage = 100;
    private int distance = 0;

    public NeedForSpeed(int speed, int batteryDrain) {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public boolean batteryDrained() {
        return batteryPercentage == 0;
    }

    public int distanceDriven() {
        return distance;
    }

    public void drive() {
        if (batteryPercentage < batteryDrain) return;
        distance += speed;
        batteryPercentage -= batteryDrain;
    }

    public static NeedForSpeed nitro() {
        return new NeedForSpeed(NITRO_SPEED, NITRO_BATTERY_DRAIN);
    }
}

class RaceTrack {
    private final int distance;

    public RaceTrack(int distance) {
        this.distance = distance;
    }

    public boolean tryFinishTrack(NeedForSpeed car) {
        while (car.distanceDriven() < distance && !car.batteryDrained()) {
            car.drive();
        }
        return car.distanceDriven() >= distance;
    }
}
