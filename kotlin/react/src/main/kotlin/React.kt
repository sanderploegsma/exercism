import kotlin.properties.Delegates

class Reactor<T> {
    interface Subscription {
        fun cancel()
    }

    abstract inner class Cell {
        abstract val value: T
        internal val subscribers = mutableListOf<ComputeCell>()
    }

    inner class InputCell(initialValue: T) : Cell() {
        override var value by Delegates.observable(initialValue) { _, _, _ ->
            subscribers.forEach { it.updateValue() }
            subscribers.forEach { it.notify() }
        }
    }

    inner class Callback(initialValue: T, callback: (T) -> Any) {
        var value: T? by Delegates.observable(initialValue) { _, oldValue, newValue ->
            if (newValue != null && newValue != oldValue) {
                callback.invoke(newValue)
            }
        }
    }

    inner class ComputeCell(private val cells: List<Cell>, private val calculate: (List<T>) -> T) : Cell() {

        constructor(vararg cells: Cell, getValue: (List<T>) -> T) : this(cells.toList(), getValue) {
            cells.forEach { it.subscribers.add(this) }
        }

        private val callbacks = mutableMapOf<Int, Callback>()
        private var callbackId = 0

        override var value = calculate()
            private set

        fun addCallback(callback: (T) -> Any): Subscription {
            val id = callbackId++
            callbacks[id] = Callback(value, callback)
            return object : Subscription {
                override fun cancel() {
                    callbacks.remove(id)
                }
            }
        }

        private fun calculate() = calculate(cells.map { it.value })

        internal fun updateValue() {
            val nextValue = calculate()
            if (nextValue != value) {
                value = nextValue
                subscribers.forEach { it.updateValue() }
            }
        }

        internal fun notify() {
            callbacks.values.forEach { it.value = value }
            subscribers.forEach { it.notify() }
        }
    }
}
