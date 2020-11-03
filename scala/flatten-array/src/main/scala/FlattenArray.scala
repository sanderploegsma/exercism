object FlattenArray {
  def flatten(array: List[Any]): List[Int] = array.flatMap {
    case null => List()
    case x: Int => List(x)
    case x: List[Any] => flatten(x)
    case x => throw new IllegalArgumentException(s"Unexpected element $x")
  }
}