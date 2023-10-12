import org.scalatest.funsuite.AnyFunSuite
import org.scalatest.matchers.should.Matchers


/** @version 1.3.0 */
class MatchingBracketsTest extends AnyFunSuite with Matchers {

  test("paired square brackets") {
    MatchingBrackets.isPaired("[]") should be(true)
  }

  test("empty string") {
    MatchingBrackets.isPaired("") should be(true)
  }

  test("unpaired brackets") {
    MatchingBrackets.isPaired("[[") should be(false)
  }

  test("wrong ordered brackets") {
    MatchingBrackets.isPaired("}{") should be(false)
  }

  test("wrong closing bracket") {
    MatchingBrackets.isPaired("{]") should be(false)
  }

  test("paired with whitespace") {
    MatchingBrackets.isPaired("{ }") should be(true)
  }

  test("partially paired brackets") {
    MatchingBrackets.isPaired("{[])") should be(false)
  }

  test("simple nested brackets") {
    MatchingBrackets.isPaired("{[]}") should be(true)
  }

  test("several paired brackets") {
    MatchingBrackets.isPaired("{}[]") should be(true)
  }

  test("paired and nested brackets") {
    MatchingBrackets.isPaired("([{}({}[])])") should be(true)
  }

  test("unopened closing brackets") {
    MatchingBrackets.isPaired("{[)][]}") should be(false)
  }

  test("unpaired and nested brackets") {
    MatchingBrackets.isPaired("([{])") should be(false)
  }

  test("paired and wrong nested brackets") {
    MatchingBrackets.isPaired("[({]})") should be(false)
  }

  test("math expression") {
    MatchingBrackets.isPaired("(((185 + 223.85) * 15) - 543)/2") should be(true)
  }

  test("complex latex expression") {
    MatchingBrackets.isPaired(
      """\left(\begin{array}{cc} \frac{1}{3} & x\ \mathrm{e}^{x} &... x^2 \end{array}\right)""") should be(
      true)
  }
}
