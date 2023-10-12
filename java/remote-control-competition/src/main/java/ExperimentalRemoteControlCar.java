public class ExperimentalRemoteControlCar implements RemoteControlCar {
    private static final int SPEED = 20;
    private int distance;

    public void drive() {
        distance += SPEED;
    }

    public int getDistanceTravelled() {
        return distance;
    }
}
