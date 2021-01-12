object Bob {
  def response(statement: String): String = statement.trim match {
    case s if isQuestion(s) && isUpperCase(s) => "Calm down, I know what I'm doing!"
    case s if isUpperCase(s) => "Whoa, chill out!"
    case s if isQuestion(s) => "Sure."
    case s if isSilence(s) => "Fine. Be that way!"
    case _ => "Whatever."
  }

  private def isQuestion(statement: String) = statement.endsWith("?")
  private def isUpperCase(statement: String) = statement.toCharArray.exists(_.isUpper) && !statement.toCharArray.exists(_.isLower)
  private def isSilence(statement: String) = statement.isBlank
}
