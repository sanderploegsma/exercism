import scala.annotation.tailrec

object MatchingBrackets {
  private val brackets = Map(('(', ')'), ('[', ']'), ('{', '}'))

  def isPaired(brackets: String): Boolean = isPaired(List(), brackets)

  @tailrec
  private def isPaired(stack: List[Char], input: String): Boolean = {
    val expected = stack.headOption.flatMap(brackets.get)

    input.headOption match {
      case None => stack.isEmpty
      case Some(head) if brackets.keySet contains head => isPaired(head :: stack, input.tail)
      case Some(head) if brackets.values.toList contains head =>
        if (expected.contains(head)) isPaired(stack.tail, input.tail) else false
      case _ => isPaired(stack, input.tail)
    }
  }
}
