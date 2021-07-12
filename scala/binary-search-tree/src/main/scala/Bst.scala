object Bst {
  def fromList[T](values: List[T])(implicit ordering: T => Ordered[T]): Bst[T] = values match {
    case x :: xs => xs.foldLeft(Bst(x))(_.insert(_))
    case x :: Nil => Bst(x)
    case _ => throw new IllegalArgumentException("Cannot construct tree from empty list")
  }

  def toList[T](tree: Bst[T]): List[T] = {
    def values(tree: Option[Bst[T]]): List[T] = tree match {
      case None => List.empty
      case Some(t) => values(t.left) ++ List(t.value) ++ values(t.right)
    }

    values(Some(tree))
  }
}

case class Bst[T](value: T, left: Option[Bst[T]] = None, right: Option[Bst[T]] = None)(implicit ordering: T => Ordered[T]) {
  def insert(newValue: T): Bst[T] = {
    if (newValue <= value)
      Bst(value, left = insert(newValue, left), right = right)
    else
      Bst(value, left = left, right = insert(newValue, right))
  }

  private def insert(newValue: T, tree: Option[Bst[T]]): Option[Bst[T]] = tree match {
    case None => Some(Bst(newValue))
    case Some(x) => Some(x.insert(newValue))
  }
}