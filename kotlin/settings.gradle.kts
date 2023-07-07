rootProject.name = "exercism-kotlin"
include(
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
    "linked-list",
    "list-ops",
    "prime-factors",
    "robot-simulator",
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
