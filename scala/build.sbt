ThisBuild / scalaVersion := "2.12.8"

lazy val root = (project in file("."))
  .aggregate(`hello-world`, `two-fer`, leap, `space-age`, `robot-name`, `collatz-conjecture`, `armstrong-numbers`,
    triangle, `flatten-array`, `perfect-numbers`, allergies)

lazy val `hello-world` = project
lazy val `two-fer` = project
lazy val leap = project
lazy val `space-age` = project
lazy val `robot-name` = project
lazy val `collatz-conjecture` = project
lazy val `armstrong-numbers` = project
lazy val triangle = project
lazy val `flatten-array` = project
lazy val `perfect-numbers` = project
lazy val allergies = project