ThisBuild / scalaVersion := "2.12.8"

lazy val root = (project in file("."))
  .aggregate(`hello-world`, `two-fer`, leap, `space-age`)

lazy val `hello-world` = project
lazy val `two-fer` = project
lazy val leap = project
lazy val `space-age` = project