module main

fn collatz(number int) !int {
	if number < 1 {
		return error("Only positive values are supported")
	}

	if number == 1 {
		return 0
	}

	next := if number % 2 == 0 { number / 2 } else { 3 * number + 1 }
	result := collatz(next) or { return err }
	return result + 1
}
