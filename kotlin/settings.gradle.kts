rootProject.name = "exercism-kotlin"
include(
    "acronym",
    "affine-cipher",
    "all-your-base",
    "allergies",
    "anagram",
    "armstrong-numbers",
    "atbash-cipher",
    "bank-account",
    "binary-search",
    "binary-search-tree",
    "bob",
    "clock",
    "collatz-conjecture",
    "complex-numbers",
    "crypto-square",
    "custom-set",
    "darts",
    "difference-of-squares",
    "diffie-hellman",
    "dnd-character",
    "etl",
    "flatten-array",
    "forth",
    "gigasecond",
    "grade-school",
    "grains",
    "hamming",
    "hello-world",
    "isbn-verifier",
    "isogram",
    "largest-series-product",
    "leap",
    "linked-list",
    "list-ops",
    "luhn",
    "matching-brackets",
    "matrix",
    "meetup",
    "minesweeper",
    "nth-prime",
    "nucleotide-count",
    "pangram",
    "perfect-numbers",
    "phone-number",
    "prime-factors",
    "raindrops",
    "resistor-color",
    "resistor-color-duo",
    "resistor-color-trio",
    "reverse-string",
    "rna-transcription",
    "robot-name",
    "robot-simulator",
    "rotational-cipher",
    "run-length-encoding",
    "saddle-points",
    "scale-generator",
    "scrabble-score",
    "secret-handshake",
    "series",
    "sieve",
    "space-age",
    "sublist",
    "sum-of-multiples",
    "transpose",
    "triangle",
    "two-fer",
    "word-count",
    "wordy",
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
