class BankAccount {
    
    private var currentBalance = 0L
    private var active = true

    val balance get() = synchronized(this) {
            if (active) currentBalance
            else throw IllegalStateException() }

    fun adjustBalance(amount: Long) = synchronized(this) {
        if (!active) {
            throw IllegalStateException()
        }
        
        currentBalance += amount
    }

    fun close() = synchronized(this) {
        active = false
    }
}
