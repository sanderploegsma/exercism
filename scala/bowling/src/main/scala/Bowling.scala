sealed trait Bowling {
  def roll(pins: Int): Bowling

  def score(): Either[String, Int]
}

object Bowling {
  def apply(): Bowling = BowlingGameFrame(history = List.empty, rolls = List.empty)
}

private case class InvalidBowlingGame(message: String) extends Bowling {
  override def roll(pins: Int): Bowling = this

  override def score(): Either[String, Int] = Left(message)
}

private case class FinishedBowlingGame(frames: List[CompletedFrame]) extends Bowling {
  override def roll(pins: Int): Bowling = InvalidBowlingGame("Cannot roll after game has finished")

  override def score(): Either[String, Int] = Right(score(frames))

  private def score(frames: List[CompletedFrame]): Int = frames match {
    case Nil => 0
    case frame :: tail =>
      val nextRolls = tail.flatMap(_.rolls)
      val bonusScore = frame.frameType match {
        case Spare => nextRolls.head
        case Strike => nextRolls.take(2).sum
        case _ => 0
      }
      frame.rolls.sum + bonusScore + score(tail)
  }
}

private case class BowlingGameFrame(history: List[CompletedFrame], rolls: List[Int]) extends Bowling {
  override def roll(pins: Int): Bowling = {
    if (pins < 0 || pins > 10 - rolls.sum)
      return InvalidBowlingGame("Invalid roll")

    val frameType = rolls match {
      case Nil if pins < 10 => None
      case Nil => Some(Strike)
      case prev :: Nil if prev + pins == 10 => Some(Spare)
      case _ => Some(Open)
    }

    frameType
      .map(CompletedFrame(rolls :+ pins, _))
      .map(f => startNewFrame(history :+ f))
      .getOrElse(BowlingGameFrame(history, rolls :+ pins))
  }

  private def startNewFrame(frames: List[CompletedFrame]): Bowling =
    if (frames.length < 9) {
      BowlingGameFrame(frames, rolls = List.empty)
    } else {
      BowlingGameFinalFrame(frames, rolls = List.empty)
    }

  override def score(): Either[String, Int] = Left("Cannot calculate score for game that is not yet finished")
}

private case class BowlingGameFinalFrame(history: List[CompletedFrame], rolls: List[Int], pinsLeft: Int = 10) extends Bowling {
  override def roll(pins: Int): Bowling = {
    if (pins < 0 || pins > pinsLeft)
      return InvalidBowlingGame("Invalid roll")

    val nextPins = pinsLeft - pins match {
      case 0 => 10
      case n => n
    }

    rolls match {
      case _ :: _ :: Nil => FinishedBowlingGame(history :+ CompletedFrame(rolls :+ pins, Final))
      case prev :: Nil if prev + pins < 10 => FinishedBowlingGame(history :+ CompletedFrame(rolls :+ pins, Final))
      case _ => BowlingGameFinalFrame(history, rolls :+ pins, nextPins)
    }
  }

  override def score(): Either[String, Int] = Left("Cannot calculate score for game that is not yet finished")
}

private sealed trait FrameType

private case object Strike extends FrameType

private case object Spare extends FrameType

private case object Open extends FrameType

private case object Final extends FrameType

private case class CompletedFrame(rolls: List[Int], frameType: FrameType)