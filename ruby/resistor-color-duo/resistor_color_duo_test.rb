require 'minitest/autorun'
require_relative 'resistor_color_duo'

# Common test data version: 2.1.0 00dda3a
class ResistorColorDuoTest < Minitest::Test
  def test_brown_and_black
    assert_equal 10, ResistorColorDuo.value(["brown", "black"])
  end

  def test_blue_and_grey
    assert_equal 68, ResistorColorDuo.value(["blue", "grey"])
  end

  def test_yellow_and_violet
    assert_equal 47, ResistorColorDuo.value(["yellow", "violet"])
  end

  def test_orange_and_orange
    assert_equal 33, ResistorColorDuo.value(["orange", "orange"])
  end

  def test_ignore_additional_colors
    assert_equal 51, ResistorColorDuo.value(["green", "brown", "orange"])
  end
end
