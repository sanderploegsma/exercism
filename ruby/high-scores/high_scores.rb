class HighScores
  attr_reader :scores, :personal_top_three

  def initialize(scores)
    @scores = scores
    @personal_top_three = scores.max(3)
  end

  def latest
    scores.last
  end

  def personal_best
    personal_top_three.first
  end

  def latest_is_personal_best?
    latest == personal_best
  end
end
