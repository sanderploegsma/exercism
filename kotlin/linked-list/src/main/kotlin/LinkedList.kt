class Deque<T> {
    private var head: Node<T>? = null
    private var tail: Node<T>? = null

    fun push(value: T) {
        tail = Node(value, previous = tail).also { it.previous?.next = it }

        if (head == null) {
            head = tail
        }
    }

    fun pop(): T? = tail?.value?.also { tail = tail?.previous }

    fun unshift(value: T) {
        head = Node(value, next = head).also { it.next?.previous = it }

        if (tail == null) {
            tail = head
        }
    }

    fun shift(): T? = head?.value?.also { head = head?.next }
}

private class Node<T>(val value: T, var next: Node<T>? = null, var previous: Node<T>? = null)
