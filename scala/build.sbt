ThisBuild / scalaVersion := "2.12.8"

lazy val root = (project in file("."))
  .aggregate(`hello-world`, `two-fer`, leap, `space-age`, `robot-name`, `collatz-conjecture`, `armstrong-numbers`,
    triangle, `flatten-array`, `perfect-numbers`, allergies, `all-your-base`, `grade-school`, bob, hamming,
    `palindrome-products`, series, `nth-prime`, etl, `robot-simulator`, `secret-handshake`, `atbash-cipher`,
    `saddle-points`, `simple-linked-list`, `pythagorean-triplet`, `queen-attack`, `nucleotide-count`, `complex-numbers`,
    `custom-set`, `binary-search`, grains, `linked-list`, `binary-search-tree`, sublist, `largest-series-product`,
    `zebra-puzzle`, raindrops)

lazy val `all-your-base` = project
lazy val allergies = project
lazy val `armstrong-numbers` = project
lazy val `atbash-cipher` = project
lazy val `binary-search` = project
lazy val `binary-search-tree` = project
lazy val bob = project
lazy val `collatz-conjecture` = project
lazy val `complex-numbers` = project
lazy val `custom-set` = project
lazy val etl = project
lazy val `flatten-array` = project
lazy val `grade-school` = project
lazy val grains = project
lazy val hamming = project
lazy val `hello-world` = project
lazy val `largest-series-product` = project
lazy val leap = project
lazy val `linked-list` = project
lazy val `nth-prime` = project
lazy val `nucleotide-count` = project
lazy val `palindrome-products` = project
lazy val `perfect-numbers` = project
lazy val `pythagorean-triplet` = project
lazy val `queen-attack` = project
lazy val raindrops = project
lazy val `robot-name` = project
lazy val `robot-simulator` = project
lazy val `saddle-points` = project
lazy val `secret-handshake` = project
lazy val series = project
lazy val `simple-linked-list` = project
lazy val `space-age` = project
lazy val sublist = project
lazy val triangle = project
lazy val `two-fer` = project
lazy val `zebra-puzzle` = project
