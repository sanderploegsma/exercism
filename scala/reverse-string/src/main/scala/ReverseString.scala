object ReverseString {
  def reverse(str: String): String =
    str.indices.map(i => str.charAt(str.length - i  - 1)).mkString
}
