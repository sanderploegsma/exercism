class Clock
    MAX_MINUTES = 24 * 60

    attr_accessor :minutes

    def initialize(hour: 0, minute: 0)
        total = hour * 60 + minute
        while total < 0
            total += MAX_MINUTES
        end
        @minutes = total % MAX_MINUTES
    end

    def +(other)
        Clock.new(minute: self.minutes + other.minutes)
    end

    def -(other)
        Clock.new(minute: self.minutes - other.minutes)
    end

    def ==(other)
        self.minutes == other.minutes
    end

    def to_s
        hours = self.minutes / 60
        minutes = self.minutes - hours * 60
        "%02d:%02d" % [hours, minutes]
    end
end