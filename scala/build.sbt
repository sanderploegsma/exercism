ThisBuild / scalaVersion := "2.12.8"

lazy val root = (project in file("."))
  .aggregate(`hello-world`, `two-fer`, leap, `space-age`, `robot-name`, `collatz-conjecture`, `armstrong-numbers`)

lazy val `hello-world` = project
lazy val `two-fer` = project
lazy val leap = project
lazy val `space-age` = project
lazy val `robot-name` = project
lazy val `collatz-conjecture` = project
lazy val `armstrong-numbers` = project