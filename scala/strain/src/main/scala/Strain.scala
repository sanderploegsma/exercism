object Strain {
  def keep[T](items: Seq[T], filter: T => Boolean): Seq[T] = {
    for (elem <- items if filter(elem)) yield elem
  }

  def discard[T](items: Seq[T], filter: T => Boolean): Seq[T] = {
    for (elem <- items if !filter(elem)) yield elem
  }
}