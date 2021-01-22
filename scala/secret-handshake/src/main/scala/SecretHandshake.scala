object SecretHandshake {
  private object Flags {
    val Wink         : Int = 1 << 0
    val DoubleBlink  : Int = 1 << 1
    val CloseYourEyes: Int = 1 << 2
    val Jump         : Int = 1 << 3
    val Reverse      : Int = 1 << 4
  }

  private val events = Seq(
    Flags.Wink -> "wink",
    Flags.DoubleBlink -> "double blink",
    Flags.CloseYourEyes -> "close your eyes",
    Flags.Jump -> "jump"
  )

  def commands(mask: Int): List[String] = {
    val handshake = events
      .filter { case (flag, _) => isSatisfied(flag, mask) }
      .map { case (_, event) => event }
      .toList

    if (isSatisfied(Flags.Reverse, mask)) handshake.reverse else handshake
  }

  private def isSatisfied(flag: Int, mask: Int): Boolean = (mask & flag) > 0
}