class Rules
  def bonus_points?(power_up_active, touching_bandit)
    touching_bandit && power_up_active
  end

  def score?(touching_power_up, touching_crystal)
    touching_crystal || touching_power_up
  end

  def lose?(power_up_active, touching_bandit)
    touching_bandit && !power_up_active
  end

  def win?(has_picked_up_all_crystals, power_up_active, touching_bandit)
    !lose?(power_up_active, touching_bandit) && has_picked_up_all_crystals
  end
end
