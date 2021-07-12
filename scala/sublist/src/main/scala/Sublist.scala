object Sublist extends Enumeration {
  type Sublist = Value
  val Equal, Unequal, Sublist, Superlist = Value

  def sublist[T](a: List[T], b: List[T]): Sublist = {
    val isSublist = isContainedBy(a, b)
    val isSuperlist = isContainedBy(b, a)

    (isSublist, isSuperlist) match {
      case (true, true) => Equal
      case (true, false) => Sublist
      case (false, true) => Superlist
      case (false, false) => Unequal
    }
  }

  private def isContainedBy[T](a: List[T], b: List[T]): Boolean = b match {
    case _ if a == Nil => true
    case _ if b.length < a.length => false
    case _ => b.sliding(a.length, 1).contains(a)
  }
}