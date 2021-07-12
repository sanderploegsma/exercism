private case class Node[T](value: T, var next: Option[Node[T]], var previous: Option[Node[T]])

case class Deque[T]() {
  private var head: Option[Node[T]] = None
  private var tail: Option[Node[T]] = None

  def push(value: T): Unit = {
    val node = Node(value, previous = tail, next = None)

    tail match {
      case None =>
        head = Some(node)
        tail = Some(node)
      case Some(last) =>
        last.next = Some(node)
        tail = Some(node)
    }
  }

  def pop: Option[T] = tail match {
    case None => None
    case Some(node) =>
      node.previous match {
        case None =>
          head = None
          tail = None
        case Some(previous) =>
          previous.next = None
          tail = Some(previous)
      }
      Some(node.value)
  }

  def unshift(value: T): Unit = {
    val node = Node(value, next = head, previous = None)

    head match {
      case None =>
        head = Some(node)
        tail = Some(node)
      case Some(first) =>
        first.previous = Some(node)
        head = Some(node)
    }
  }

  def shift: Option[T] = head match {
    case None => None
    case Some(node) =>
      node.next match {
        case None =>
          head = None
          tail = None
        case Some(next) =>
          next.previous = None
          head = Some(next)
      }
      Some(node.value)
  }
}