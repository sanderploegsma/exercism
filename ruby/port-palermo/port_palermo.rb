module Port
  Identifier = :PALE

  def self.get_identifier(city)
    city.upcase[0..3].to_sym
  end

  def self.get_terminal(ship_identifier)
    cargo = ship_identifier.to_s[0..2]
    ["OIL", "GAS"].include?(cargo) ? :A : :B
  end
end
