sealed trait Bowling {
  def roll(pins: Int): Bowling

  def score(): Either[Error, Int]
}

object Bowling {
  def apply(): Bowling = new BowlingGame(List.empty)
}

case class Error(message: String)

private class BowlingGame(rolls: List[Int]) extends Bowling {
  private val frameCount = 10

  override def roll(pins: Int): Bowling = new BowlingGame(rolls :+ pins)

  override def score(): Either[Error, Int] = {
    if (rolls.exists(x => x < 0 || x > 10))
      return Left(Error("Invalid roll found"))

    val frames = createFrames(rolls)

    if (frames.length != frameCount)
      return Left(Error("Invalid number of frames"))

    if (frames.exists(!_.isValid))
      return Left(Error("Invalid frame found"))

    Right(score(frames))
  }

  private def createFrames(rolls: List[Int], frameId: Int = 1): List[Frame] = rolls match {
    case Nil => List.empty
    case _ if frameId == frameCount => List(createFinalFrame(rolls))
    case 10 :: tail => Strike :: createFrames(tail, frameId + 1)
    case x1 :: x2 :: tail if x1 + x2 == 10 => Spare(List(x1, x2)) :: createFrames(tail, frameId + 1)
    case x1 :: x2 :: tail => Open(List(x1, x2)) :: createFrames(tail, frameId + 1)
  }

  private def createFinalFrame(rolls: List[Int]): Frame = rolls match {
    case 10 :: _ => FinalStrike(rolls)
    case x1 :: x2 :: _ if x1 + x2 == 10 => FinalSpare(rolls)
    case _ => Open(rolls)
  }

  private def score(frames: List[Frame]): Int = frames match {
    case Nil => 0
    case Open(rolls) :: tail => rolls.sum + score(tail)
    case Strike :: tail => 10 + tail.flatMap(_.rolls).take(2).sum + score(tail)
    case Spare(rolls) :: tail => rolls.sum + tail.flatMap(_.rolls).head + score(tail)
    case FinalSpare(rolls) :: Nil => rolls.sum
    case FinalStrike(rolls) :: Nil => rolls.sum
  }

  private sealed trait Frame {
    val rolls: List[Int]
    val isValid: Boolean
  }

  private case object Strike extends Frame {
    override val rolls: List[Int] = List(10)
    override val isValid: Boolean = true
  }

  private case class Spare(rolls: List[Int]) extends Frame {
    override val isValid: Boolean = rolls.length == 2 && rolls.sum == 10
  }

  private case class Open(rolls: List[Int]) extends Frame {
    override val isValid: Boolean = rolls.length == 2 && rolls.sum < 10
  }

  private case class FinalStrike(rolls: List[Int]) extends Frame {
    override val isValid: Boolean = rolls match {
      case 10 :: 10 :: _ :: Nil => true
      case 10 :: x1 :: x2 :: Nil => x1 + x2 <= 10
      case _ => false
    }
  }

  private case class FinalSpare(rolls: List[Int]) extends Frame {
    override val isValid: Boolean = rolls.length == 3 && rolls.take(2).sum == 10
  }
}