rootProject.name = "exercism-kotlin"
include("allergies")
include("binary-search")
include("binary-search-tree")
include("collatz-conjecture")
include("complex-numbers")
include("diffie-hellman")
include("sublist")

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
