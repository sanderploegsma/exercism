object SpaceAge {
  def onEarth(seconds: Int): Double = seconds / 31557600D
  def onMercury(seconds: Int): Double = onEarth(seconds) / 0.2408467
  def onVenus(seconds: Int): Double = onEarth(seconds) / 0.61519726
  def onMars(seconds: Int): Double = onEarth(seconds) / 1.8808158
  def onJupiter(seconds: Int): Double = onEarth(seconds) / 11.862615
  def onSaturn(seconds: Int): Double = onEarth(seconds) / 29.447498
  def onUranus(seconds: Int): Double = onEarth(seconds) / 84.016846
  def onNeptune(seconds: Int): Double = onEarth(seconds) / 164.79132
}