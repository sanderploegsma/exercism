public class SalaryCalculator {
    private static final double BASE_SALARY = 1000.00;
    private static final double SALARY_CAP = 2000.00;


    public double multiplierPerDaysSkipped(int daysSkipped) {
        var penalty = daysSkipped > 5 ? 0.15 : 0;
        return 1.0 - penalty;
    }

    public int multiplierPerProductsSold(int productsSold) {
        return productsSold > 20 ? 13 : 10;
    }

    public double bonusForProductSold(int productsSold) {
        return productsSold * multiplierPerProductsSold(productsSold);
    }

    public double finalSalary(int daysSkipped, int productsSold) {
        var salary = BASE_SALARY * multiplierPerDaysSkipped(daysSkipped) + bonusForProductSold(productsSold);
        return Math.min(salary, SALARY_CAP);
    }
}
