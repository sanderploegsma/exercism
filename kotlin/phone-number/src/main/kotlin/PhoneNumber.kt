private const val REQUIRED_LENGTH = 10

class PhoneNumber(input: String) {
    val number: String

    init {
        val digits = input.filter { it.isDigit() }.let {
            if (it.length == 11 && it[0] == '1') it.drop(1) else it
        }

        require(digits.length == REQUIRED_LENGTH) { "Phone number $input is invalid: length is not $REQUIRED_LENGTH" }
        require(digits[0] !in "01") { "Phone number $input is invalid: area code may not start with 0 or 1" }
        require(digits[3] !in "01") { "Phone number $input is invalid: exchange code may not start with 0 or 1" }

        number = digits
    }
}
