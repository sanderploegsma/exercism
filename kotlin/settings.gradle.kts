rootProject.name = "exercism-kotlin"
include(
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
    "difference-of-squares",
    "diffie-hellman",
    "flatten-array",
    "grade-school",
    "grains",
    "hamming",
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
    "rna-transcription",
    "robot-simulator",
    "run-length-encoding",
    "secret-handshake",
    "series",
    "sieve",
    "sublist",
    "sum-of-multiples",
    "triangle",
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
