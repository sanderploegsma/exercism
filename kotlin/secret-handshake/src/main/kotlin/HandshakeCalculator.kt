object HandshakeCalculator {
    private val actions = mapOf<Int, MutableList<Signal>.() -> Unit>(
        1 shl 0 to { add(Signal.WINK) },
        1 shl 1 to { add(Signal.DOUBLE_BLINK) },
        1 shl 2 to { add(Signal.CLOSE_YOUR_EYES) },
        1 shl 3 to { add(Signal.JUMP) },
        1 shl 4 to { reverse() },
    )

    fun calculateHandshake(number: Int) = buildList {
        actions
            .filterKeys { number and it != 0 }
            .forEach { (_, action) -> action.invoke(this) }
    }
}
