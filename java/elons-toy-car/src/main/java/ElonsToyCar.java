public class ElonsToyCar {
    private int distanceDriven = 0;
    private int batteryLevel = 100;

    public static ElonsToyCar buy() {
        return new ElonsToyCar();
    }

    public String distanceDisplay() {
        return String.format("Driven %d meters", distanceDriven);
    }

    public String batteryDisplay() {
        return batteryLevel > 0 ? String.format("Battery at %d%%", batteryLevel) : "Battery empty";
    }

    public void drive() {
        if (batteryLevel == 0) return;

        batteryLevel -= 1;
        distanceDriven += 20;
    }
}
