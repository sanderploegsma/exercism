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
    "custom-set",
    "diffie-hellman",
    "flatten-array",
    "grade-school",
    "grains",
    "isbn-verifier",
    "largest-series-product",
    "linked-list",
    "list-ops",
    "luhn",
    "matrix",
    "nth-prime",
    "perfect-numbers",
    "prime-factors",
    "robot-simulator",
    "run-length-encoding",
    "series",
    "sieve",
    "sublist",
    "sum-of-multiples",
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
