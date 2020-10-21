class Darts
    def initialize(x, y)
        @@x = x
        @@y = y
    end

    def score
        case dist.ceil
        when 0..1 then 10
        when 2..5 then 5
        when 6..10 then 1
        else 0
        end
    end

    def dist
        Math.sqrt(@@x ** 2 + @@y ** 2)
    end
end