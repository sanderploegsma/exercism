class Gigasecond
    def self.from(start)
        Time.at(start.to_i + 1e9)
    end
end
