object Pangrams {
  private val alphabet = 'a' to 'z'

  def isPangram(input: String): Boolean = (alphabet.toSet -- input.toLowerCase).isEmpty
}

