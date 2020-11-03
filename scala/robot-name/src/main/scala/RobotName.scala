import Robot.generate

import scala.collection.mutable
import scala.util.Random

object Robot {
  private val alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
  private val numeric = "0123456789"

  private val recipe: Seq[String] = Seq(alpha, alpha, numeric, numeric, numeric)
  private val maxNumberOfNames = recipe.foldLeft(1)(_ * _.length)
  private val generated: mutable.HashSet[String] = mutable.HashSet.empty

  def generate(): String = {
    if (generated.size == maxNumberOfNames) {
      throw new UnsupportedOperationException("Robot names exhausted")
    }

    val name = Stream.continually {
      recipe.map(chars => chars.charAt(Random.nextInt(chars.length))).mkString("")
    }
      .filter { !generated.contains(_) }
      .head

    generated += name
    name
  }
}

class Robot {
  private var _name: String = generate()

  def name: String = _name

  def reset(): Unit = {
    this._name = generate()
  }
}