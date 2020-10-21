class Microwave
    def initialize(input)
        minutes = (input / 100).to_i
        seconds = input - (minutes * 100)
        @@time = minutes * 60 + seconds
    end

    def timer
        '%02d:%02d' % [(@@time / 60).to_i, @@time % 60]
    end
end