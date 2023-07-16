rootProject.name = "exercism-kotlin"
include(
        "affine-cipher",
        "all-your-base",
        "allergies",
        "bank-account",
        "binary-search",
        "binary-search-tree",
        "collatz-conjecture",
        "complex-numbers",
        "custom-set",
        "diffie-hellman",
        "flatten-array",
        "grains",
        "largest-series-product",
        "linked-list",
        "list-ops",
        "nth-prime",
        "perfect-numbers",
        "prime-factors",
        "robot-simulator",
        "run-length-encoding",
        "sieve",
        "sublist",
        "sum-of-multiples",
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
