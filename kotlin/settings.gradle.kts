rootProject.name = "exercism-kotlin"
include(
    "allergies",
    "binary-search",
    "binary-search-tree",
    "collatz-conjecture",
    "complex-numbers",
    "custom-set",
    "diffie-hellman",
    "grains",
    "list-ops",
    "sieve",
    "sublist",
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
