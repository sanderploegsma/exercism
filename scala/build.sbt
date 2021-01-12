ThisBuild / scalaVersion := "2.12.8"

lazy val root = (project in file("."))
  .aggregate(`hello-world`, `two-fer`, leap, `space-age`, `robot-name`, `collatz-conjecture`, `armstrong-numbers`,
    triangle, `flatten-array`, `perfect-numbers`, allergies, `all-your-base`, `grade-school`, bob, hamming,
    `palindrome-products`, series)

lazy val `all-your-base` = project
lazy val allergies = project
lazy val `armstrong-numbers` = project
lazy val bob = project
lazy val `collatz-conjecture` = project
lazy val `flatten-array` = project
lazy val `grade-school` = project
lazy val hamming = project
lazy val `hello-world` = project
lazy val leap = project
lazy val `palindrome-products` = project
lazy val `perfect-numbers` = project
lazy val `robot-name` = project
lazy val series = project
lazy val `space-age` = project
lazy val triangle = project
lazy val `two-fer` = project
