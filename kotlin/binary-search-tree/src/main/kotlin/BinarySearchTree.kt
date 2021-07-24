import java.util.*

class BinarySearchTree<T : Comparable<T>> {

    data class Node<T>(val data: T, val left: Node<T>? = null, val right: Node<T>? = null)

    var root: Node<T>? = null

    fun insert(value: T) {
        root = insert(value, root)
    }

    private fun insert(value: T, node: Node<T>?): Node<T> = when {
        node == null -> Node(value)
        value > node.data -> node.copy(right = insert(value, node.right))
        else -> node.copy(left = insert(value, node.left))
    }

    fun asSortedList(): List<T> = asSortedList(root)

    private fun asSortedList(node: Node<T>?): List<T> {
        if (node == null) {
            return emptyList()
        }

        return asSortedList(node.left) + node.data + asSortedList(node.right)
    }

    fun asLevelOrderList(): List<T> {
        val items = mutableListOf<T>()
        val queue = LinkedList<Node<T>?>()
        queue.add(root)

        while (queue.isNotEmpty()) {
            val node = queue.poll() ?: continue

            items.add(node.data)
            queue.add(node.left)
            queue.add(node.right)
        }

        return items
    }
}
