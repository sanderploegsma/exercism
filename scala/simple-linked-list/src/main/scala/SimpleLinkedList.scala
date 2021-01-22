trait SimpleLinkedList[T] {
  def isEmpty: Boolean
  def value: T
  def add(item: T): SimpleLinkedList[T]
  def next: SimpleLinkedList[T]
  def reverse: SimpleLinkedList[T]
  def toSeq: Seq[T]
}

object SimpleLinkedList {
  def apply[T](): SimpleLinkedList[T] = EmptyList[T]()

  def apply[T](args: T*): SimpleLinkedList[T] = fromSeq(args.toSeq)

  def fromSeq[T](seq: Seq[T]): SimpleLinkedList[T] = seq.foldLeft(SimpleLinkedList[T]())(_.add(_))
}

case class EmptyList[T]() extends SimpleLinkedList[T] {
  override def isEmpty: Boolean = true

  override def value: T = throw new NoSuchElementException()

  override def add(item: T): SimpleLinkedList[T] = LinkedList(item, this)

  override def next: SimpleLinkedList[T] = this

  override def reverse: SimpleLinkedList[T] = this

  override def toSeq: Seq[T] = Seq()
}

case class LinkedList[T](value: T, next: SimpleLinkedList[T]) extends SimpleLinkedList[T] {
  override def isEmpty: Boolean = false

  override def add(item: T): SimpleLinkedList[T] = LinkedList(value, next.add(item))

  override def reverse: SimpleLinkedList[T] = next.reverse.add(value)

  override def toSeq: Seq[T] = value +: next.toSeq
}