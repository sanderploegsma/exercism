object Prime {

    fun nth(n: Int): Int {
        require(n > 0) {
            "There is no zeroth prime."
        }
        
        return primes.drop(n - 1).first()
    }
    
    private val primes = sequence {
        val state = mutableListOf<Int>()
        
        for (i in 2..Int.MAX_VALUE) {
            if (state.all { i % it != 0 }) {
                yield(i)
                state += i
            }
        }
    }
}
