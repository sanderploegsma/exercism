rootProject.name = "exercism-kotlin"
include(
    "acronym",
    "affine-cipher",
    "all-your-base",
    "allergies",
    "anagram",
    "atbash-cipher",
    "bank-account",
    "binary-search",
    "binary-search-tree",
    "clock",
    "collatz-conjecture",
    "complex-numbers",
    "crypto-square",
    "custom-set",
    "darts",
    "difference-of-squares",
    "diffie-hellman",
    "dnd-character",
    "flatten-array",
    "gigasecond",
    "grade-school",
    "grains",
    "hamming",
    "hello-world",
    "isbn-verifier",
    "isogram",
    "largest-series-product",
    "linked-list",
    "list-ops",
    "luhn",
    "matching-brackets",
    "matrix",
    "nth-prime",
    "nucleotide-count",
    "perfect-numbers",
    "prime-factors",
    "raindrops",
    "resistor-color",
    "resistor-color-duo",
    "rna-transcription",
    "robot-simulator",
    "run-length-encoding",
    "saddle-points",
    "scrabble-score",
    "secret-handshake",
    "series",
    "sieve",
    "sublist",
    "sum-of-multiples",
    "triangle",
    "two-fer",
    "yacht",
    "zebra-puzzle"
)

pluginManagement {
    repositories {
        mavenCentral()
        gradlePluginPortal()
    }
    resolutionStrategy {
        eachPlugin {
            when (requested.id.id) {
                "org.jetbrains.kotlin.jvm" -> useModule("org.jetbrains.kotlin:kotlin-gradle-plugin:1.6.0")
            }
        }
    }
}
