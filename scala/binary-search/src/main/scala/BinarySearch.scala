object BinarySearch {
  def find[T](items: Seq[T], item: T)(implicit orderer: T => Ordered[T]): Option[Int] =
    items match {
      case Nil => None
      case x :: Nil if x == item => Some(0)
      case _ :: Nil => None
      case _ =>
        val middle = items.length / 2
        items(middle) match {
          case x if x == item => Some(middle)
          case x if x > item => find(items.take(middle), item)
          case x if x < item => find(items.drop(middle), item).map(_ + middle)
        }
    }
}